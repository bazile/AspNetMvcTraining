using System;
using System.Security.Cryptography;
using System.Text;

namespace WebApplicationQuizz.Controllers
{
    internal static class HashHelper
    {
        //internal static string CalculatePasswordHash(string password, string salt)
        //{
        //    if (string.IsNullOrEmpty(password)) return "";

        //    using (var hashAlg = SHA1.Create())
        //    {
        //        byte[] hash = hashAlg.ComputeHash(Encoding.UTF8.GetBytes(salt + "#" + password));
        //        return Convert.ToBase64String(hash);
        //    }
        //}

        internal static string CalculatePasswordHash(string password, byte[] salt)
        {
            using (var rfc2898 = new Rfc2898DeriveBytes(password, salt, 10_000))
            {
                byte[] hash = rfc2898.GetBytes(32);
                return Convert.ToBase64String(hash);
            }
        }
    }
}