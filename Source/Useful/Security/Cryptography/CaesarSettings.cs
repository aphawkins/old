using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.ObjectModel;

namespace Useful.Security.Cryptography
{
	/// <summary>
	/// Accesses the Caesar Shift algorithm settings.
	/// </summary>
	public class CaesarSettings : ISymmetricCipherSettings
	{
        private char m_shift;
        private byte[] m_key;
        private byte[] m_iv;
        private Collection<char> m_allowedLetters;

		/// <summary>
		/// Initializes a new instance of this class.
		/// </summary>
		/// <param name="shift">The shift used to encipher.</param>
		public CaesarSettings(char shift)
		{
            this.m_allowedLetters = Letters.CaesarLetters;
			this.Shift = shift;
		}

		/// <summary>
		/// Initializes a new instance of this class.
		/// </summary>
		/// <param name="key">The encryption Key.</param>
		/// <param name="iv">The Initialization Vector.</param>
		public CaesarSettings(byte[] key, byte[] iv)
		{
			this.SetKey(key);
			this.SetIV(iv);
		}

		/// <summary>
		/// The shift used to encipher.
		/// </summary>
        public char Shift
        {
            get
            {
                return this.m_shift;
            }
            set
            {
                // Not an allowed letter?
                if (!(this.m_allowedLetters.Contains(value)))
                {
                    throw new CryptographicException("This is not an allowed letter.");
                }

                this.m_shift = value;
                // Allow for upper and lower case key char.
                this.m_key = Encoding.Unicode.GetBytes(new char[] { value });  // - 33) % 32;

                OnSettingsChanged();
            }
        }

		private void OnSettingsChanged()
		{
			if (this.SettingsChanged != null)
			{
				this.SettingsChanged(this, new EventArgs());
			}
		}

		#region ISymmetricCipherSettings Members

		/// <summary>
		/// Get the Initialization Vector.
		/// </summary>
		/// <returns></returns>
		public byte[] GetIV()
		{
			return this.m_iv;
		}

		/// <summary>
		/// Set the Initialization Vector.
		/// </summary>
		public void SetIV(byte[] iv)
		{
			this.m_iv = iv;

			OnSettingsChanged();
		}

		/// <summary>
		/// Get the encryption Key.
		/// </summary>
		/// <returns></returns>
		public byte[] GetKey()
		{
			return this.m_key;
		}

		/// <summary>
		/// Set the encryption Key.
		/// </summary>
		public void SetKey(byte[] key)
		{
			this.m_shift = Encoding.Unicode.GetChars(key)[0];
			this.m_key = key;

			OnSettingsChanged();
		}

		/// <summary>
		/// The letters that can be used in this cipher
		/// </summary>
		public Collection<char> AllowedLetters
		{
			get
			{
				return this.m_allowedLetters;
			}
		}

		/// <summary>
		/// Raised when the settings are changed.
		/// </summary>
		public event EventHandler<EventArgs> SettingsChanged;

        /// <summary>
        /// The name of this cipher
        /// </summary>
        public string CipherName
        {
            get
            {
                return "Caesar Shift";
            }
        }

		#endregion
	}
}
