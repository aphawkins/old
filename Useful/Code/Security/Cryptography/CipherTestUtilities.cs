//-----------------------------------------------------------------------
// <copyright file="CipherTestUtilities.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>The MonoAlphabetic algorithm.</summary>
//-----------------------------------------------------------------------

namespace Useful.Security.Cryptography
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Utilities used for testing ciphes.
    /// </summary>
    public static class CipherTestUtilities
    {
        /// <summary>
        /// Tests writing and reading enciphered text to a file.
        /// </summary>
        /// <param name="target">The algorithm to use.</param>
        /// <param name="mode">The direction of encryption.</param>
        /// <param name="input">The text to test.</param>
        public static void TestFile(SymmetricAlgorithm target, CipherTransformMode mode, string input)
        {
            string filePath = Path.GetTempFileName();

            // Write the file
            using (MemoryStream inputStream = new MemoryStream(Encoding.Unicode.GetBytes(input)))
            {
                using (FileStream outputStream = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    CipherMethods.DoCipher(target, mode, inputStream, outputStream, new UTF8Encoding(false));
                }
            }

            string output;

            // Read the file
            using (MemoryStream outputStream = new MemoryStream())
            {
                using (FileStream inputStream = new FileStream(filePath, FileMode.Open))
                {
                    CipherMethods.DoCipher(target, CipherTransformMode.Encrypt, inputStream, outputStream, new UTF8Encoding(false));
                }

                outputStream.Flush();
                output = Encoding.Unicode.GetString(outputStream.ToArray());
            }

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            Assert.IsTrue(string.Equals(input, output, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Tests an encryption algorithm.
        /// </summary>
        /// <param name="target">The algorithm to use.</param>
        /// <param name="mode">The direction of the encryption.</param>
        /// <param name="key">the key.</param>
        /// <param name="iv">The initialization vector.</param>
        /// <param name="input">The test text.</param>
        /// <param name="output">The expected resul text.</param>
        /// <param name="newIv">The value of the resultant initialization vecctor.</param>
        internal static void TestTarget(SymmetricAlgorithm target, CipherTransformMode mode, string key, string iv, string input, string output, string newIv)
        {
            target.Key = Encoding.Unicode.GetBytes(key);
            target.IV = Encoding.Unicode.GetBytes(iv);
            TestTargetStream(target, mode, input, output);
            Assert.IsTrue(string.Equals(Encoding.Unicode.GetString(target.Key), key, StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(string.Equals(Encoding.Unicode.GetString(target.IV), newIv, StringComparison.OrdinalIgnoreCase));

            target.Key = Encoding.Unicode.GetBytes(key);
            target.IV = Encoding.Unicode.GetBytes(iv);
            TestTargetString(target, mode, input, output);
            Assert.IsTrue(string.Equals(Encoding.Unicode.GetString(target.Key), key, StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(string.Equals(Encoding.Unicode.GetString(target.IV), newIv, StringComparison.OrdinalIgnoreCase));
        }

        private static void TestTargetStream(SymmetricAlgorithm target, CipherTransformMode mode, string input, string output)
        {
            byte[] preamble = Encoding.Unicode.GetPreamble();
            byte[] inputBytes = Encoding.Unicode.GetBytes(input);

            using (MemoryStream inputStream = new MemoryStream(preamble.Length + inputBytes.Length))
            {
                inputStream.Write(preamble, 0, preamble.Length);
                inputStream.Write(inputBytes, 0, inputBytes.Length);
                inputStream.Position = 0;

                using (MemoryStream outputStream = new MemoryStream())
                {
                    CipherMethods.DoCipher(target, mode, inputStream, outputStream, new UnicodeEncoding(false, false));

                    outputStream.Flush();

                    byte[] encoded = outputStream.ToArray();

                    string s = Encoding.Unicode.GetString(encoded);
                    Assert.IsTrue(string.Equals(s, output, StringComparison.Ordinal));
                }
            }
        }

        private static void TestTargetString(SymmetricAlgorithm target, CipherTransformMode mode, string plaintext, string ciphertext)
        {
            string enciphered = CipherMethods.DoCipher(target, mode, plaintext);
            Assert.IsTrue(string.Equals(enciphered, ciphertext, StringComparison.OrdinalIgnoreCase));
        }
    }
}