using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AuthDemo
{
    public static class UserHelper
    {
        public static string GetPasswordHash(string password, byte[] salt)
        {
            using (var hashAlg = SHA1.Create())
            {
                byte[] input = Encoding.UTF8.GetBytes(password);
                input = input.Concat(salt).ToArray();

                byte[] hash = hashAlg.ComputeHash(input);
                return ToHexString(hash);
            }
        }

        public static byte[] GenerateSalt()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[8];
                rng.GetBytes(salt);
                return salt;
            }
        }

        public static string ToHexString(byte[] hash)
        {
            var sb = new StringBuilder(hash.Length * 2);
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static byte[] FromHexString(string hex)
        {
            byte[] array = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i+=2)
            {
                array[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return array;
        }
    }
}