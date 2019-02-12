using System;
using System.Security.Cryptography;

namespace Useful.Security.Cryptography
{
    /// <summary>
    /// Accesses the Reversed Caesar Shift algorithm.
    /// </summary>
	public static class ReversedCaesar
	{
        /// <summary>
        /// Cracks ciphertext into plaintext.
        /// </summary>
        /// <param name="ciphertext">The ciphertext to crack.</param>
        /// <returns>The plaintext.</returns>
		public static char Crack(string ciphertext)
		{
			return Caesar.Crack(Atbash.Crack(ciphertext));
		}

        /// <summary>
        /// Decipher ciphertext letter into plaintext using the specified shift.
        /// </summary>
        /// <param name="letter">The letter to decipher.</param>
        /// <param name="shift">The shift used to decipher.</param>
        /// <returns>The plaintext letter.</returns>
		public static char Decipher(char letter, char shift)
		{
			return Caesar.Decipher(Atbash.Decipher(letter), shift);
		}

        /// <summary>
        /// Decipher ciphertext into plaintext using the specified shift.
        /// </summary>
        /// <param name="ciphertext">The ciphertext to decipher.</param>
        /// <param name="shift">The shift used to decipher.</param>
        /// <returns>The plaintext.</returns>
		public static string Decipher(string ciphertext, char shift)
		{
			return Caesar.Decipher(Atbash.Decipher(ciphertext), shift);
		}

        /// <summary>
        /// Encipher a plaintext letter into ciphertext using the specified shift.
        /// </summary>
        /// <param name="letter">The plaintext letter to encipher.</param>
        /// <param name="shift">The shift used to encipher.</param>
        /// <returns>The ciphertext letter.</returns>
		public static char Encipher(char letter, char shift)
		{
			return Atbash.Encipher(Caesar.Encipher(letter, shift));
		}

        /// <summary>
        /// Encipher plaintext into ciphertext using the specified shift.
        /// </summary>
        /// <param name="plaintext">The plaintext to encipher.</param>
        /// <param name="shift">The shift used to encipher.</param>
        /// <returns>The ciphertext.</returns>
		public static string Encipher(string plaintext, char shift)
		{
			return Atbash.Encipher(Caesar.Encipher(plaintext, shift));
		}
	}
}
