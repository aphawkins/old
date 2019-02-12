using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Globalization;

using Useful;

namespace Useful.Security.Cryptography
{
    /// <summary>
    /// Accesses the Vigenere algorithm.
    /// </summary>
	public static class Vigenere
	{
        /// <summary>
        /// Encipher plaintext into ciphertext using a specified key.
        /// </summary>
        /// <param name="plaintext">The plaintext to encipher.</param>
        /// <param name="key">The key used to encipher the plaintext.</param>
        /// <returns>The ciphertext.</returns>
		public static string Encipher(string plaintext, string key)
		{
			if (plaintext == null)
			{
				throw new ArgumentNullException("plaintext");
			}
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}

			StringBuilder ciphertext = new StringBuilder();

			for (int i = 0; i < plaintext.Length; i++)
			{
				ciphertext.Append(Caesar.Encipher(plaintext[i], key[(i % key.Length)]));
			}
			return ciphertext.ToString();
		}

		/// <summary>
		/// Decrypts a string based on the CodeString
		/// </summary>
		/// <param name="ciphertext"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public static string Decipher(string ciphertext, string key)
		{
			if (ciphertext == null)
			{
				throw new ArgumentNullException("ciphertext");
			}

			if (key == null)
			{
				throw new ArgumentNullException("key");
			}

			if (key.Length <= 0)
			{
				return ciphertext;
			}

			StringBuilder plaintext = new StringBuilder();


			for (int i = 0; i < ciphertext.Length; i++)
			{
				plaintext.Append(Caesar.Decipher(ciphertext[i], key[(i % key.Length)]));
			}

			return plaintext.ToString();
		}

		/// <summary>
		/// Cracks the Vigenere cipher.
		/// </summary>
		/// <param name="ciphertext"></param>
		/// <returns>The keystring.</returns>
		public static string Crack(string ciphertext)
		{
			int keyLength = FindKeyLength(ciphertext);
			 
			return FindKeyString(ciphertext, keyLength);
		}

		private static int FindKeyLength(string ciphertext)
		{
			int matchCount;
			string tempCiphertext;
			string crackText;
			int letterCount;
			float[] matches;
			int topSearch;
			int[] top;

			//Check parameters
			if (ciphertext.Length == 0)
			{
				return 0;
			}
  
			matches = new float[ciphertext.Length];
            Dictionary<int, float> htMatches = new Dictionary<int, float>();

			//Loop through the string to find matches
			//Start at 1 as 0 will always match itself
			for (int i = 1 ; i < ciphertext.Length ; i++)
			{
				matchCount = 0;
			    
				tempCiphertext = ciphertext.Substring(i);
				crackText = ciphertext.Substring(0,  ciphertext.Length - i);
			    

				for (letterCount = 0 ; letterCount < (ciphertext.Length - i) ; letterCount++) 
				{
					if (char.IsLetter(tempCiphertext[letterCount]) && char.IsLetter(crackText[letterCount]))
					{
						if (tempCiphertext[letterCount].Equals(crackText[letterCount]))
						{
							matchCount++;
						}
					}
				}
							    
				//Calculate a weighting for the match
				matches[i] = ((float)matchCount / (float)ciphertext.Length) * 100.0f;

				//Create a hashtable of the matches
				htMatches.Add(i, matches[i]);
			}

			topSearch = (ciphertext.Length / 40);
			if (topSearch == 0)
			{
				topSearch = 1;
			}
			if (topSearch > 5)
			{
				topSearch = 5;
			}

			top = new int[topSearch];

			for (int i = 0 ; i < topSearch ; i++)
			{
				top[i] = GetAndRemoveLargestWeighting(htMatches);
			}

			return Statistics.FindCommonDenominator(top, SearchMethod.Highest);
		}

		/// <summary>
		/// Finds the key required to decipher the ciphertext.
		/// </summary>
        /// <param name="ciphertext">The ciphertext.</param>
        /// <param name="keyLength">The length of the key to find.</param>
		/// <returns></returns>
		public static string FindKeyString(string ciphertext, int keyLength)
		{
			if (ciphertext == null)
			{
				throw new ArgumentNullException("ciphertext");
			}

			StringBuilder extracted = new StringBuilder();
			char shift;
			StringBuilder keyString = new StringBuilder();

			for (int i = 0 ; i < keyLength ; i++)
			{
				extracted = new StringBuilder();
				for (int cipherCount = 0 ; cipherCount < ciphertext.Length ; cipherCount++)
				{
					if ((cipherCount % keyLength) == i)
					{
						extracted.Append(ciphertext[cipherCount]);
					}
				}
				shift = Caesar.Crack(extracted.ToString());
				keyString.Append(shift);
			}
			return keyString.ToString();
		}


		/// <summary>
		/// Go through the collection finding the biggest match weighting, then remove it.
		/// </summary>
        /// <param name="match">The collection of weightings.</param>
		/// <returns>The index of the largest key.</returns>
		private static int GetAndRemoveLargestWeighting(Dictionary<int, float> match)
		{
			float largestValue = float.MinValue;
			int largestKey = 0;

			foreach (int i in match.Keys)
			{
				if ((float)match[i] > largestValue)
				{
					largestValue = match[i];
					largestKey = i;
				}
			}
			match.Remove(largestKey);
			return largestKey;
		}
	}
}
