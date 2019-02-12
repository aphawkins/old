//-----------------------------------------------------------------------
// <copyright file="EnigmaRotorControl.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>An Enigma Rotor Windows control.</summary>
//-----------------------------------------------------------------------

namespace Useful.Windows.Forms.Controls.Cryptography
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Forms;
    using Useful.Security.Cryptography;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// An Enigma Rotor Windows control.
    /// </summary>
    public partial class EnigmaRotorControl : UserControl
    {
        #region Fields
        /// <summary>
        /// The positon of the rotor.
        /// </summary>
        private EnigmaRotorPosition rotorPosition;

        /// <summary>
        /// States if the setting have changed.
        /// </summary>
        private bool settingsChanged;

        /// <summary>
        /// The current settings.
        /// </summary>
        private EnigmaSettings settings;

        /// <summary>
        /// States if this object has been disposed.
        /// </summary>
        private bool isDisposed;
        #endregion
        
        #region ctor
        /// <summary>
        /// Initializes a new instance of the EnigmaRotorControl class.
        /// Default constructor.
        /// Do not use!
        /// Only for the Form Designer
        /// </summary>
        public EnigmaRotorControl()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the EnigmaRotorControl class.
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="rotorPosition"></param>
        public EnigmaRotorControl(EnigmaSettings settings, EnigmaRotorPosition rotorPosition)
            : this()
        {
            Extensions.CheckNullArgument(() => settings);

            this.settings = settings;
         
            this.labelRotor1.Text = EnigmaUINameConverter.Convert(rotorPosition);
            this.rotorPosition = rotorPosition;

            this.settings.SettingsChanged += new EventHandler<EventArgs>(this.Settings_SettingsChanged);
            this.Settings_SettingsChanged(this, EventArgs.Empty);           
        }
        #endregion

        #region Properties
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
                // A call to Dispose(false) should only clean up native resources. 
                // A call to Dispose(true) should clean up both managed and native resources.
                if (disposing)
                {
                    // Dispose managed resources
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
                // Free native resources
                base.Dispose(disposing);
            }

            this.isDisposed = true;
        }

        private static void AddRotors(System.Windows.Forms.ComboBox combo, Collection<EnigmaRotorNumber> rotors, EnigmaRotorNumber selectedRotor)
        {
            Contract.Requires(combo != null);
            Contract.Requires(rotors != null);

            combo.Items.Clear();

            foreach (EnigmaRotorNumber rotor in rotors)
            {
                combo.Items.Add(EnigmaUINameConverter.Convert(rotor));
            }

            combo.SelectedItem = EnigmaUINameConverter.Convert(selectedRotor);
        }
        
        private void Settings_SettingsChanged(object sender, EventArgs e)
        {
            this.settingsChanged = true;
            this.SetRotors();
            this.SetPositions();
            this.settingsChanged = false;
        }

        private void ComboRotor1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Contract.Requires(this.comboRotor1 != null);
            Contract.Requires(this.comboRotor1.SelectedItem != null);
            Contract.Requires(this.settings != null);
            Contract.Requires(this.comboRotor1.SelectedItem.ToString().Length > 0);

            if (!this.settingsChanged)
            {
                this.settings.SetRotorOrder(this.rotorPosition, EnigmaUINameConverter.Convert(this.comboRotor1.SelectedItem.ToString()));
            }
        }

        private void ComboInitialPosition1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Contract.Requires(this.comboInitialPosition1 != null);
            Contract.Requires(this.comboInitialPosition1.SelectedItem != null);
            Contract.Requires(this.settings != null);
            Contract.Requires(0 < this.comboInitialPosition1.SelectedItem.ToString().Length);

            if (!this.settingsChanged)
            {
                this.settings.SetRotorSetting(this.rotorPosition, this.comboInitialPosition1.SelectedItem.ToString()[0]);
            }
        }

        private void SetRotors()
        {
            Contract.Requires(this.settings != null);
            Contract.Requires(this.comboRotor1 != null);

            // TODO: Make two separate function calls here?
            // Available
            AddRotors(this.comboRotor1, this.settings.AvailableRotors(this.rotorPosition), this.settings.GetRotorOrder(this.rotorPosition));
        }

        private void SetPositions()
        {
            Contract.Requires(this.comboInitialPosition1 != null);
            Contract.Requires(this.settings != null);

            this.comboInitialPosition1.Items.Clear();
            Collection<char> allowedLetters = EnigmaRotor.GetAllowedLetters(this.settings.GetRotorOrder(this.rotorPosition));
            if (allowedLetters != null)
            {
                foreach (char letter in allowedLetters)
                {
                    this.comboInitialPosition1.Items.Add(letter);
                }
            }

            // Initial Values
            if (this.settings.GetRotorOrder(this.rotorPosition) != EnigmaRotorNumber.None)
            {
                this.comboInitialPosition1.SelectedItem = this.settings.GetRotorSetting(this.rotorPosition);
            }
        }
        #endregion
    }
}