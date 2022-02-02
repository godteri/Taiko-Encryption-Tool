using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace TaikoEncryptionTool
{
	public class EncryptTool
	{
		public static string UnzipText(string path, Encoding encoding, EncryptTool.AesKeyType type)
		{
			MemoryStream stream = new MemoryStream(EncryptTool.ReadAES(path, type));
			MemoryStream memoryStream = new MemoryStream();
			using (GZipStream gzipStream = new GZipStream(stream, CompressionMode.Decompress))
			{
				gzipStream.CopyTo(memoryStream);
			}
			return encoding.GetString(memoryStream.ToArray());
		}
		public static byte[] ZipText(string path, EncryptTool.AesKeyType type)
		{
			MemoryStream stream = new MemoryStream(File.ReadAllBytes(path));
			MemoryStream memoryStream = new MemoryStream();
			using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
			{
				stream.CopyTo(gzipStream);
			}
			FileStream tmp = File.Create(Path.GetTempPath() + "taiko.tmp");
			tmp.Write(memoryStream.ToArray());
			tmp.Close();
			MemoryStream memoryStream2 = new MemoryStream(EncryptTool.CreateAES(Path.GetTempPath() + "taiko.tmp", type));
			return memoryStream2.ToArray();
		}
		public static byte[] UnzipBytes(string path, EncryptTool.AesKeyType type)
		{
			MemoryStream stream = new MemoryStream(EncryptTool.ReadAES(path, type));
			MemoryStream memoryStream = new MemoryStream();

			using (GZipStream gzipStream = new GZipStream(stream, CompressionMode.Decompress))
			{
				gzipStream.CopyTo(memoryStream);
			}
			return memoryStream.ToArray();
		}
		public static byte[] ReadAES(string path, EncryptTool.AesKeyType type)
		{
			byte[] EncryptedBytes = File.ReadAllBytes(path);
			int num = EncryptedBytes.Length - 16;
			byte[] DecryptedBytes = new byte[num];
			byte[] IV = new byte[16];
			Array.Copy(EncryptedBytes, 0, IV, 0, 16);
			byte[] FinalDecryptedBytes;
			using (ICryptoTransform cryptoTransform = new AesCryptoServiceProvider
			{
				BlockSize = 128,
				KeySize = 256,
				Mode = CipherMode.CBC,
				Padding = PaddingMode.PKCS7,
				IV = IV,
				Key = Encoding.ASCII.GetBytes(EncryptTool.AESKey(type))
			}.CreateDecryptor())
			{
				using (MemoryStream memoryStream = new MemoryStream(EncryptedBytes, 16, num))
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read))
					{
						using (BinaryReader binaryReader = new BinaryReader(cryptoStream))
						{
							binaryReader.Read(DecryptedBytes, 0, num);
						}
					}
				}
				FinalDecryptedBytes = DecryptedBytes;
			}
			return FinalDecryptedBytes;
		}
		public static byte[] CreateAES(string path, EncryptTool.AesKeyType type)
		{
			byte[] UnencryptedBytes = File.ReadAllBytes(path);
			byte[] EncryptedBytes;
			using (ICryptoTransform cryptoTransform = new AesCryptoServiceProvider
			{
				BlockSize = 128,
				KeySize = 256,
				Mode = CipherMode.CBC,
				Padding = PaddingMode.PKCS7,
				IV = Encoding.UTF8.GetBytes("MadeByGodteriOwO"),
				Key = Encoding.ASCII.GetBytes(EncryptTool.AESKey(type))
			}.CreateEncryptor())
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
					{ 
						using (BinaryWriter binaryWriter = new BinaryWriter(cryptoStream))
						{
							binaryWriter.Write(UnencryptedBytes);
						}
					}
					EncryptedBytes = Encoding.UTF8.GetBytes("MadeByGodteriOwO");
					EncryptedBytes = Combine(EncryptedBytes, memoryStream.ToArray());
				}	
			}
			return EncryptedBytes;
		}
		private static string AESKey(EncryptTool.AesKeyType type)
		{
			string text = "";
			for (int i = 0; i < 16; i++)
			{
				int j;
				for (j = EncryptTool.AESNum(i); j > 255; j -= 256)
				{
				}
				int num = i * 2;
				if (type != EncryptTool.AesKeyType.Type1)
				{
					if (type != EncryptTool.AesKeyType.Type2)
					{
						text += Convert.ToChar((int)EncryptTool.aesValType0[num] ^ j).ToString();
						text += Convert.ToChar((int)EncryptTool.aesValType0[num + 1] ^ j).ToString();
					}
					else
					{
						text += Convert.ToChar((int)EncryptTool.aesValType2[num] ^ j).ToString();
						text += Convert.ToChar((int)EncryptTool.aesValType2[num + 1] ^ j).ToString();
					}
				}
				else
				{
					text += Convert.ToChar((int)EncryptTool.aesValType1[num] ^ j).ToString();
					text += Convert.ToChar((int)EncryptTool.aesValType1[num + 1] ^ j).ToString();
				}
			}
			return text;
		}
		private static int AESNum(int n)
		{
			int i = 0;
			int num = 1;
			int num2 = 0;
			while (i < n)
			{
				int num3 = num;
				num = num2;
				num2 = num3 + num;
				i++;
			}
			return num2;
		}

		private static readonly byte[] aesValType0 = new byte[]
		{
		121,
		74,
		123,
		79,
		87,
		80,
		116,
		78,
		65,
		75,
		73,
		103,
		80,
		95,
		59,
		79,
		124,
		82,
		73,
		17,
		67,
		103,
		24,
		21,
		214,
		195,
		143,
		140,
		63,
		20,
		53,
		36
		};

		private static readonly byte[] aesValType1 = new byte[]
		{
		82,
		97,
		89,
		117,
		56,
		83,
		55,
		115,
		110,
		85,
		93,
		55,
		90,
		69,
		73,
		88,
		109,
		94,
		83,
		16,
		112,
		89,
		3,
		11,
		229,
		220,
		164,
		208,
		58,
		16,
		37,
		1
		};

		private static readonly byte[] aesValType2 = new byte[]
		{
		81,
		121,
		87,
		113,
		121,
		84,
		114,
		55,
		52,
		55,
		118,
		51,
		76,
		92,
		121,
		107,
		81,
		70,
		106,
		26,
		125,
		114,
		61,
		111,
		232,
		164,
		141,
		190,
		16,
		76,
		19,
		90
		};
		public enum AesKeyType
		{
			Type0,
			Type1,
			Type2
		}
		public static byte[] Combine(byte[] first, byte[] second)
		{
			byte[] bytes = new byte[first.Length + second.Length];
			Buffer.BlockCopy(first, 0, bytes, 0, first.Length);
			Buffer.BlockCopy(second, 0, bytes, first.Length, second.Length);
			return bytes;
		}
	}

}
