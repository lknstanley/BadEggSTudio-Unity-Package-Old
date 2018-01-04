
using System;
using System.IO;
using System.IO.Compression;

namespace BadEggStudio.Utils.Serialize
{
    public static class Compressor
    {
        public static byte[] Compress( byte[] binary )
        {
            return _Process( binary, CompressionMode.Compress ) ;
        }

        public static byte[] Decompress( byte[] compressed )
        {
            return _Process( compressed, CompressionMode.Decompress ) ;
        }

        private static byte[] _Process( byte[] data, CompressionMode mode )
        {
            byte[] processed = null ;

            MemoryStream ms = new MemoryStream() ;
            GZipStream gzip = new GZipStream( ms, mode ) ;
            
            gzip.Write( data, 0, data.Length ) ;
            gzip.Close() ;

            processed = new byte[ ms.Length ] ;
            Buffer.BlockCopy( ms.GetBuffer(), 0, processed, 0, processed
            .Length ) ;

            ms.Close() ;

            return processed ;
        }
    }
}