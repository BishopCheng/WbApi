using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ValidateServer
{

    /// <summary>
    /// DES加解密操作类
    /// </summary>
     public class DESEncrypt
    {
        public static string Encrypt(string encryptValue, string encryptKey)
        {
            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(encryptKey);
            byte[] bytes2 = Encoding.UTF8.GetBytes(encryptValue);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, new byte[8]), CryptoStreamMode.Write);
            cryptoStream.Write(bytes2, 0, bytes2.Length);
            cryptoStream.FlushFinalBlock();
            return Convert.ToBase64String(memoryStream.ToArray());
        }

        public static string Decrypt(string decryptValue, string decryptKey)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(decryptKey);
            byte[] array = Convert.FromBase64String(decryptValue);
            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(bytes, new byte[8]), CryptoStreamMode.Write);
            cryptoStream.Write(array, 0, array.Length);
            cryptoStream.FlushFinalBlock();
            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }

        public static bool Validate(string encryptValue, string sKey, string decryptValue)
        {
            return Decrypt(decryptValue, sKey).Equals(encryptValue);
        }
    }
}
