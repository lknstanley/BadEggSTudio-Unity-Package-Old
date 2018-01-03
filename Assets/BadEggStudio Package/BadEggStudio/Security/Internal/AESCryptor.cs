using System;
using System.Security.Cryptography;

namespace BadEggStudio.Security.Internal
{
    class AESCryptor
    {
        internal static void Encrypt( ref int keyIndex, ref byte[] data, out byte[] encrypted )
        {
            if ( data == null )
            {
                encrypted = null ;
                return ;
            }

            byte[] key;
            byte[] iv;
            
            AESKey.GetKey(keyIndex, out key, out iv);

            Aes _aes = Aes.Create();
            _aes.Key = key;
            _aes.IV = iv;

            ICryptoTransform encryptor = _aes.CreateEncryptor(_aes.Key, _aes.IV);

            encrypted = encryptor.TransformFinalBlock(data, 0, data.Length);
        }

        internal static void Decrypt( ref int keyIndex, ref byte[] encrypted, out byte[] data )
        {
            if ( encrypted == null )
            {
                data = null ;
                return ;
            }

            byte[] key;
            byte[] iv;

            AESKey.GetKey(keyIndex, out key, out iv);

            Aes _aes = Aes.Create();
            _aes.Key = key;
            _aes.IV = iv;

            ICryptoTransform decryptor = _aes.CreateDecryptor(_aes.Key, _aes.IV);

            data = decryptor.TransformFinalBlock(encrypted, 0, encrypted.Length);
        }
    }
}
