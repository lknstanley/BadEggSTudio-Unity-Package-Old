using BadEggStudio.Security ;

public static class EncryptionExtension
{
    public static byte[] GetHash( this byte[] data, HashType hashType = HashType.SHA256 )
    {
        return Encryption.GetBinaryHash( data, hashType ) ;
    }

    public static string GetHashString( this string data, HashType hashType = HashType.SHA256 )
    {
        return Encryption.GetHash( data, hashType ) ;
    }

    public static byte[] Encrypt( this byte[] data, int key = 0 )
    {
        return Encryption.BinaryEncrypt( data, key ) ;
    }

    public static byte[] Decrypt( this byte[] encrypted, int key = 0 )
    {
        return Encryption.BinaryDecrypt( encrypted, key ) ;
    }

    public static string EncryptToString( this byte[] data, int key = 0 )
    {
        return Encryption.EncryptToString( data, key ) ;
    }

    public static byte[] DecryptToBytes( this string encrypted )
    {
        return Encryption.DecryptToBytes( encrypted ) ;
    }


    ///<summary>
    ///Return Encrypted Data. (Format: {Key Index}!!!{Encrypted Content}!!!{Nonce})
    ///</summary>
    public static string Encrypt( this string data, int key = 0 )
    {
        return Encryption.Encrypt( data, key ) ;
    }

    public static string Decrypt( this string encrypted )
    {
        return Encryption.Decrypt( encrypted ) ;
    }
}