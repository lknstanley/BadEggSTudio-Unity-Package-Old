using System ;
using System.Text;
using BadEggStudio.Security.Internal;

namespace BadEggStudio.Security
{
	public class Encryption
	{
        public const int NONCE_LENGTH = 16;

        public static byte[] GetBinaryHash( byte[] data, HashType hashType = HashType.SHA256 )
        {
            if ( data == null )
            {
                return null;
            }

            if ( data.Length == 0 )
            {
                return data ;
            }

            return Hash.GetHash(data, Hash.GetHashAlgorithm(hashType));
        }

		public static string GetHash( byte[] data, HashType hashType = HashType.SHA256 )
		{
            if (data == null)
            {
                return null;
            }

            if ( data.Length == 0 )
            {
                return string.Empty ;
            }

            byte[] hash = GetBinaryHash( data, hashType ) ;
            return Utility.ToBase64String( hash ) ;
		}

		public static string GetHash( string data, HashType hashType = HashType.SHA256 )
		{
            if (data == null)
            {
                return null;
            }

            if ( string.IsNullOrEmpty( data ) )
            {
                return string.Empty ;
            }

            byte[] binary = Encoding.UTF8.GetBytes( data ) ;
            return GetHash( binary, hashType ) ;
        }

        public static byte[] BinaryEncrypt( byte[] data, int you_know_what_is_this_key = 0 )
        {
            if (data == null)
            {
                return null;
            }

            if ( data.Length == 0 )
            {
                return data ;
            }

            int keyIndex = you_know_what_is_this_key;

            byte[] encrypted;

            AESCryptor.Encrypt(ref keyIndex, ref data, out encrypted);

            return encrypted;
        }

        public static byte[] BinaryDecrypt( byte[] encrypted, int you_know_what_is_this_key = 0)
        {
            if (encrypted == null)
            {
                return null;
            }

            if ( encrypted.Length == 0 )
            {
                return encrypted ;
            }

            int keyIndex = you_know_what_is_this_key;

            byte[] data;

            AESCryptor.Decrypt(ref keyIndex, ref encrypted, out data);

            return data;
        }

        public static string EncryptToString( byte[] data, int key = 0 )
        {
            if ( data == null )
            {
                return null ;
            }

            if ( data.Length == 0 )
            {
                return string.Empty ;
            }

            int keyIndex = key ;
            string nonce = Utility.GenerateNonce(NONCE_LENGTH);
            byte[] binaryNonce = Encoding.UTF8.GetBytes( nonce ) ;

            byte[] dataToEncrypt = Utility.MergeBytes( data, binaryNonce ) ;
            byte[] encrypted;

            AESCryptor.Encrypt(ref keyIndex, ref dataToEncrypt, out encrypted);

            string beEncrypted = Utility.ToBase64String(encrypted);
            beEncrypted = keyIndex + Utility.SEP + beEncrypted + Utility.SEP + nonce;

            return beEncrypted;
        }

        public static byte[] DecryptToBytes( string encryptedData )
        {
            if (encryptedData == null)
            {
                return null ;
            }

            if ( string.IsNullOrEmpty( encryptedData ) )
            {
                return new byte[0] ;
            }

            string[] values = encryptedData.Split(Utility.SEPARRAY, StringSplitOptions.None);

            if ( values.Length != 3 )
            {
                return null ;
            }

            int keyIndex;
            string beEncrypted = values[1];
            string nonce = values[2];

            if ( ! int.TryParse( values[0], out keyIndex ) )
            {
                return null ;
            }

            byte[] encrypted = Utility.FromBase64String(beEncrypted);
            byte[] binary;

            AESCryptor.Decrypt(ref keyIndex, ref encrypted, out binary);

            if ( binary == null )
            {
                return null ;
            }

            byte[] binaryNonce = Encoding.UTF8.GetBytes( nonce ) ;
            byte[] data ;
            byte[] checkNonceBinary ;

            Utility.SeparateBytes( binary, binaryNonce.Length, out data, out checkNonceBinary ) ;

            if ( ! Utility.IsBytesSame( binaryNonce, checkNonceBinary ) )
            {
                return null ;
            }

            return data ;
        }

        public static string Encrypt( string data, int key = 0)
        {
            if ( data == null )
            {
                return null ;
            }

            if ( string.IsNullOrEmpty( data ) )
            {
                return "" ;
            }

            int keyIndex = key;
            string nonce = Utility.GenerateNonce(NONCE_LENGTH);

            string toEncrypt = data + nonce;

            byte[] binary = Encoding.UTF8.GetBytes(toEncrypt);
            byte[] encrypted;

            AESCryptor.Encrypt(ref keyIndex, ref binary, out encrypted);

            string beEncrypted = Utility.ToBase64String(encrypted);
            beEncrypted = keyIndex + Utility.SEP + beEncrypted + Utility.SEP + nonce;

            return beEncrypted;
        }

        public static string Decrypt( string encryptedData )
        {
            if (encryptedData == null)
            {
                return null;
            }

            if ( string.IsNullOrEmpty( encryptedData ) )
            {
                return string.Empty ;
            }

            string[] values = encryptedData.Split(Utility.SEPARRAY, StringSplitOptions.None);

            if ( values.Length != 3 )
            {
                return encryptedData;
            }

            int keyIndex;
            string beEncrypted = values[1];
            string nonce = values[2];

            if ( ! int.TryParse( values[0], out keyIndex ) )
            {
                return encryptedData;
            }

            byte[] encrypted = Utility.FromBase64String(beEncrypted);
            byte[] binary;

            AESCryptor.Decrypt(ref keyIndex, ref encrypted, out binary);

            if ( binary == null )
            {
                return encryptedData ;
            }

            string data = Encoding.UTF8.GetString(binary);
            string checkNonce = data.Substring(data.Length - NONCE_LENGTH);

            if ( checkNonce != nonce )
            {
                return encryptedData;
            }

            return data.Substring(0, data.Length - NONCE_LENGTH);
        }
    }
}