using System;
using System.Collections.Generic;
using System.Text;

using Useful;

namespace Useful.Security.Cryptography
{
    /// <summary>
    /// Accesses the Playfair algorithm.
    /// </summary>
	public class Playfair
	{
		string m_keyString;	//The keystring used to generate the square
		char[][] m_square;		//The 5x5 square to hold the key
		int[] m_letterColumn;	//Which column the letter appears in the square
		int[] m_letterRow;		//Which row the letter appears in the square

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
		public Playfair()
		{
			Reset();
		}

		private void Reset()
		{
			this.m_keyString = string.Empty;
			this.m_square = new char[5][];
			for (int i = 0; i < 5; i++)
			{
				this.m_square[i] = new char[5];
			}
			this.m_letterColumn = new int[26];
			this.m_letterRow = new int[26];
		}

        /// <summary>
        /// The keyword used to encipher/decipher the code.
        /// </summary>
		public string Keyword
		{
			get 
			{
				return this.m_keyString;
			}
			set 
			{
				this.m_keyString = Letters.CleanString(value);
				GenerateSquare();
			}
		}

		private void GenerateSquare()
		{
            List<char> letters = new List<char>();
			int currentRow = 0;
			int currentColumn = 0;
			this.m_letterColumn = new int[26];
			this.m_letterRow = new int[26];

			//Populate the arraylist with all letters
			for (char c = 'A' ; c <= 'Z' ; c++)
			{
				if (c != 'J')
				{
					letters.Add(c);
				}
			}

			//Sort the arraylist
			letters.Sort();

			string keyString = this.m_keyString.Replace('J', 'I');
	
			for (int i = 0 ; i < keyString.Length ; i++)
			{
				if (letters.Contains(keyString[i]))
				{
					//Move to the next row if we're at the end of the column
					if ((currentColumn > 4))
					{
						currentRow++;
						currentColumn = 0;
					}
					
					//Add the letter to the square
					this.m_square[currentRow][currentColumn] = keyString[i];
					m_letterColumn[keyString[i] % 'A'] = currentColumn;
					m_letterRow[keyString[i] % 'A'] = currentRow;

					currentColumn++;

					letters.Remove(keyString[i]);
				}
			}

			for (int i = 0 ; i < letters.Count ; i++)
			{
				//Move to the next row if we're at the end of the column
				if ((currentColumn > 4))
				{
					currentRow++;
					currentColumn = 0;
				}
					
				//Add the letter to the square
				this.m_square[currentRow][currentColumn] = (char)letters[i];
				this.m_letterColumn[((char)letters[i]) % 'A'] = currentColumn;
				this.m_letterRow[((char)letters[i]) % 'A'] = currentRow;

				currentColumn++;
			}
		}

		/// <summary>
		/// Enciphers a digraph.
		/// </summary>
		/// <param name="letterA">The first letter of the digraph.</param>
		/// <param name="letterB">The second letter of the digraph.</param>
		/// <returns>The enciphered digraph.</returns>
		public string Encipher(char letterA, char letterB)
		{
			int letterACol = this.m_letterColumn[letterA % 'A'];
			int letterARow = this.m_letterRow[letterA % 'A'];
			int letterBCol = this.m_letterColumn[letterB % 'A'];
			int letterBRow = this.m_letterRow[letterB % 'A'];
			char encipheredLetterA = char.MinValue;
			char encipheredLetterB = char.MinValue;

			//Different row & different column
			if ((letterACol != letterBCol) && (letterARow != letterBRow))
			{
				encipheredLetterA = this.m_square[letterARow][letterBCol];
				encipheredLetterB = this.m_square[letterBRow][letterACol];
			}
			//Same row
			else if (letterARow == letterBRow)
			{
				encipheredLetterA = this.m_square[letterARow][(letterACol + 1) % 5];
				encipheredLetterB = this.m_square[letterBRow][(letterBCol + 1) % 5];
			}
			//Same column
			else if (letterACol == letterBCol)
			{
				encipheredLetterA = this.m_square[(letterARow + 1) % 5][letterACol];
				encipheredLetterB = this.m_square[(letterBRow + 1) % 5][letterBCol];
			}
			return encipheredLetterA.ToString() + encipheredLetterB.ToString();
		}

        /// <summary>
        /// Encipher a plaintext string into ciphertext.
        /// </summary>
        /// <param name="plaintext">The plaintext to encipher.</param>
        /// <returns>The ciphertext.</returns>
		public string Encipher(string plaintext)
		{
			char[][] digraphs;
			StringBuilder ciphertext = new StringBuilder();

			digraphs = CipherMethods.GenerateDigraphs(plaintext);
			for (int i = 0 ; i <= digraphs.Length ; i++)
			{
				ciphertext.Append(Encipher(digraphs[i][0], digraphs[i][1]));
			}
			return ciphertext.ToString();
		}

		/// <summary>
		/// Decipher a digraph.
		/// </summary>
		/// <param name="letterA">First letter of the digraph.</param>
        /// <param name="letterB">Second letter of the digraph.</param>
		/// <returns></returns>
		public string Decipher(char letterA, char letterB)
		{
			int letterACol = this.m_letterColumn[letterA % 'A'];
			int letterARow = this.m_letterRow[letterA % 'A'];
			int letterBCol = this.m_letterColumn[letterB % 'A'];
			int letterBRow = this.m_letterRow[letterB % 'A'];
			char encipheredLetterA = char.MinValue;
			char encipheredLetterB = char.MinValue;

			//Different row & different column
			if ((letterACol != letterBCol) && (letterARow != letterBRow))
			{
				encipheredLetterA = this.m_square[letterARow][letterBCol];
				encipheredLetterB = this.m_square[letterBRow][letterACol];
			}
			//Same row
			else if (letterARow == letterBRow)
			{
				encipheredLetterA = this.m_square[letterARow][(letterACol + 4) % 5];
				encipheredLetterB = this.m_square[letterBRow][(letterBCol + 4) % 5];
			}
			//Same column
			else if (letterACol == letterBCol)
			{
				encipheredLetterA = this.m_square[(letterARow + 4) % 5][letterACol];
				encipheredLetterB = this.m_square[(letterBRow + 4) % 5][letterBCol];
			}
			return encipheredLetterA.ToString() + encipheredLetterB.ToString();
		}

        /// <summary>
        /// Decipher a ciphertext into plaintext.
        /// </summary>
        /// <param name="ciphertext">The ciphertext to decipher.</param>
        /// <returns>The plaintext.</returns>
		public string Decipher(string ciphertext)
		{
			char[][] digraphs;
			StringBuilder plaintext = new StringBuilder();

			digraphs = CipherMethods.SplitDigraphs(ciphertext);
			for (int i = 0 ; i <= digraphs.Length ; i++)
			{
				plaintext.Append(Decipher(digraphs[i][0], digraphs[i][1]));
			}
			return plaintext.ToString();
		}
	}
}
