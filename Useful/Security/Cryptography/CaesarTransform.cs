using System;
using System.Security.Cryptography;
using System.Globalization;
using System.Text;
using System.Diagnostics;

namespace Useful.Security.Cryptography
{
	internal sealed class CaesarTransform : ICryptoTransform
	{
        private const int c_blockSize = 2;

        private readonly CipherTransformMode transformMode;
        private CaesarSettings settings;

        ////static int[] frequency = new int[Letters.CaesarLetters.Count];	// 26 letters 0 to 25
        ////static int letterCount;

        #region Constructor
        internal CaesarTransform(byte[] rgbKey, CipherTransformMode transformMode)
		{
            settings = new CaesarSettings(rgbKey, null);

			this.transformMode = transformMode;
        }
        #endregion

        #region ICryptoTransform Members

        public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
		{
            if (inputBuffer[0] == 0)
            {
                return inputBuffer;
            }
            else
            {
                byte[] outputBuffer = new byte[0];
                TransformBlock(inputBuffer, inputOffset, inputCount, outputBuffer, 0);
                return outputBuffer;
            }
		}

		public bool CanReuseTransform
		{
			get
			{
				return true;
			}
		}

		public int InputBlockSize
		{
			get
			{
				return c_blockSize;
			}
		}

		public int OutputBlockSize
		{
			get
			{
				return c_blockSize;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="inputBuffer">The input for which to compute the Caesar code.</param>
		/// <param name="inputOffset"></param>
		/// <param name="inputCount"></param>
		/// <param name="outputBuffer"></param>
		/// <param name="outputOffset"></param>
		/// <returns></returns>
		public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
		{
			if (inputBuffer == null)
			{
				throw new ArgumentNullException("inputBuffer");
			}
			if (outputBuffer == null)
			{
				throw new ArgumentNullException("outputBuffer");
			}
			if (inputBuffer.Length < (inputOffset + inputCount))
			{
				throw new ArgumentException(Resource.InputBufferLength, "inputBuffer");
			}
			try
			{
				byte[] inputBytes = new byte[c_blockSize];
				Array.Copy(inputBuffer, inputOffset, inputBytes, 0, c_blockSize);
				char[] inputChars = Encoding.Unicode.GetChars(inputBytes);
				char cipheredChar;

				switch (this.transformMode)
				{
					case (CipherTransformMode.Encrypt):
					{
						cipheredChar = Encipher(inputChars[0]);
						// outputBuffer[outputOffset] = (byte)Encipher((char)inputBuffer[inputOffset]);
						break;
					}
					case (CipherTransformMode.Decrypt):
					{
						cipheredChar = Decipher(inputChars[0]);
						// outputBuffer[outputOffset] = (byte)Decipher((char)inputBuffer[inputOffset]);
						break;
					}
					default:
					{
						throw new CryptographicException(string.Format(Culture.CaesarCulture, Resource.UnsupportedTransformMode, this.transformMode.ToString()));
					}
				}

				byte[] cipheredBytes = Encoding.Unicode.GetBytes(new char[] { cipheredChar });
				Array.Copy(cipheredBytes, 0, outputBuffer, 0, c_blockSize);

				return inputCount;
			}
			catch
			{
				throw;
			}
		}

		public bool CanTransformMultipleBlocks
		{
			get
			{
				return false;
			}
		}

		#endregion

        #region Encipher
        /// <summary>
        /// Encipher a plaintext letter into an enciphered letter.
        /// </summary>
        /// <param name="letter">The plaintext letter to encipher.</param>
        /// <returns>The enciphered letter.</returns>
		private char Encipher(char letter)
		{
            Debug.Assert(this.settings.AllowedLetters.Contains(letter));

            //// Not a letter?
            //if (!char.IsLetter(letter))
            //{
            //    return letter;
            //}

			// Force upper case, add the shift
			return (char)(((char.ToUpper(letter, Culture.CaesarCulture) + char.ToUpper(this.settings.Shift, Culture.CaesarCulture)) % Letters.CaesarLetters.Count) + 'A');
		}

		///// <summary>
		///// Encipher a plaintext letter into an enciphered letter.
		///// </summary>
		///// <param name="letter">The plaintext letter to encipher.</param>
		///// <returns>The enciphered letter.</returns>
		//private char Encipher(char letter)
		//{
		//    //return deciphered letter
		//    return CaesarTransform.Encipher(letter, this.settings);
		//}

		///// <summary>
		///// Encipher a plaintext letter into an enciphered letter using the specified shift.
		///// </summary>
		///// <param name="letter">The plaintext letter to encipher.</param>
		///// <param name="settings">The settings used to encipher.</param>
		///// <returns>The enciphered letter.</returns>
		//private static char Encipher(char letter, CaesarSettings settings)
		//{
		//    // Not a letter?
		//    if (!char.IsLetter(letter))
		//    {
		//        return letter;
		//    }

		//    // Force upper case, add the shift
		//    return (char)(((char.ToUpper(letter, s_culture) + char.ToUpper(settings.Shift, s_culture)) % letterNum) + 'A');
		//}

		///// <summary>
		///// Encipher plaintext into ciphertext using the specified shift.
		///// </summary>
		///// <param name="plaintext">The plaintext to encipher.</param>
		///// <param name="settings">The settings used to encipher.</param>
		///// <returns>The ciphertext.</returns>
		//private static string Encipher(string plaintext, CaesarSettings settings)
		//{
		//    if (plaintext == null)
		//    {
		//        throw new ArgumentNullException("plaintext");
		//    }

		//    StringBuilder ciphertext = new StringBuilder(plaintext.Length);

		//    //Encipher the string
		//    for (int i = 0; i < plaintext.Length; i++)
		//    {
		//        ciphertext.Append(Encipher(plaintext[i], settings));
		//    }

		//    //Return the enciphered string
		//    return ciphertext.ToString();
		//}

        #endregion

        #region Decipher

		/// <summary>
		/// Deciphers a plaintext letter into an plaintext letter.
		/// </summary>
		/// <param name="letter">The enciphered letter to decipher.</param>
		/// <returns>The deciphered letter.</returns>
		private char Decipher(char letter)
		{
            Debug.Assert(this.settings.AllowedLetters.Contains(letter));

            //// Not a letter?
            //if (!char.IsLetter(letter))
            //{
            //    return letter;
            //}

			// Force upper case, remove the shift
            return (char)(((char.ToUpper(letter, Culture.CaesarCulture) - char.ToUpper(this.settings.Shift, Culture.CaesarCulture) + Letters.CaesarLetters.Count) % Letters.CaesarLetters.Count) + 'A');
		}

		///// <summary>
		///// Deciphers a plaintext letter into an plaintext letter.
		///// </summary>
		///// <param name="letter">The enciphered letter to decipher.</param>
		///// <returns>The deciphered letter.</returns>
		//private char Decipher(char letter)
		//{
		//    //return deciphered letter
		//    return CaesarTransform.Decipher(letter, this.settings);
		//}

		///// <summary>
		///// Decipher ciphertext letter into plaintext letter using the specified shift.
		///// </summary>
		///// <param name="letter">The letter to decipher.</param>
		///// <param name="settings">The settings used to decipher.</param>
		///// <returns>The plaintext letter.</returns>
		//internal static char Decipher(char letter, CaesarSettings settings)
		//{
		//    // Not a letter?
		//    if (!char.IsLetter(letter))
		//    {
		//        return letter;
		//    }

		//    // Force upper case, remove the shift
		//    return (char)(((char.ToUpper(letter, s_culture) - char.ToUpper(settings.Shift, s_culture) + letterNum) % letterNum) + 'A');
		//}

		///// <summary>
		///// Decipher ciphertext into plaintext using the specified shift.
		///// </summary>
		///// <param name="ciphertext">The ciphertext to decipher.</param>
		///// <param name="settings">The settings used to decipher.</param>
		///// <returns>The plaintext.</returns>
		//internal static string Decipher(string ciphertext, CaesarSettings settings)
		//{
		//    if (ciphertext == null)
		//    {
		//        throw new ArgumentNullException("ciphertext");
		//    }

		//    StringBuilder plaintext = new StringBuilder(ciphertext.Length);

		//    //Encipher the string
		//    for (int i = 0; i < ciphertext.Length; i++)
		//    {
		//        plaintext.Append(Decipher(ciphertext[i], settings));
		//    }

		//    //Return the enciphered string
		//    return plaintext.ToString();
		//}
        #endregion

        #region Crack
		///// <summary>
		///// Cracks ciphertext into plaintext.
		///// </summary>
		///// <param name="ciphertext">The ciphertext to crack.</param>
		///// <returns>The plaintext.</returns>
		//internal static char Crack(string ciphertext)
		//{
		//    if (ciphertext == null)
		//    {
		//        throw new ArgumentNullException("ciphertext");
		//    }

		//    char shift;

		//    float pseudoFrequencyBest = float.MaxValue; ;	// Lowest standard deviation for the pseudo shifts
		//    int psuedoShiftBest = 0;						// Phantom shift - as we have to test them all
		//    int pseudoShift;								// The current psuedo shift
		//    int[] pseudoFrequency = new int[letterNum];	// Frequency with the pseudo shift
		//    float[] freqPerc;			// Frequency percentages
		//    float[] freqDiff;			// Frequncy differences (freq - freq table)
		//    float[] frequencyTable;		// Get English letter frequencies
		//    float stdDev;				// Standard Deviation  
		//    Letters letters = new Letters();

		//    letters.LoadLetterFrequencies();
		//    frequencyTable = letters.GetLetterFrequencies();

		//    ciphertext = ciphertext.ToUpper(s_culture);

		//    //Add the textbox to the freq table
		//    AddText(ciphertext);

		//    for (pseudoShift = 0; pseudoShift < letterNum; pseudoShift++)
		//    {
		//        //Do a pseudo frequency shift
		//        for (int i = 0; i < letterNum; i++)
		//        {
		//            pseudoFrequency[(pseudoShift + i) % letterNum] = frequency[i];
		//        }

		//        //Calculate the frequency percentage
		//        freqPerc = Statistics.CalcFrequencyPercentages(pseudoFrequency);

		//        //Calculate the frequency difference
		//        freqDiff = Statistics.CalcFrequencyDifferences(freqPerc, frequencyTable);

		//        //Calculate the standard deviation
		//        stdDev = Statistics.StandardDeviation(freqDiff);

		//        //Is this the lowest standard deviation?
		//        if (stdDev < pseudoFrequencyBest)
		//        {
		//            pseudoFrequencyBest = stdDev;
		//            psuedoShiftBest = pseudoShift;
		//        }
		//    }

		//    if (psuedoShiftBest == 0)
		//    {
		//        shift = 'A';
		//    }
		//    else
		//    {
		//        shift = (char)('A' + (letterNum - psuedoShiftBest));
		//    }

		//    return shift;
		//}
        #endregion

		///// <summary>
		///// Add a text to the frequency table and letter count.  Note: these will be cleared prior to the addition.
		///// </summary>
		///// <param name="ciphertext">The text to add to the frequence table and letter count.</param>
		//private static void AddText(string ciphertext)
		//{
		//    // Clear the letter count
		//    letterCount = 0;

		//    // Clear the frequency table
		//    Array.Clear(frequency, 0, letterNum);

		//    //Add the letters to the frequency table
		//    for (int i = 0; i < ciphertext.Length; i++)
		//    {
		//        if (char.IsLetter(ciphertext[i]))
		//        {
		//            //add the to letter's frequency
		//            frequency[ciphertext[i] % 'A']++;

		//            //increment the letter count
		//            letterCount++;
		//        }
		//    }
		//}

        #region IDisposable Members

		/// <summary>
		/// Releases all resources used by this object.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		public static void Dispose(bool disposing)
		{
			// A call to Dispose(false) should only clean up native resources. 
			// A call to Dispose(true) should clean up both managed and native resources.
			if (disposing)
			{
			}
		}

        #endregion
    }
}
