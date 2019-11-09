namespace MSBuildCode
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// Exported using ILSpy from Microsoft.Build.Tasks.Core.dll
    /// </summary>
    [ComImport]
    [SecurityCritical]
    [ComConversionLoss]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("9FD93CCF-3280-4391-B3A9-96E1CDE77C8D")]
    internal interface IClrStrongName
    {
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        int GetHashFromAssemblyFile([In] [MarshalAs(UnmanagedType.LPStr)] string pszFilePath, [In] [Out] [MarshalAs(UnmanagedType.U4)] ref int piHashAlg, [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pbHash, [In] [MarshalAs(UnmanagedType.U4)] int cchHash, [MarshalAs(UnmanagedType.U4)] out int pchHash);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        int GetHashFromAssemblyFileW([In] [MarshalAs(UnmanagedType.LPWStr)] string pwzFilePath, [In] [Out] [MarshalAs(UnmanagedType.U4)] ref int piHashAlg, [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pbHash, [In] [MarshalAs(UnmanagedType.U4)] int cchHash, [MarshalAs(UnmanagedType.U4)] out int pchHash);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        int GetHashFromBlob([In] IntPtr pbBlob, [In] [MarshalAs(UnmanagedType.U4)] int cchBlob, [In] [Out] [MarshalAs(UnmanagedType.U4)] ref int piHashAlg, [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] pbHash, [In] [MarshalAs(UnmanagedType.U4)] int cchHash, [MarshalAs(UnmanagedType.U4)] out int pchHash);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        int GetHashFromFile([In] [MarshalAs(UnmanagedType.LPStr)] string pszFilePath, [In] [Out] [MarshalAs(UnmanagedType.U4)] ref int piHashAlg, [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pbHash, [In] [MarshalAs(UnmanagedType.U4)] int cchHash, [MarshalAs(UnmanagedType.U4)] out int pchHash);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        int GetHashFromFileW([In] [MarshalAs(UnmanagedType.LPWStr)] string pwzFilePath, [In] [Out] [MarshalAs(UnmanagedType.U4)] ref int piHashAlg, [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pbHash, [In] [MarshalAs(UnmanagedType.U4)] int cchHash, [MarshalAs(UnmanagedType.U4)] out int pchHash);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        int GetHashFromHandle([In] IntPtr hFile, [In] [Out] [MarshalAs(UnmanagedType.U4)] ref int piHashAlg, [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pbHash, [In] [MarshalAs(UnmanagedType.U4)] int cchHash, [MarshalAs(UnmanagedType.U4)] out int pchHash);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [return: MarshalAs(UnmanagedType.U4)]
        int StrongNameCompareAssemblies([In] [MarshalAs(UnmanagedType.LPWStr)] string pwzAssembly1, [In] [MarshalAs(UnmanagedType.LPWStr)] string pwzAssembly2, [MarshalAs(UnmanagedType.U4)] out int dwResult);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        int StrongNameFreeBuffer([In] IntPtr pbMemory);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        int StrongNameGetBlob([In] [MarshalAs(UnmanagedType.LPWStr)] string pwzFilePath, [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pbBlob, [In] [Out] [MarshalAs(UnmanagedType.U4)] ref int pcbBlob);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        int StrongNameGetBlobFromImage([In] IntPtr pbBase, [In] [MarshalAs(UnmanagedType.U4)] int dwLength, [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pbBlob, [In] [Out] [MarshalAs(UnmanagedType.U4)] ref int pcbBlob);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        int StrongNameGetPublicKey([In] [MarshalAs(UnmanagedType.LPWStr)] string pwzKeyContainer, [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pbKeyBlob, [In] [MarshalAs(UnmanagedType.U4)] int cbKeyBlob, out IntPtr ppbPublicKeyBlob, [MarshalAs(UnmanagedType.U4)] out int pcbPublicKeyBlob);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [return: MarshalAs(UnmanagedType.U4)]
        int StrongNameHashSize([In] [MarshalAs(UnmanagedType.U4)] int ulHashAlg, [MarshalAs(UnmanagedType.U4)] out int cbSize);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        int StrongNameKeyDelete([In] [MarshalAs(UnmanagedType.LPWStr)] string pwzKeyContainer);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        int StrongNameKeyGen([In] [MarshalAs(UnmanagedType.LPWStr)] string pwzKeyContainer, [In] [MarshalAs(UnmanagedType.U4)] int dwFlags, out IntPtr ppbKeyBlob, [MarshalAs(UnmanagedType.U4)] out int pcbKeyBlob);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        int StrongNameKeyGenEx([In] [MarshalAs(UnmanagedType.LPWStr)] string pwzKeyContainer, [In] [MarshalAs(UnmanagedType.U4)] int dwFlags, [In] [MarshalAs(UnmanagedType.U4)] int dwKeySize, out IntPtr ppbKeyBlob, [MarshalAs(UnmanagedType.U4)] out int pcbKeyBlob);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        int StrongNameKeyInstall([In] [MarshalAs(UnmanagedType.LPWStr)] string pwzKeyContainer, [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pbKeyBlob, [In] [MarshalAs(UnmanagedType.U4)] int cbKeyBlob);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        int StrongNameSignatureGeneration([In] [MarshalAs(UnmanagedType.LPWStr)] string pwzFilePath, [In] [MarshalAs(UnmanagedType.LPWStr)] string pwzKeyContainer, [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pbKeyBlob, [In] [MarshalAs(UnmanagedType.U4)] int cbKeyBlob, [In] [Out] IntPtr ppbSignatureBlob, [MarshalAs(UnmanagedType.U4)] out int pcbSignatureBlob);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        int StrongNameSignatureGenerationEx([In] [MarshalAs(UnmanagedType.LPWStr)] string wszFilePath, [In] [MarshalAs(UnmanagedType.LPWStr)] string wszKeyContainer, [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pbKeyBlob, [In] [MarshalAs(UnmanagedType.U4)] int cbKeyBlob, [In] [Out] IntPtr ppbSignatureBlob, [MarshalAs(UnmanagedType.U4)] out int pcbSignatureBlob, [In] [MarshalAs(UnmanagedType.U4)] int dwFlags);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        int StrongNameSignatureSize([In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pbPublicKeyBlob, [In] [MarshalAs(UnmanagedType.U4)] int cbPublicKeyBlob, [MarshalAs(UnmanagedType.U4)] out int pcbSize);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [return: MarshalAs(UnmanagedType.U4)]
        int StrongNameSignatureVerification([In] [MarshalAs(UnmanagedType.LPWStr)] string pwzFilePath, [In] [MarshalAs(UnmanagedType.U4)] int dwInFlags, [MarshalAs(UnmanagedType.U4)] out int dwOutFlags);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [return: MarshalAs(UnmanagedType.U4)]
        int StrongNameSignatureVerificationEx([In] [MarshalAs(UnmanagedType.LPWStr)] string pwzFilePath, [In] [MarshalAs(UnmanagedType.I1)] bool fForceVerification, [MarshalAs(UnmanagedType.I1)] out bool fWasVerified);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [return: MarshalAs(UnmanagedType.U4)]
        int StrongNameSignatureVerificationFromImage([In] IntPtr pbBase, [In] [MarshalAs(UnmanagedType.U4)] int dwLength, [In] [MarshalAs(UnmanagedType.U4)] int dwInFlags, [MarshalAs(UnmanagedType.U4)] out int dwOutFlags);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        int StrongNameTokenFromAssembly([In] [MarshalAs(UnmanagedType.LPWStr)] string pwzFilePath, out IntPtr ppbStrongNameToken, [MarshalAs(UnmanagedType.U4)] out int pcbStrongNameToken);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        int StrongNameTokenFromAssemblyEx([In] [MarshalAs(UnmanagedType.LPWStr)] string pwzFilePath, out IntPtr ppbStrongNameToken, [MarshalAs(UnmanagedType.U4)] out int pcbStrongNameToken, out IntPtr ppbPublicKeyBlob, [MarshalAs(UnmanagedType.U4)] out int pcbPublicKeyBlob);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        int StrongNameTokenFromPublicKey([In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pbPublicKeyBlob, [In] [MarshalAs(UnmanagedType.U4)] int cbPublicKeyBlob, out IntPtr ppbStrongNameToken, [MarshalAs(UnmanagedType.U4)] out int pcbStrongNameToken);
    }
}