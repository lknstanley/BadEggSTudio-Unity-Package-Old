
using System;
using System.IO;
using System.IO.Compression;

using UnityEngine ;

namespace BadEggStudio.Utils.Serialize
{
    public static class Compressor
    {
        public static byte[] Compress( byte[] binary )
        {
            // byte[] processed = null ;

            // MemoryStream ms = new MemoryStream() ;
            // GZipStream gzip = new GZipStream( ms, CompressionMode.Compress ) ;
            
            // gzip.Write( binary, 0, binary.Length ) ;
            // gzip.Flush() ;

            // processed = new byte[ ms.Length ] ;
            // Buffer.BlockCopy( ms.GetBuffer(), 0, processed, 0, processed.Length ) ;

            // gzip.Close() ;
            // ms.Close() ;

            // return processed ;

            return binary ;
        }

        public static byte[] Decompress( byte[] compressed )
        {
            // byte[] buffer = new byte[ 4096 ] ;
            // MemoryStream inStream = new MemoryStream( compressed ) ;
            // MemoryStream outStream = new MemoryStream() ;
            // GZipStream gzip = new GZipStream( inStream, CompressionMode.Decompress ) ;

            // outStream.Flush() ;

            // buffer = new byte[ outStream.Length ] ;
            // Buffer.BlockCopy( outStream.GetBuffer(), 0, buffer, 0, buffer.Length ) ;

            // return buffer ;

            return compressed ;
        }
    }
}