using System;
using System.Security.Cryptography;

namespace TNDDMLogin
{
    public static class TokenGenerator
    {
        public static string GetNewToken()
        {
            byte[] bytes = new byte[40];

            using (var crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(bytes);
            }

            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }
}
