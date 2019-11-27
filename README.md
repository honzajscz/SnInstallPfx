## PFX problem

Have you ever received following MSBuild error?
```
error MSB3325: Cannot import the following key file: my.pfx. 
The key file may be password protected. 
To correct this, try to import the certificate again or 
manually install the certificate to the Strong Name CSP 
with the following key container name: VS_KEY_ABCDEF1234567890
```
This error occurs when you build an MSBuild project and attempt to strong name sign it with a password protected PFX bearing a key pair. Under the hood MSBuild computes a hash using your domain\username and the PFX file bytes and searches for a private/public key container named *VS_KEY_\<THAT_HASH\>* in a system cryptographic service provider (CSP) to sign the compiled project.

To fix the compilation error you first need to install the key pair into the provided container and register it with the CSP. The .NET SDK contains the sn.exe* utility allow to do so. The full command is 
```
sn.exe -i <infile> <container>
```
This command has two drawbacks 

 1.  You have  to pass the container name (*VS_KEY_ABCDEF1234567890*)
 2. You have to enter PFX password. This password cannot be passed as a parameter which make things complicated in batch scenarios.

## SnInstallPFX utility
I have written a .NET utility that overcomes the aforementioned drawbacks. It computes the container name from the PFX file (if not specified) and accepts the password as a parameter.

```
SnInstallPfx.exe <pfx_infile> <pfx_password>
SnInstallPfx.exe <pfx_infile> <pfx_password> <container_name>
```
The hash computing is copied from the MSBuild source code on GitHub.

## Download 
Check [the release tab](https://github.com/honzajscz/SnInstallPfx/releases).

## Useful commands

```
// list containers in CSP, add -v switch for verbose output
certutil -csp "Microsoft Strong Cryptographic Provider" -key

// delete a container from CSP
certutil -delkey -csp "Microsoft Strong Cryptographic Provider" "<container>"

```
