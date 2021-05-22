using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GScriptApi.Helpers
{
    public class CypherService
    {
        public static String GetSalt()
        {
            Random random = new Random();
            String salt = "";
            for (int i = 1; i <= 50; i++)
            {
                int rd = random.Next(0, 255);
                char letter = Convert.ToChar(rd);
                salt += letter;
            }

            return salt;
        }

        public static byte[] Cypher(String content, ref String salt)
        {
            salt = CypherService.GetSalt();
            String fullContent = content + salt;

            SHA256Managed sha = new SHA256Managed();
            byte[] result = Encoding.UTF8.GetBytes(fullContent);
            for (int i = 1; i <= 100; i++)
            {
                result = sha.ComputeHash(result);
            }
            sha.Clear();

            return result;
        }

        public static byte[] Cypher(String content, String salt)
        {
            String fullContent = content + salt;

            SHA256Managed sha = new SHA256Managed();
            byte[] result = Encoding.UTF8.GetBytes(fullContent);
            for (int i = 1; i <= 100; i++)
            {
                result = sha.ComputeHash(result);
            }
            sha.Clear();

            return result;
        }
    }
}
