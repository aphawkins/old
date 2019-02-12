//-----------------------------------------------------------------------
// <copyright file="CipherSettingsControl.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>A Windows base control that handles the settings for ciphers.</summary>
//-----------------------------------------------------------------------

namespace Useful.Windows.Forms.Controls.Cryptography
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Security.Cryptography;
    using System.Windows.Forms;

    /// <summary>
    /// A Windows base control that handles the settings for ciphers.
    /// </summary>
    public partial class CipherSettingsControl : UserControl
    {
        #region Fields
        /// <summary>
        /// States if this object's settings have been changed.
        /// </summary>
        private bool haveSettingsChanged;

        /// <summary>
        /// States if this object been disposed.
        /// </summary>
        private bool isDisposed;
        #endregion

        #region ctor
        /// <summary>
        /// Initializes a new instance of the CipherSettingsControl class.
        /// Required for VS.WinForms designer
        /// </summary>
        internal CipherSettingsControl()
        {
            this.InitializeComponent();

            this.SettingsChanged += new EventHandler<EventArgs>(this.Control_SettingsChanged);
        }
        #endregion

        #region Events
        /// <summary>
        /// Raised when the settings change.
        /// </summary>
        internal event EventHandler<EventArgs> SettingsChanged;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the name of the cipher.
        /// </summary>
        public string CipherName { get; set; }

        /// <summary>
        /// Gets or sets the cipher.
        /// </summary>
        public SymmetricAlgorithm Cipher { get; set; }

        // internal static CipherSettingsControl StaticInstance { get; set; }
        internal Useful.Security.Cryptography.ISymmetricCipherSettings Settings { get; set; }
        #endregion

        #region Methods
        internal void OnSettingsChanged()
        {
            if (this.SettingsChanged != null)
            {
                this.SettingsChanged(this, EventArgs.Empty);
            }
        }

        internal void Control_SettingsChanged(object sender, EventArgs e)
        {
            if (this.haveSettingsChanged)
            {
                return;
            }

            this.haveSettingsChanged = true;
            byte[] key = this.Cipher.Key;
            byte[] iv = this.Cipher.IV;

            if (key == null)
            {
                throw new CryptographicException();
            }

            if (iv == null)
            {
                throw new CryptographicException();
            }

            this.Settings.SetKey(key);
            this.Settings.SetIV(iv);
            this.haveSettingsChanged = false;
        }

        internal void Settings_SettingsChanged(object sender, EventArgs e)
        {
            if (this.haveSettingsChanged)
            {
                return;
            }

            this.haveSettingsChanged = true;
            this.Cipher.Key = this.Settings.GetKey();
            this.Cipher.IV = this.Settings.GetIV();
            this.haveSettingsChanged = false;

            // this.OnSettingsChanged();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (this.isDisposed)
            {
                return;
            }

            try
            {
                if (disposing)
                {
                }
            }
            finally
            {
                base.Dispose(disposing);
            }

            this.isDisposed = true;
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.CipherName != null);
            Contract.Invariant(this.Cipher != null);
            Contract.Invariant(this.Settings != null);
        }
        #endregion
    }
}
