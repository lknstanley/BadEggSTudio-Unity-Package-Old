using System ;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BadEggStudio.Utils.Serialize
{
    public static class BinarySerializer
    {
        private static BinaryFormatter _binaryFormatter = null ;

        private static void _LazyLoading()
        {
            _binaryFormatter = new BinaryFormatter() ;
        }

        public static byte[] Serialize( object obj )
        {
            _LazyLoading() ;

            byte[] result = null ;
            MemoryStream memoryStream = new MemoryStream() ;

            _binaryFormatter.Serialize( memoryStream, obj ) ;
            result = new byte[memoryStream.Length] ;

            Buffer.BlockCopy( memoryStream.GetBuffer(), 0, result, 0, result.Length ) ;

            memoryStream.Close() ;

            return result ;
        }

        public static object Deserialize( byte[] binary )
        {
            _LazyLoading() ;

            object obj = null ;
            MemoryStream memoryStream = new MemoryStream( binary ) ;

            obj = _binaryFormatter.Deserialize( memoryStream ) ;

            memoryStream.Close() ;

            return obj ;
        }
    }
}