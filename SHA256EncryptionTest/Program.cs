using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SHA256EncryptionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter some passwsord");
            string pass = Console.ReadLine();
            
            string encrypted = HashText(pass, "safeSalt", new SHA256Managed());
            Console.WriteLine("Hash is: {0}", encrypted);
            Console.WriteLine("Enter some passwsord");
            string pass2 = Console.ReadLine();

            string encrypted2 = HashText(pass, "safeSalt",new SHA256Managed());
            Console.WriteLine("Hash is: {0}", encrypted2);
            Console.ReadKey();
        }

        public static string HashText(string text, string salt, SHA256Managed hasher)
        {
            byte[] textWithSaltBytes = Encoding.UTF8.GetBytes(string.Concat(text, salt));
            byte[] hashedBytes = hasher.ComputeHash(textWithSaltBytes);
            hasher.Clear();
            return Convert.ToBase64String(hashedBytes);
        }

    }
}

