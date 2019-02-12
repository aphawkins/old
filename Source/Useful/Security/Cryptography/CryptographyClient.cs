using System;
using System.IO;
using System.Security.Cryptography;

namespace Useful.Security.Cryptography
{
	/// <summary>
	/// A base class for a logging client.
	/// </summary>
	public sealed class CryptographyClient : /* RemoteClient, */ ICryptographyService
	{
		#region ICryptographyService Members

		/// <summary>
		/// Enciphers or deciphers a stream.
		/// </summary>
		/// <param name="input">The input stream.</param>
		/// <param name="output">The output stream.</param>
        /// <param name="cipherType">The cipher to use.</param>
		/// <param name="key">The cipher's initial settings.</param>
        /// <param name="iv">The cipher's initial settings.</param>
		/// <param name="transformMode">Defines the way in which the cipher will work.</param>
        public void DoCipher(Stream input, Stream output, Type cipherType, ref byte[] key, ref byte[] iv, Useful.Security.Cryptography.CipherTransformMode transformMode)
		{
			CipherMethods.DoCipher(input, output, cipherType, ref key, ref iv, transformMode);
		}

		/// <summary>
		/// Enciphers or deciphers a stream.
		/// </summary>
		/// <param name="input">The input text.</param>
        /// <param name="cipherType">The cipher to use.</param>
        /// <param name="key">The cipher's initial settings.</param>
        /// <param name="iv">The cipher's initial settings.</param>
		/// <param name="transformMode">Defines the way in which the cipher will work.</param>
		/// <returns>The output text.</returns>
        public string DoCipher(string input, Type cipherType, ref byte[] key, ref byte[] iv, Useful.Security.Cryptography.CipherTransformMode transformMode)
		{
            string ciphertext = CipherMethods.DoCipher(input, cipherType, ref key, ref iv, transformMode);
			return ciphertext;
		}

		#endregion
	}
}
