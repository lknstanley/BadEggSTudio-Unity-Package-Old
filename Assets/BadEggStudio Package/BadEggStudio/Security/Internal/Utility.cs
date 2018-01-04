using System;
using BadEggStudio.Utils;

namespace BadEggStudio.Security.Internal
{
    public class Utility
    {
        private const string NONCE_DICTIONARY = "qwertyuiopasdfghjklzxcvbnm1234567890QWERTYUIOPASDFGHJKLZXCVBNM" ;
        private static Random _random;

        internal const string SEP = "!!!";
        private static string[] _SEPARRAY = null;

        internal static string[] SEPARRAY
        {
            get
            {
                if (_SEPARRAY == null)
                {
                    _SEPARRAY = new string[] { SEP };
                }
                return _SEPARRAY;
            }
        }

        internal static string GenerateNonce( int length )
        {
            char[] nonce_char = new char[length];
            for ( int i = 0; i < length; i++ )
            {
                nonce_char[i] = NONCE_DICTIONARY[GetRandom(0, NONCE_DICTIONARY.Length)];
            }

            return new string(nonce_char);
        }

        internal static int GetRandom( int min, int max )
        {
            if (_random == null )
            {
                _random = new Random();
            }

            return _random.Next( min, max ) ;
        }

        internal static byte[] MergeBytes( byte[] a, byte[] b )
        {
            byte[] newBytes = new byte[ a.Length + b.Length ] ;
            Buffer.BlockCopy( a, 0, newBytes, 0, a.Length ) ;
            Buffer.BlockCopy( b, 0, newBytes, a.Length, b.Length ) ;
            return newBytes ;
        }

        internal static void SeparateBytes( byte[] from, int lastIndex, out byte[] a, out byte[] b )
        {
            a = null ;
            b = null ;

            if ( lastIndex < 0 || lastIndex > from.Length )
            {
                return ;
            }

            if ( lastIndex == 0 || lastIndex == from.Length )
            {
                a = from ;
                return ;
            }

            int aLength = from.Length - lastIndex ;

            a = new byte[ aLength ] ;
            b = new byte[ lastIndex ] ;
            Buffer.BlockCopy( from, 0, a, 0, aLength ) ;
            Buffer.BlockCopy( from, aLength, b, 0, lastIndex ) ;
        }

        internal static bool IsBytesSame( byte[] a, byte[] b )
        {
            if ( a.Length != b.Length )
            {
                return false ;
            }

            for( int i = 0 ; i < a.Length ; ++ i )
            {
                if ( a[i] != b[i] )
                {
                    return false ;
                }
            }

            return true ;
        }
    }
}
