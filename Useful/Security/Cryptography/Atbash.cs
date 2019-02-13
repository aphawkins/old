using System;
using System.Text;
using System.Globalization;

namespace Useful.Security.Cryptography
{
    /// <summary>
    /// Accesses the Caesar Shift algorithm.
    /// </summary>
	public static class Atbash
	{
		private static CultureInfo m_culture = CultureInfo.InvariantCulture;

        /// <summary>
        /// Cracks ciphertext into plaintext.
        /// </summary>
        /// <param name="ciphertext">The ciphertext to crack.</param>
        /// <returns>The plaintext.</returns>
		public static string Crack(string ciphertext)
		{
		    // We don't need to crack it as there's nothing to crack hence do an en/de-cryption
			return Encipher(ciphertext);
		}

        /// <summary>
        /// Decipher a ciphertext letter into an plaintext letter.
        /// </summary>
        /// <param name="letter">The ciphertext letter to decipher.</param>
        /// <returns>The plaintext letter.</returns>
		public static char Decipher(char letter)
		{
			return Encipher(letter);
		}

        /// <summary>
        /// Decipher a ciphertext into plaintext.
        /// </summary>
        /// <param name="ciphertext">The ciphertext to decipher.</param>
        /// <returns>The plaintext.</returns>
		public static string Decipher(string ciphertext)
		{
		    // To decipher just need to use the encryption method as the cipher is reversible
			return Encipher(ciphertext);
		}

        /// <summary>
        /// Encipher a plaintext letter into an enciphered letter.
        /// </summary>
        /// <param name="letter">The plaintext letter to encipher.</param>
        /// <returns>The enciphered letter.</returns>
		public static char Encipher(char letter)
		{
			if (char.IsLetter(letter))
			{
				//A=Z, B=Y, C=X, etc
				return ((char)('Z' - (char.ToUpper(letter, m_culture) % 'A')));
			}
			else
			{
				//Not a letter so do nothing to it
				return letter;
			}
		}

        /// <summary>
        /// Encipher a plaintext string into ciphertext.
        /// </summary>
        /// <param name="plaintext">The plaintext to encipher.</param>
        /// <returns>The ciphertext.</returns>
		public static string Encipher(string plaintext)
		{
			if (plaintext == null)
			{
				throw new ArgumentNullException("plaintext");
			}

			StringBuilder ciphertext = new StringBuilder();

			for (int i = 0 ; i < plaintext.Length ; i++)
			{
				ciphertext.Append(Encipher(plaintext[i]));
			}
			return ciphertext.ToString();
		}
	}
}

