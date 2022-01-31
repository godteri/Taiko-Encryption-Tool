using System;
using System.IO;
using System.Security.Cryptography;
using System.IO.Compression;
using System.Text;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Environment.Exit(0);
            }

            string FilePath = args[0];

            Console.WriteLine("Taiko Encryption Tool");
            Console.WriteLine("Choose Option");
            Console.WriteLine("1. Decrypt Sound");
            Console.WriteLine("2. Decrypt Fumen");
            Console.WriteLine("3. Decrypt ReadAssets");
            Console.WriteLine("4. Encrypt Sound");
            Console.WriteLine("5. Encrypt Fumen");
            Console.WriteLine("6. Encrypt ReadAssets");

            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.D1)
            {
                //Decrypt Sound
                byte[] DecryptedBytes = Cryptgraphy.ReadAllAesBytes(FilePath, Cryptgraphy.AesKeyType.Type0);
                FileStream file = File.Create(FilePath);
                file.Write(DecryptedBytes);
                file.Close();
            }
            else if (key.Key == ConsoleKey.D2)
            {
                //Decrypt Fumen
                byte[] DecryptedBytes = Cryptgraphy.ReadAllAesAndGZipBytes(FilePath, Cryptgraphy.AesKeyType.Type2);
                FileStream file = File.Create(FilePath);
                file.Write(DecryptedBytes);
                file.Close();
            }
            else if (key.Key == ConsoleKey.D3)
            {
                //Decrypt ReadAssets
                string DecryptedBytes = Cryptgraphy.ReadZipText(FilePath, Encoding.UTF8, Cryptgraphy.AesKeyType.Type1);
                FileStream file = File.Create(FilePath);
                file.Write(Encoding.UTF8.GetBytes(DecryptedBytes));
                file.Close();
            }
            else if (key.Key == ConsoleKey.D4)
            {
                //Encrypt Sound
                byte[] DecryptedBytes = Cryptgraphy.CreateAllAesBytes(FilePath, Cryptgraphy.AesKeyType.Type0);
                FileStream file = File.Create(FilePath);
                file.Write(DecryptedBytes);
                file.Close();
            }
            else if (key.Key == ConsoleKey.D5)
            {
                //Encrypt Fumen
                byte[] DecryptedBytes = Cryptgraphy.CreateZipText(FilePath, Cryptgraphy.AesKeyType.Type2);
                FileStream file = File.Create(FilePath);
                file.Write(DecryptedBytes);
                file.Close();
            }
            else if (key.Key == ConsoleKey.D6)
            {
                //Encrypt ReadAssets
                byte[] DecryptedBytes = Cryptgraphy.CreateZipText(FilePath, Cryptgraphy.AesKeyType.Type1);
                FileStream file = File.Create(FilePath);
                file.Write(DecryptedBytes);
                file.Close();
            }
        }
	}
}
