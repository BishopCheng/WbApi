using System;
using System.Collections.Generic;
using System.Text;

namespace ValidateServer
{
    /// <summary>
    /// 随机加解密操作类
    /// </summary>
     public class RandomEncrypt
    {
        private static string[] strs = new string[67]
       {
        "a",
        "b",
        "c",
        "d",
        "e",
        "f",
        "g",
        "h",
        "i",
        "g",
        "k",
        "l",
        "m",
        "n",
        "o",
        "p",
        "q",
        "r",
        "s",
        "t",
        "u",
        "v",
        "w",
        "x",
        "y",
        "z",
        "A",
        "B",
        "C",
        "D",
        "E",
        "F",
        "G",
        "H",
        "I",
        "G",
        "K",
        "L",
        "M",
        "N",
        "O",
        "P",
        "Q",
        "R",
        "S",
        "T",
        "U",
        "V",
        "W",
        "X",
        "Y",
        "Z",
        "1",
        "2",
        "3",
        "4",
        "5",
        "6",
        "7",
        "8",
        "9",
        "0",
        "+",
        "-",
        "/",
        "=",
        "#"
     };

        private static string getKey()
        {
            int maxValue = strs.Length;
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < 8; i++)
            {
                stringBuilder.Append(strs[random.Next(maxValue)]);
            }
            return stringBuilder.ToString();
        }

        public static string Encrypt(string toEncryptValue)
        {
            string key = getKey();
            return encode(key + DESEncrypt.Encrypt(toEncryptValue, key));
        }

        public static string Decrypt(string toDecryptValue)
        {
            toDecryptValue = decode(toDecryptValue);
            string decryptKey = toDecryptValue.Substring(0, 8);
            toDecryptValue = toDecryptValue.Substring(8);
            return DESEncrypt.Decrypt(toDecryptValue, decryptKey);
        }

        private static string encode(string value)
        {
            return value.Replace("+", "%a").Replace("-", "%b").Replace("/", "%c")
                .Replace("=", "%d")
                .Replace("#", "%e");
        }

        private static string decode(string value)
        {
            return value.Replace("%a", "+").Replace("%b", "-").Replace("%c", "/")
                .Replace("%d", "=")
                .Replace("%e", "#");
        }
    }
}
