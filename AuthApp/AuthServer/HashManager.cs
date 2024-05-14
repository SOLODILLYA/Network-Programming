using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AuthServer
{
    internal class HashManager
    {
        public static string GetHash(string passw)
        {
            string result = string.Empty;
            MD5 mD5 = MD5.Create();

            byte[] data = Encoding.UTF8.GetBytes(passw);
            byte[] hash = mD5.ComputeHash(data);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("x2"));
            }

            result = sb.ToString();
            return result;
        }
    }
}
