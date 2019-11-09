using System;
using System.Globalization;
using System.IO;

namespace MSBuildCode
{
    /// <summary>
    /// Adjusted MSBuild source from https://github.com/microsoft/msbuild/blob/master/src/Tasks/ResolveKeySource.cs
    /// </summary>
    public static class ResolveKeySourceTask
    {
        private const string pfxFileExtension = ".pfx";
        private const string pfxFileContainerPrefix = "VS_KEY_";

        // This is was originally a msbuild task method. Only its first half is used.
        public static string ResolveAssemblyKey(string KeyFile)
        {
            if (string.IsNullOrEmpty(KeyFile))
            {
                throw new ArgumentException("KeyFile cannot be empty");
            }

            string keyFileExtension = String.Empty;
            try
            {
                keyFileExtension = Path.GetExtension(KeyFile);
            }
            catch (ArgumentException ex)
            {
                var message = string.Format("MSB3324: Invalid key file name \"{0}\". {1}", KeyFile, ex.Message);
                throw new ApplicationException(message);
            }

            if (0 != String.Compare(keyFileExtension, pfxFileExtension, StringComparison.OrdinalIgnoreCase))
            {
                throw new ApplicationException($"This implementation only works with {pfxFileExtension} keys.");
            }

            // it is .pfx file. It is being imported into key container with name = "VS_KEY_<MD5 check sum of the encrypted file>"
            FileStream fs = null;
            try
            {
                string currentUserName = Environment.UserDomainName + "\\" + Environment.UserName;
                // we use the curent user name to randomize the associated container name, i.e different user on the same machine will export to different keys
                // this is because SNAPI by default will create keys in "per-machine" crypto store (visible for all the user) but will set the permission such only
                // creator will be able to use it. This will make imposible for other user both to sign or export the key again (since they also can not delete that key).
                // Now different users will use different container name. We use ToLower(invariant) because this is what the native equivalent of this function (Create new key, or VC++ import-er).
                // use as well and we want to keep the hash (and key container name the same) otherwise user could be prompt for a password twice.
                byte[] userNameBytes =
                    System.Text.Encoding.Unicode.GetBytes(
                        currentUserName.ToLower(CultureInfo.InvariantCulture));
                fs = File.OpenRead(KeyFile);
                int fileLength = (int)fs.Length;
                var keyBytes = new byte[fileLength];
                fs.Read(keyBytes, 0, fileLength);

                UInt64 hash = HashFromBlob(keyBytes);
                hash ^= HashFromBlob(
                    userNameBytes); // modify it with the username hash, so each user would get different hash for the same key

                string hashedContainerName =
                    pfxFileContainerPrefix + hash.ToString("X016", CultureInfo.InvariantCulture);

                return hashedContainerName;
            }
            finally
            {
                fs?.Close();
            }
        }

        public static bool IsContainerInstalled(string hashedContainerName)
        {
            
            if (StrongNameHelpers.StrongNameGetPublicKey(hashedContainerName, IntPtr.Zero, 0, out IntPtr publicKeyBlob, out _) && publicKeyBlob != IntPtr.Zero)
            {
                StrongNameHelpers.StrongNameFreeBuffer(publicKeyBlob);
                return true;
            }

            return false;
        }

        // We we use hash the contens of .pfx file so we can establish relationship file <-> container name, whithout
        // need to prompt for password. Note this is not used for any security reasons. With the departure from standard MD5 algoritm
        // we need as simple hash function for replacement. The data blobs we use (.pfx files)  are
        // encrypted meaning they have high entropy, so in all practical pupose even a simpliest
        // hash would give good enough results. This code needs to be kept in sync with the code  in compsvcpkgs
        // to prevent double prompt for newly created keys. The magic numbers here are just random primes
        // in the range 10m/20m.
        private static UInt64 HashFromBlob(byte[] data)
        {
            UInt32 dw1 = 17339221;
            UInt32 dw2 = 19619429;
            UInt32 pos = 10803503;

            foreach (byte b in data)
            {
                UInt32 value = b ^ pos;
                pos *= 10803503;
                dw1 += ((value ^ dw2) * 15816943) + 17368321;
                dw2 ^= ((value + dw1) * 14984549) ^ 11746499;
            }
            UInt64 result = dw1;
            result <<= 32;
            result |= dw2;
            return result;
        }
    }
}