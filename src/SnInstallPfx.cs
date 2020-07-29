using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using MSBuildCode;

namespace SnInstallPfx
{
    // Utility to replace the sn.exe -i command that does not accepts password. 
    public static class SnInstallPfx
    {
        static int Main(string[] args)
        {
            // params and usage
            if (args.Length == 0 || args[0] == "?" || args[0] == "-?" || (args.Length != 1 && args.Length != 2 && args.Length != 3))
            {
                Console.WriteLine($"By Honzajscz at {DateTime.Now.Year}");
                Console.WriteLine($"https://github.com/honzajscz/SnInstallPfx");
                Console.WriteLine();
                Console.WriteLine("Installs key pair from <pfx_infile> into a key container compatible for MSBuild.");
                Console.WriteLine("This utility is an alternative for command sn.exe -i <infile> <container>.");
                Console.WriteLine("It accepts password from command line and automatically generates a container name for <pxf_infile> if no container name is specified via the <container_name> argument.");
                Console.WriteLine();
                Console.WriteLine("Usage:");
                Console.WriteLine($"{Assembly.GetEntryAssembly().GetName().Name}.exe <pfx_infile> // show information about the pfx_infile");
                Console.WriteLine($"{Assembly.GetEntryAssembly().GetName().Name}.exe <pfx_infile> <pfx_password> // install the pfx_infile");
                Console.WriteLine($"{Assembly.GetEntryAssembly().GetName().Name}.exe <pfx_infile> <pfx_password> <container_name> // install the pfx_infile under container_name");
                Console.WriteLine();

                return -1;
            }

            string pfxPath = args[0];
            string pfxContainer = args.Length == 3 ? args[2] : ResolveKeySourceTask.ResolveAssemblyKey(pfxPath);

            bool infoOnly = args.Length == 1;
            if (infoOnly)
            {
                Console.WriteLine(pfxContainer);
                Console.WriteLine($"Installed: {ResolveKeySourceTask.IsContainerInstalled(pfxContainer)}");
                return 0;
            }

            if (ResolveKeySourceTask.IsContainerInstalled(pfxContainer))
            {
                //Installs from infile in the specified key container. The key container resides in the strong name CSP.
                Console.Error.WriteLine($"The key pair is already installed in the strong name CSP key container '{pfxContainer}'.");
                Console.Error.WriteLine("To delete the key container run following command from the Developer Command Prompt:");
                Console.Error.WriteLine($"sn.exe -d {pfxContainer}");
                Console.Error.WriteLine();
                Console.Error.WriteLine("To list all installed key containers run following command:");
                Console.Error.WriteLine("certutil -csp \"Microsoft Strong Cryptographic Provider\" -key");
                return -2;
            }

            string pfxPassword = args[1];
            // open pfx and export its private key
            var pfxCert = new X509Certificate2(pfxPath, pfxPassword, X509KeyStorageFlags.Exportable);
            var pfxPrivateKey = pfxCert.PrivateKey as RSACryptoServiceProvider;
            var pfxCspBlob = pfxPrivateKey.ExportCspBlob(true);


            // create cryptographic service provider (CSP) and machine-wide persistent key container
            // more at https://stackoverflow.com/questions/2528186/what-exactly-is-a-key-container
            // and https://www.sysadmins.lv/blog-en/certutil-tips-and-tricks-query-cryptographic-service-providers-csp-and-ksp.aspx
            const string DotNetStrongSigningCSP = "Microsoft Strong Cryptographic Provider";
            var cspParameters = new CspParameters(1, DotNetStrongSigningCSP, pfxContainer)
            {
                KeyNumber = (int)KeyNumber.Signature, // container used for signing 
                Flags = CspProviderFlags.UseMachineKeyStore | CspProviderFlags.UseNonExportableKey
            };

            using (var rsaCSP = new RSACryptoServiceProvider(cspParameters))
            {
                rsaCSP.PersistKeyInCsp = true;
                rsaCSP.ImportCspBlob(pfxCspBlob);
            };

            // output
            // This not an actual error - just avoiding output pollution.
            Console.Error.WriteLine($"The key pair has been installed into the strong name CSP key container '{pfxContainer}'.");
            // Write the container to the output
            Console.WriteLine(pfxContainer);
            return 0;

        }
    }


}


