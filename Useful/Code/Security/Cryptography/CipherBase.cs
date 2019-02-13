using System;
using System.ComponentModel;

namespace Useful.Security.Cryptography
{
    /// <summary>
    /// A base class that all ciphers inherit from.
    /// </summary>
	public abstract class CipherBase
	{
        /// <summary>
        /// Encipher a plaintext letter into an enciphered letter.
        /// </summary>
        /// <param name="plaintext">The plaintext letter to encipher.</param>
        /// <returns>The enciphered letter.</returns>
		public abstract string Encipher(string plaintext);

        /// <summary>
        /// Decipher ciphertext into plaintext.
        /// </summary>
        /// <param name="ciphertext">The ciphertext to decipher.</param>
        /// <returns>The plaintext.</returns>
		public abstract string Decipher(string ciphertext);	
	}
}
