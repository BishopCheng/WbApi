using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace ValidateServer
{
    /// <summary>
    /// MD5加解密操作类
    /// </summary>
     public class MD5Encrypt
    {
        public static string Encrypt(string value)
        {
            return runRadom(GetString(value));
        }

        public static bool Validate(string validateValue, string encryptValue)
        {
            return Encrypt(validateValue).Equals(encryptValue);
        }

        public static string GetString(string value)
        {
            string text = "";
            MD5 mD = MD5.Create();
            byte[] array = mD.ComputeHash(Encoding.UTF8.GetBytes(value));
            for (int i = 0; i < array.Length; i++)
            {
                text += array[i].ToString("X");
            }
            return runRadom(text);
        }

        public static string GetFile(string fileName)
        {
            try
            {
                FileStream fileStream = new FileStream(fileName, FileMode.Open);
                MD5 mD = new MD5CryptoServiceProvider();
                byte[] array = mD.ComputeHash(fileStream);
                fileStream.Close();
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < array.Length; i++)
                {
                    stringBuilder.Append(array[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetBytes(byte[] bytes)
        {
            string text = "";
            MD5 mD = MD5.Create();
            byte[] array = mD.ComputeHash(bytes);
            for (int i = 0; i < array.Length; i++)
            {
                text += array[i].ToString("x2");
            }
            return text;
        }

        private static string runRadom(string value)
        {
            string str = value.Substring(0, 10);
            string str2 = value.Substring(10);
            return str2 + str;
        }
    }
}
