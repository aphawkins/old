using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

using Useful.Security.Cryptography;

namespace Useful.Windows.Forms.Controls
{
    /// <summary>
    /// A Windows control that handles the settings for the Caesar cipher.
    /// </summary>
    public partial class CaesarSettingsControl : CipherSettingsControl
    {
        private Useful.Security.Cryptography.CaesarSettings settings;

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public CaesarSettingsControl()
            : base(typeof(Useful.Security.Cryptography.Caesar), new Useful.Security.Cryptography.CaesarSettings('A'))
        {
            InitializeComponent();

			this.settings = (Useful.Security.Cryptography.CaesarSettings)this.Settings;

            //Populate the shift
            this.comboShift.Items.Clear();
			foreach (char allowedLetter in this.settings.AllowedLetters)
            {
				this.comboShift.Items.Add(allowedLetter);
            }
            this.comboShift.Text = this.settings.Shift.ToString();
        }

        private void comboShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.settings.Shift = this.comboShift.Text[0];
        }
    }
}
