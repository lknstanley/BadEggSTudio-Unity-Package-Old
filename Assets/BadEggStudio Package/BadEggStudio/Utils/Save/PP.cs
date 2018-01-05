using UnityEngine ;
using System ;
using BadEggStudio.Security ;
using BadEggStudio.Utils ;
using BadEggStudio.Utils.Serialize ;
using System.Collections.Generic;

namespace BadEggStudio.Utils.Save
{
    public enum PPMode
    {
        Unknown,

        Raw,
        Serialized,
        Compressed,
        Encrypted,
        CompressedAndEncrypted,
    }

    public static class PP
    {
        private const string SEP = "!!!" ;
        private static Dictionary<int, string> MODE_KEY_CACHE = new Dictionary<int, string>() ;

        public static int GetInt( string key, int defaultValue = 0 )
        {
            if ( ! HasKey( key ) )
            {
                return defaultValue ;
            }

            return PlayerPrefs.GetInt( key ) ;
        }

        public static float GetFloat( string key, float defaultValue = 0 )
        {
            if ( ! HasKey( key ) )
            {
                return defaultValue ;
            }

            return PlayerPrefs.GetFloat( key ) ;
        }

        public static string GetString( string key, string defaultValue = null, PPMode mode = PPMode.Unknown )
        {
            if ( ! HasKey( key ) )
            {
                return defaultValue ;
            }

            string valueFromPP = PlayerPrefs.GetString( key ) ;

            if ( mode == PPMode.Raw )
            {
                return valueFromPP ;
            }

            string[] resultArray = valueFromPP.Split( new String[] { SEP }, StringSplitOptions.None ) ;

            if ( mode == PPMode.Unknown )
            {
                mode = _FindMode( resultArray[0] ) ;

                if ( mode == PPMode.Unknown )
                {
                    return valueFromPP ;
                }
            }

            object obj = _Deserialize( resultArray[1], mode ) ;

            if ( obj is string )
            {
                return (string) obj ;
            }

            return defaultValue ;
        }

        public static object GetObject( string key, PPMode mode = PPMode.Unknown )
        {
            if ( mode == PPMode.Raw )
            {
                return null ;
            }

            if ( ! HasKey( key ) )
            {
                return null ;
            }

            string valueFromPP = PlayerPrefs.GetString( key ) ;

            string[] resultArray = valueFromPP.Split( new String[] { SEP }, StringSplitOptions.None ) ;

            if ( mode == PPMode.Unknown )
            {
                mode = _FindMode( resultArray[0] ) ;

                if ( mode == PPMode.Unknown )
                {
                    return null ;
                }
            }

            object obj = _Deserialize( resultArray[1], mode ) ;

            return obj ;
        }

        

        public static void SetInt( string key, int value )
        {
            PlayerPrefs.SetInt( key, value ) ;
        }

        public static void SetFloat( string key, float value )
        {
            PlayerPrefs.SetFloat( key, value ) ;
        }

        public static void SetString( string key, string value, PPMode mode = PPMode.Raw )
        {
            if ( mode == PPMode.Raw || mode == PPMode.Unknown )
            {
                PlayerPrefs.SetString( key, value ) ;
                return ;
            }

            SetObject( key, value, mode ) ;
        }

        public static void SetObject( string key, object value, PPMode mode = PPMode.Raw )
        {
            if ( mode == PPMode.Raw || mode == PPMode.Unknown )
            {
                throw new Exception( "Cannot save object with raw mode." ) ;
            }

            string base64Value = _Serialize( value, mode ) ;

            base64Value = _GetModeKey( mode ) + SEP + base64Value ;

            PlayerPrefs.SetString( key, base64Value ) ;
        }

        public static bool HasKey( string key )
        {
            return PlayerPrefs.HasKey( key ) ;            
        }

        public static bool Remove( string key )
        {
            bool hasKey = HasKey( key ) ;

            PlayerPrefs.DeleteKey( key ) ;

            return hasKey ;
        }

        public static void RemoveAll()
        {
            PlayerPrefs.DeleteAll() ;
        }

        private static string _GetModeKey( PPMode mode )
        {
            int index = (int) mode ;

            if ( MODE_KEY_CACHE.ContainsKey( index ) )
            {
                return MODE_KEY_CACHE[index] ;
            }

            string key = index + mode.ToString() + index ;

            MODE_KEY_CACHE.Add( index, key ) ;

            return key ;
        }

        private static PPMode _FindMode( string key )
        {
            if ( key.Length < 5 )
            {
                return PPMode.Unknown ;
            }

            key = key.Substring( 1, key.Length - 2 ) ;

            try
            {
                PPMode mode = (PPMode) Enum.Parse( typeof( PPMode ), key ) ;
                return mode ;
            }
            catch( Exception )
            {

            }

            return PPMode.Unknown ;
        }

        private static string _Serialize( object obj, PPMode mode )
        {
            byte[] binary = BinarySerializer.Serialize( obj ) ;

            if ( mode == PPMode.Encrypted || mode == PPMode.CompressedAndEncrypted )
            {
                binary = Encryption.BinaryEncrypt( binary ) ;
            }

            if ( mode == PPMode.Compressed || mode == PPMode.CompressedAndEncrypted )
            {
                binary = Compressor.Compress( binary ) ;
            }

            string base64Value = StringTools.ToBase64String( binary ) ;

            return base64Value ;
        }

        private static object _Deserialize( string value, PPMode mode )
        {
            byte[] binary = StringTools.FromBase64String( value ) ;
            
            if ( mode == PPMode.Compressed || mode == PPMode.CompressedAndEncrypted )
            {
                binary = Compressor.Decompress( binary ) ;
            }

            if ( mode == PPMode.Encrypted || mode == PPMode.CompressedAndEncrypted )
            {
                binary = Encryption.BinaryDecrypt( binary ) ;
            }

            object obj = BinarySerializer.Deserialize( binary ) ;

            return obj ;
        }

        public static void Save() {
            PlayerPrefs.Save();
        }
    }
}