//-----------------------------------------------------------------------
// <copyright file="EnigmaSettingsControl.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>The Enigma algorithm settings Windows control.</summary>
//-----------------------------------------------------------------------

namespace Useful.Windows.Forms.Controls.Cryptography
{
    using System;
    using System.Linq;
    using System.Windows.Forms;

    using Useful.Security.Cryptography;

    /// <summary>
    /// The Enigma algorithm settings Windows control.
    /// </summary>
    public partial class EnigmaSettingsControl : CipherSettingsControl
    {
        /// <summary>
        /// An instance of this object.
        /// </summary>
        private static EnigmaSettingsControl staticInstance = GetControl();

        /// <summary>
        /// States if this object has been disposed.
        /// </summary>
        private bool isDisposed;
        
        #region ctor
        /// <summary>
        /// Initializes a new instance of the EnigmaSettingsControl class.
        /// </summary>
        public EnigmaSettingsControl()
            : base()
        {
            this.InitializeComponent();

            this.Cipher = new Useful.Security.Cryptography.Enigma();

            this.Settings = new EnigmaSettings(this.Cipher.Key, this.Cipher.IV);

            EnigmaSettings settings = (EnigmaSettings)this.Settings;

            this.SuspendLayout();

            var rotorPositionDesc = from position in settings.AllowedRotorPositions 
                    orderby position descending 
                    select position;

            foreach (EnigmaRotorPosition rotorPosition in rotorPositionDesc)
            {
                Useful.Windows.Forms.Controls.Cryptography.EnigmaRotorControl enigmaRotorControl = new Useful.Windows.Forms.Controls.Cryptography.EnigmaRotorControl(settings, rotorPosition);
                enigmaRotorControl.Name = "enigmaRotorControl_" + EnigmaUINameConverter.Convert(rotorPosition);

                this.flowLayoutPanel1.Controls.Add(enigmaRotorControl);
            }

            this.monoAlphabeticSettingsControl1 = new MonoAlphabeticSettingsControl(settings.Plugboard);
            this.monoAlphabeticSettingsControl1.Anchor = (System.Windows.Forms.AnchorStyles)
                (System.Windows.Forms.AnchorStyles.Top 
                | System.Windows.Forms.AnchorStyles.Bottom
                | System.Windows.Forms.AnchorStyles.Left
                | System.Windows.Forms.AnchorStyles.Right);
            this.monoAlphabeticSettingsControl1.Location = new System.Drawing.Point(3, 119);
            this.monoAlphabeticSettingsControl1.Name = "monoAlphabeticSettingsControl1";
            this.monoAlphabeticSettingsControl1.Size = new System.Drawing.Size(700, 244);
            this.monoAlphabeticSettingsControl1.TabIndex = 34;
            this.Controls.Add(this.monoAlphabeticSettingsControl1);

            ////this.monoAlphabeticSettingsControl1.Settings.SettingsChanged += new EventHandler<EventArgs>(monoAlphabeticSettingsControl1_SettingsChanged);
            ////this.monoAlphabeticSettingsControl1.SettingsChanged += new EventHandler<EventArgs>(monoAlphabeticSettingsControl1_SettingsChanged);

            this.ResumeLayout(false);

            this.Settings.SettingsChanged += new EventHandler<EventArgs>(Settings_SettingsChanged);

            Settings_SettingsChanged(this, EventArgs.Empty);
        }

        ////private void monoAlphabeticSettingsControl1_SettingsChanged(object sender, EventArgs e)
        ////{
        ////    ((EnigmaSettings)Settings).SetPlugboardNew(((MonoAlphabeticSettings)this.monoAlphabeticSettingsControl1.Settings).Substitutions);

        ////    // Settings_SettingsChanged(sender, e);
        ////}

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
                return EnigmaSettingsControl.staticInstance.Settings.CipherName;
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

                    if (this.flowLayoutPanel1 != null)
                    {
                        foreach (Control control in this.flowLayoutPanel1.Controls)
                        {
                            control.Dispose();
                        }
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
        private static EnigmaSettingsControl GetControl()
        {
            return new EnigmaSettingsControl();
        }
        #endregion
    }
}
