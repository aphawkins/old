using System;
using System.IO;
using System.Security.Cryptography;

namespace Useful.Security.Cryptography
{
	/// <summary>
	/// An interface between logging client and server.
	/// </summary>
	public interface ICryptographyService
	{
		/// <summary>
		/// Enciphers or deciphers a stream.
		/// </summary>
		/// <param name="input">The input stream.</param>
		/// <param name="output">The output stream.</param>
        /// <param name="cipherType">The cipher to use.</param>
		/// <param name="settings">The cipher's initial settings.</param>
		/// <param name="transformMode">Defines the way in which the cipher will work.</param>
		void DoCipher(Stream input, Stream output, Type cipherType, ISymmetricCipherSettings settings, CipherTransformMode transformMode);

		/// <summary>
		/// Enciphers or deciphers a stream.
		/// </summary>
		/// <param name="input">The input text.</param>
        /// <param name="cipherType">The cipher to use.</param>
        /// <param name="settings">The cipher's initial settings.</param>
        /// <param name="transformMode">Defines the way in which the cipher will work.</param>
        /// <returns>The output text.</returns>
        string DoCipher(string input, Type cipherType, ISymmetricCipherSettings settings, CipherTransformMode transformMode);
	}
}
