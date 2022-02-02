using System;
using System.IO;
using System.Text;

namespace TaikoEncryptionTool
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("No file detected, make sure to drag the file on the exe!");
                Console.WriteLine("Press Any Key to close");
                Console.ReadKey();
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

            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.D1)
            {
                try
                {
                    //Decrypt Sound
                    byte[] DecryptedBytes = EncryptTool.ReadAES(FilePath, EncryptTool.AesKeyType.Type0);
                    FileStream file = File.Create(FilePath);
                    file.Write(DecryptedBytes);
                    file.Close();
                    Console.WriteLine("Finished Decrypting");
                    Console.WriteLine("Press Any Key to close");
                    Console.ReadKey();
                }
                catch (Exception exc)
                {
                    Console.WriteLine("Exception occurred: " + exc);
                    Console.WriteLine("Press Any Key to close");
                    Console.ReadKey();
                }
            }
            else if (key.Key == ConsoleKey.D2)
            {
                try
                {
                    //Decrypt Fumen
                    byte[] DecryptedBytes = EncryptTool.UnzipBytes(FilePath, EncryptTool.AesKeyType.Type2);
                    FileStream file = File.Create(FilePath);
                    file.Write(DecryptedBytes);
                    file.Close();
                    Console.WriteLine("Finished Decrypting");
                    Console.WriteLine("Press Any Key to close");
                    Console.ReadKey();
                }
                catch (Exception exc)
                {
                    Console.WriteLine("Exception occurred: " + exc);
                    Console.WriteLine("Press Any Key to close");
                    Console.ReadKey();
                }
            }
            else if (key.Key == ConsoleKey.D3)
            {
                try
                {
                    //Decrypt ReadAssets
                    string DecryptedBytes = EncryptTool.UnzipText(FilePath, Encoding.UTF8, EncryptTool.AesKeyType.Type1);
                    FileStream file = File.Create(FilePath);
                    file.Write(Encoding.UTF8.GetBytes(DecryptedBytes));
                    file.Close();
                    Console.WriteLine("Finished Decrypting");
                    Console.WriteLine("Press Any Key to close");
                    Console.ReadKey();
                }
                catch (Exception exc)
                {
                    Console.WriteLine("Exception occurred: " + exc);
                    Console.WriteLine("Press Any Key to close");
                    Console.ReadKey();
                }
            }
            else if (key.Key == ConsoleKey.D4)
            {
                try
                {
                    //Encrypt Sound
                    byte[] DecryptedBytes = EncryptTool.CreateAES(FilePath, EncryptTool.AesKeyType.Type0);
                    FileStream file = File.Create(FilePath);
                    file.Write(DecryptedBytes);
                    file.Close();
                    Console.WriteLine("Finished Encrypting");
                    Console.WriteLine("Press Any Key to close");
                    Console.ReadKey();
                }
                catch (Exception exc)
                {
                    Console.WriteLine("Exception occurred: " + exc);
                    Console.WriteLine("Press Any Key to close");
                    Console.ReadKey();
                }
            }
            else if (key.Key == ConsoleKey.D5)
            {
                try
                {
                    //Encrypt Fumen
                    byte[] DecryptedBytes = EncryptTool.ZipText(FilePath, EncryptTool.AesKeyType.Type2);
                    FileStream file = File.Create(FilePath);
                    file.Write(DecryptedBytes);
                    file.Close();
                    Console.WriteLine("Finished Encrypting");
                    Console.WriteLine("Press Any Key to close");
                    Console.ReadKey();
                }
                catch (Exception exc)
                {
                    Console.WriteLine("Exception occurred: " + exc);
                    Console.WriteLine("Press Any Key to close");
                    Console.ReadKey();
                }
            }
            else if (key.Key == ConsoleKey.D6)
            {
                try
                {
                    //Encrypt ReadAssets
                    byte[] DecryptedBytes = EncryptTool.ZipText(FilePath, EncryptTool.AesKeyType.Type1);
                    FileStream file = File.Create(FilePath);
                    file.Write(DecryptedBytes);
                    file.Close();
                    Console.WriteLine("Finished Encrypting");
                    Console.WriteLine("Press Any Key to close");
                    Console.ReadKey();
                }
                catch (Exception exc)
                {
                    Console.WriteLine("Exception occurred: " + exc);
                    Console.WriteLine("Press Any Key to close");
                    Console.ReadKey();
                }
            }
        }
	}
}
