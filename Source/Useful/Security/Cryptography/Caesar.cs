using System;
using System.Text;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Globalization;

using Useful;

namespace Useful.Security.Cryptography
{
    /// <summary>
    /// Accesses the Caesar Shift algorithm.
    /// </summary>
	public sealed class Caesar : SymmetricAlgorithm
	{
		//CaesarSettings settings;

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
		public Caesar() : base()
		{
			Reset();
        }

        #region Public

        /// <summary>
        /// Creates a symmetric decryptor object.
        /// </summary>
        /// <param name="rgbKey">The secret key to use for the symmetric algorithm.</param>
        /// <param name="rgbIV">The initialization vector to use for the symmetric algorithm.</param>
        /// <returns>The symmetric decryptor object.</returns>
        public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV)
        {
            return new CaesarTransform(rgbKey, CipherTransformMode.Decrypt);
        }

        /// <summary>
        /// Creates a symmetric encryptor object.
        /// </summary>
        /// <param name="rgbKey">The secret key to use for the symmetric algorithm.</param>
        /// <param name="rgbIV">The initialization vector to use for the symmetric algorithm.</param>
        /// <returns>The symmetric encryptor object.</returns>
        public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV)
        {
            return new CaesarTransform(rgbKey, CipherTransformMode.Encrypt);
        }

        /// <summary>
        /// Generates a random initialization vector (IV) to use for the algorithm.
        /// </summary>
        public override void GenerateIV()
        {
            try
            {
                this.IVValue = CipherMethods.GetRandomBytes(1);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Generates a random key to be used for the algorithm.
        /// </summary>
        public override void GenerateKey()
        {
            try
            {
                this.KeyValue = CipherMethods.GetRandomBytes(1);
            }
            catch
            {
                throw;
            }
        }

		///// <summary>
		///// Cracks ciphertext into plaintext.
		///// </summary>
		///// <param name="ciphertext">The ciphertext to crack.</param>
		///// <returns>The plaintext.</returns>
		//public static char Crack(string ciphertext)
		//{
		//    return CaesarTransform.Crack(ciphertext);
		//}

		#endregion

		#region Private

		private void Reset()
		{
			ModeValue = CipherMode.ECB;
			PaddingValue = PaddingMode.None;
            KeySizeValue = 16;
            BlockSizeValue = 16;
            FeedbackSizeValue = 16;
            LegalBlockSizesValue = new KeySizes[1];
            LegalBlockSizesValue[0] = new KeySizes(16, 16, 16);
            LegalKeySizesValue = new KeySizes[1];
            LegalKeySizesValue[0] = new KeySizes(16, 16, 16);
			
            GenerateKey();
			GenerateIV();
        }

        #endregion
	}
}
