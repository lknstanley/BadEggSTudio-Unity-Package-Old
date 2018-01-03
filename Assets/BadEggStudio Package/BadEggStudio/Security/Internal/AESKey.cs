using System.Text;

namespace BadEggStudio.Security.Internal
{
    public class AESKey
    {
        private const string KEY0  = "wAnI8XSG7w7fB4mv" ;
        private const string IV0   = "W4I5r43CsQWsQe9E" ;

        private const string KEY1  = "3DPcfky9U9n4amIU" ;
        private const string IV1   = "tg4NEXpsCA0T1Xtt" ;

        private const int COUNT = 2 ;
        
        private static byte[][] bKEY = null ;
        private static byte[][] bIV = null ;

        private static void _lazyInit()
        {
            if ( bKEY != null )
            {
                return ;
            }

            bKEY = new byte[COUNT][] ;
            bIV = new byte[COUNT][] ;
        }
        
        internal static void GetKey( int index, out byte[] key, out byte[] iv )
        {
            _correctIndex( ref index ) ;

            _lazyInit() ;
            _loadKey( ref index ) ;

            key = bKEY[index] ;
            iv = bIV[index] ;
        }

        private static void _loadKey( ref int index )
        {
            if ( bKEY[index] != null )
            {
                return ;
            }

            switch( index )
            {
                case 0:
                    bKEY[index] = Encoding.ASCII.GetBytes( KEY0 ) ;
                    bIV[index] = Encoding.ASCII.GetBytes( IV0 ) ;
                    break ;
                case 1:
                    bKEY[index] = Encoding.ASCII.GetBytes( KEY1 ) ;
                    bIV[index] = Encoding.ASCII.GetBytes( IV1 ) ;
                    break ;
            }
        }

        private static void _correctIndex( ref int index )
        {
            if ( index >= COUNT )
            {
                index = 0 ;
            }
        }
    }
}
