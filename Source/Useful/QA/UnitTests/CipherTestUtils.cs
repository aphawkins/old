using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Useful.Security.Cryptography;
using System.IO;
using System;

namespace UsefulQA
{
    public static class CipherTestUtils
    {
        internal static void TestTarget(SymmetricAlgorithm target, string key, string iv, string input, string output, string newIv)
        {
            target.Key = Encoding.Unicode.GetBytes(key);
            target.IV = Encoding.Unicode.GetBytes(iv);
            TestTargetStream(target, input, output);
            Assert.IsTrue(string.Compare(Encoding.Unicode.GetString(target.Key), key, false) == 0);
            Assert.IsTrue(string.Compare(Encoding.Unicode.GetString(target.IV), newIv, false) == 0);
  
            target.Key = Encoding.Unicode.GetBytes(key);
            target.IV = Encoding.Unicode.GetBytes(iv);
            TestTargetString(target, input, output);
            Assert.IsTrue(string.Compare(Encoding.Unicode.GetString(target.Key), key, false) == 0);
            Assert.IsTrue(string.Compare(Encoding.Unicode.GetString(target.IV), newIv, false) == 0);
        }

        private static void TestTargetStream(SymmetricAlgorithm target, string input, string output)
        {
            using (MemoryStream inputStream = new MemoryStream(Encoding.Unicode.GetBytes(input)))
            {
                using (MemoryStream outputStream = new MemoryStream())
                {
                    CipherMethods.DoCipher(target, CipherTransformMode.Encrypt, inputStream, outputStream, new UnicodeEncoding(false, false));

                    outputStream.Flush();
                    string s = Encoding.Unicode.GetString(outputStream.ToArray());
                    Assert.IsTrue(string.Equals(s, output, StringComparison.OrdinalIgnoreCase));
                }
            }
        }

        private static void TestTargetString(SymmetricAlgorithm target, string input, string output)
        {
            string enciphered = CipherMethods.DoCipher(target, CipherTransformMode.Encrypt, input);
            Assert.IsTrue(string.Compare(enciphered, output, false) == 0);
        }

        public static void TestFile(SymmetricAlgorithm target, string input)
        {
            string filePath = @"C:\ciphertest.txt";

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (MemoryStream inputStream = new MemoryStream(Encoding.Unicode.GetBytes(input)))
            {
                using (FileStream outputStream = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    CipherMethods.DoCipher(target, CipherTransformMode.Encrypt, inputStream, outputStream, new UTF8Encoding(false));
                }
            }

            string output;

            using (MemoryStream outputStream = new MemoryStream())
            {
                using (FileStream inputStream = new FileStream(filePath, FileMode.Open))
                {
                    CipherMethods.DoCipher(target, CipherTransformMode.Encrypt, inputStream, outputStream, new UTF8Encoding(false));
                }

                outputStream.Flush();
                output = Encoding.Unicode.GetString(outputStream.ToArray());
            }

            Assert.IsTrue(string.Equals(input, output));
        }
    }
}
