using System.Security.Cryptography;

namespace BadEggStudio.Security.Internal
{
    public class Hash
    {
        private static HashAlgorithm _MD5 = null ;
        private static HashAlgorithm _SHA1 = null ;
        private static HashAlgorithm _SHA256 = null ;
        private static HashAlgorithm _SHA512 = null ;

        internal static HashAlgorithm GetHashAlgorithm( HashType type )
        {
            switch( type )
            {
                case HashType.MD5:
                    if ( _MD5 == null )
                    {
                        _MD5 = MD5.Create() ;
                    }
                    return _MD5 ;
                case HashType.SHA1:
                    if ( _SHA1 == null )
                    {
                        _SHA1 = new SHA1CryptoServiceProvider() ;
                    }
                    return _SHA1 ;
                case HashType.SHA256:
                    if ( _SHA256 == null )
                    {
                        _SHA256 = SHA256.Create() ;
                    }
                    return _SHA256 ;
                case HashType.SHA512:
                    if ( _SHA512 == null )
                    {
                        _SHA512 = SHA512.Create() ;
                    }
                    return _SHA512 ;
            }

            if ( _SHA1 == null )
            {
                _SHA1 = new SHA1CryptoServiceProvider() ;
            }
            return _SHA1 ;
        }

        internal static byte[] GetHash( byte[] data, HashAlgorithm algorithm )
        {
            byte[] hash = algorithm.ComputeHash( data ) ;
            return hash ;
        }

        internal static byte[] ToMD5( byte[] data )
        {
            return GetHash( data, GetHashAlgorithm( HashType.MD5 ) ) ;
        }

        internal static byte[] ToSHA1( byte[] data )
        {
            return GetHash( data, GetHashAlgorithm( HashType.SHA1 ) ) ;
        }

        internal static byte[] ToSHA256(byte[] data )
        {
            return GetHash( data, GetHashAlgorithm( HashType.SHA256 ) ) ;
        }

        internal static byte[] ToSHA512(byte[] data )
        {
            return GetHash( data, GetHashAlgorithm( HashType.SHA512 ) ) ;
        }
    }
}