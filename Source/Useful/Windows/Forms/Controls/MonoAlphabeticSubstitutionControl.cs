//-----------------------------------------------------------------------
// <copyright file="MonoAlphabeticSubstitutionControl.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>The Monoalphabetic algorithm settings Windows control for a substitution.</summary>
//-----------------------------------------------------------------------

namespace Useful.Windows.Forms.Controls.Cryptography
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Windows.Forms;
    using Useful.Security.Cryptography;

    /// <summary>
    /// The Monoalphabetic algorithm settings Windows control for a substitution.
    /// </summary>
    public partial class MonoAlphabeticSubstitutionControl : UserControl
    {
        #region Fields
        /// <summary>
        /// The letter this control is currently set to.
        /// </summary>
        private char letter;

        /// <summary>
        /// The underlying settings.
        /// </summary>
        private MonoAlphabeticSettings settings;

        /// <summary>
        /// States if the settings have changed.
        /// </summary>
        private bool settingsChanged;

        /// <summary>
        /// States if this object has been disposed.
        /// </summary>
        private bool isDisposed;
        #endregion

        #region ctor
        /// <summary>
        /// Initializes a new instance of the MonoAlphabeticSubstitutionControl class.
        /// Default constructor.
        /// Do not use!
        /// Only for the Form Designer
        /// </summary>
        public MonoAlphabeticSubstitutionControl()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the MonoAlphabeticSubstitutionControl class.
        /// </summary>
        /// <param name="settings">The settings to base the controls setting on.</param>
        /// <param name="letter">Which substitution letter this control is displaying.</param>
        public MonoAlphabeticSubstitutionControl(MonoAlphabeticSettings settings, char letter)
            : this()
        {
            Extensions.CheckNullArgument(() => settings);

            this.settings = settings;

            this.letter = letter;

            this.settings.SettingsChanged += new EventHandler<EventArgs>(this.Settings_SettingsChanged);
            this.Settings_SettingsChanged(this, EventArgs.Empty);
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
                    if (this.settings != null)
                    {
                        this.settings.SettingsChanged -= new EventHandler<EventArgs>(this.Settings_SettingsChanged);
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

        private void Settings_SettingsChanged(object sender, EventArgs e)
        {
            this.settingsChanged = true;
            this.SuspendLayout();
            this.SetFrom();
            this.SetTo();
            this.ResumeLayout(false);
            this.settingsChanged = false;
        }

        private void SetFrom()
        {
            this.textFrom.Text = this.letter.ToString();
        }

        private void SetTo()
        {
            ////if (!this.m_settings.IsCleanable(this.m_letter))
            ////{
            ////    return;
            ////}

            if (this.comboTo.Items != null && this.comboTo.Items.Count == 0)
            {
                foreach (char allowedLetter in this.settings.AllowedLetters)
                {
                    this.comboTo.Items.Add(allowedLetter);
                }
            }

            this.comboTo.SelectedItem = this.settings.GetSubstitution(this.letter);
        }

        private void ComboTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.settingsChanged)
            {
                SubstitutionPair subs = new SubstitutionPair(this.letter, (char)this.comboTo.SelectedItem);
                this.settings.SetSubstitution(subs);
            }
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.settings != null);
            Contract.Invariant(this.comboTo != null);
            Contract.Invariant(this.textFrom != null);
            Contract.Invariant(this.comboTo.SelectedItem != null);
        }

        #endregion
    }
}
