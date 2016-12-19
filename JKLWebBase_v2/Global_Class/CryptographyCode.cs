﻿using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;


namespace JKLWebBase_v2.Global_Class
{
    public class CryptographyCode
    {
        public static string GenerateSHA256String(string inputString)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha256.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        public static string GenerateSHA512String(string inputString)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha512.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }

        public static string EncodeTOAddressBar(string inputcode, string value)
        {
            string f_code = inputcode.Substring(0, 64);
            string l_code = inputcode.Substring(64);
            string code = f_code + "U" + value + "U" + l_code;
            return code;
        }
    }
}