using System ;
using System.Text ;

namespace BadEggStudio.Utils
{
    public static class StringTools
    {
        public static byte[] FromBase64String( string data )
        {
            byte[] result = null ;

            try
            {
                result = Convert.FromBase64String( data ) ;
            }
            catch( Exception )
            {

            }

            return result ;
        }

        public static string ToBase64String( byte[] data )
        {
            return Convert.ToBase64String( data ) ;
        }

        public static byte[] ToByteArray( string data )
        {
            return Encoding.UTF8.GetBytes( data ) ;
        }

        public static string FromByteArray( byte[] data )
        {
            return Encoding.UTF8.GetString( data ) ;
        }
    }
}