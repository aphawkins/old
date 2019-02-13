//-----------------------------------------------------------------------
// <copyright file="MonoAlphabeticSettingsControl.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>The Monoalphabetic algorithm settings Windows control.</summary>
//-----------------------------------------------------------------------

namespace Useful.Windows.Forms.Controls.Cryptography
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Windows.Forms;
    using Useful.Security.Cryptography;

    /// <summary>
    /// The Monoalphabetic algorithm settings Windows control.
    /// </summary>
    public partial class MonoAlphabeticSettingsControl : CipherSettingsControl
    {
        /// <summary>
        /// An instance of this control.
        /// </summary>
        private static MonoAlphabeticSettingsControl staticInstance = GetControl();

        /// <summary>
        /// States if this object has been disposed.
        /// </summary>
        private bool isDisposed;

        #region ctor
        /// <summary>
        /// Initializes a new instance of the MonoAlphabeticSettingsControl class.
        /// Default constructor.
        /// Do not use!
        /// Only for the Form Designer.
        /// </summary>
        public MonoAlphabeticSettingsControl()
            : base()
        {
            this.Cipher = new Useful.Security.Cryptography.MonoAlphabetic();

            Contract.Assume(this.Cipher.Key != null);
            Contract.Assume(this.Cipher.IV != null);

            this.Settings = new MonoAlphabeticSettings(this.Cipher.Key, this.Cipher.IV);
            //// MonoAlphabeticSettingsControl.CipherName = this.Settings.CipherName;

            this.Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the MonoAlphabeticSettingsControl class.
        /// </summary>
        /// <param name="settings">The setting this control uses to get its data from.</param>
        public MonoAlphabeticSettingsControl(MonoAlphabeticSettings settings)
            : base()
        {
            Contract.Requires(settings != null);

            this.Settings = settings;
            this.Cipher = new Useful.Security.Cryptography.MonoAlphabetic();
            this.Cipher.Key = settings.GetKey();
            this.Cipher.IV = settings.GetIV();

            this.Initialize();
        }
        #endregion

        #region Fields
        #endregion

        #region Properties
        /// <summary>
        /// Gets the name of the cipher.
        /// </summary>
        public static new string CipherName
        {
            get
            {
                return MonoAlphabeticSettingsControl.staticInstance.Settings.CipherName;
            }
        }
        #endregion

        #region Methods
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
                    if (this.Settings != null)
                    {
                        this.Settings.SettingsChanged -= new EventHandler<EventArgs>(Settings_SettingsChanged);
                    }

                    if (this.flowLayoutPanel1 != null && this.flowLayoutPanel1.Controls != null)
                    {
                        foreach (Control control in this.flowLayoutPanel1.Controls)
                        {
                            control.Dispose();
                        }

                        this.flowLayoutPanel1.Controls.Clear();
                    }

                    ////if (this.components != null)
                    ////{
                    ////    this.components.Dispose();
                    ////}
                }
            }
            finally
            {
                base.Dispose(disposing);
            }

            this.isDisposed = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static MonoAlphabeticSettingsControl GetControl()
        {
            return new MonoAlphabeticSettingsControl();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Initialize()
        {
            this.InitializeComponent();

            this.SuspendLayout();

            this.Settings.SettingsChanged += new EventHandler<EventArgs>(Settings_SettingsChanged);

            Settings_SettingsChanged(this, EventArgs.Empty);

            MonoAlphabeticSettings settings = (MonoAlphabeticSettings)this.Settings;

            foreach (char letter in settings.AllowedLetters)
            {
                MonoAlphabeticSubstitutionControl control = new MonoAlphabeticSubstitutionControl(settings, letter);

                control.Name = "MonoAlphabeticSubstitutionControl_" + letter.ToString();

                this.flowLayoutPanel1.Controls.Add(control);
            }

            this.ResumeLayout(false);
        }
        #endregion
    }
}
