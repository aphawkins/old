//-----------------------------------------------------------------------
// <copyright file="CryptographyForm.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>A Windows form that handles the crytography.</summary>
//-----------------------------------------------------------------------

namespace Useful.Windows.Forms
{
    using System;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Windows.Forms;
    using Useful.Security.Cryptography;
    using Useful.Text;
    using Useful.Windows.Forms.Controls;
    using Useful.Windows.Forms.Controls.Cryptography;

    /// <summary>
    /// A Windows form that handles the crytography.
    /// </summary>
    public partial class CryptographyForm : Form
    {
        /// <summary>
        /// The ciphers available in the project.
        /// </summary>
        private System.Collections.Generic.Dictionary<string, Type> ciphers;

        /// <summary>
        /// The cipher setting control.
        /// </summary>
        private CipherSettingsControl settingsControl;

        private string ciphertext;

        private string plaintext;

        private About aboutFrame;

        /// <summary>
        /// Initializes a new instance of the CryptographyForm class.
        /// </summary>
        public CryptographyForm()
        {
            Contract.Ensures(this.settingsControl != null);

            this.aboutFrame = new About();
            this.InitializeComponent();

            this.Text = AssemblyInformation.Title;

            this.ciphers = new System.Collections.Generic.Dictionary<string, Type>();

            Assembly ass = Assembly.GetAssembly(this.GetType());
            Type[] types = ass.GetTypes();
            foreach (Type type in types)
            {
                if (type == null || type.BaseType != typeof(CipherSettingsControl))
                {
                    continue;
                }

                PropertyInfo propInfo = type.GetProperty("CipherName", BindingFlags.FlattenHierarchy | BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Static);
                MethodInfo methodInfo = propInfo.GetGetMethod();
                string cipherName = (string)methodInfo.Invoke(null, null);

                Contract.Assume(!this.comboCiphers.Items.Contains(cipherName));
                this.comboCiphers.Items.Add(cipherName);
                this.ciphers.Add(cipherName, type);

                if (this.settingsControl == null)
                {
                    this.settingsControl = (CipherSettingsControl)Activator.CreateInstance(type);
                }
            }

            Contract.Assert(this.settingsControl != null);
            this.settingsControl.Location = new System.Drawing.Point(3, 3);
            this.settingsControl.Name = "Settings1";
            //// this.m_settingsControl.Size = new System.Drawing.Size(161, 37);
            this.settingsControl.TabIndex = 3;
            this.settingsControl.Dock = DockStyle.Fill;
            this.panelCipherSettings.Controls.Add(this.settingsControl);

            this.comboCiphers.SelectedIndex = 0;

            this.comboEncoding.Items.AddRange(EncodingStrings.Encodings.Keys.ToArray<string>());
            this.comboEncoding.SelectedIndex = 1;

#if DEBUG && !CODE_ANALYSIS
            this.textInputFile.Text = "Z:\\Programming\\Useful\\TestFiles\\Mono_Plaintext_UTF8_BOM.txt";
            this.textOutputFile.Text = "Z:\\Programming\\Useful\\TestFiles\\Mono_Ciphertext.txt";
#endif
        }

        private static void ExceptionHandler(Control owner, Exception ex)
        {
            Contract.Requires(owner != null);
            Contract.Requires(ex != null);

            // TODO: A proper error box
            // #if DEBUG
            //            throw(ex);
            // #else
            MessageBox.Show(
                ex.ToString(),
                ex.Message,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                owner.RightToLeft == RightToLeft.Yes ? MessageBoxOptions.ServiceNotification | MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading : MessageBoxOptions.ServiceNotification);

            // #endif
        }

        private static void ExceptionHandler(Control owner, ErrorCode error)
        {
            Contract.Requires(owner != null);

            // TODO: A proper error box
            // #if DEBUG
            //            throw(ex);
            // #else
            MessageBox.Show(
                ErrorManager.GetMessage(error),
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                owner.RightToLeft == RightToLeft.Yes ? MessageBoxOptions.ServiceNotification | MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading : MessageBoxOptions.ServiceNotification);

            // #endif
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            ////Contract.Invariant(this.textPlaintext != null);
            ////Contract.Invariant(this.buttonEncipher != null);
            ////Contract.Invariant(this.textCiphertext != null);
            ////Contract.Invariant(this.buttonDecipher != null);
            ////Contract.Invariant(this.panelCipherSettings != null);
            ////Contract.Invariant(this.labelCiphers != null);
            ////Contract.Invariant(this.comboCiphers != null);
            ////Contract.Invariant(this.textBox1 != null);
            ////Contract.Invariant(this.button1 != null);
            ////Contract.Invariant(this.panel2 != null);
            ////Contract.Invariant(this.label1 != null);
            ////Contract.Invariant(this.label2 != null);
            ////Contract.Invariant(this.buttonRandomize != null);
            ////Contract.Invariant(this.settingsControl != null);
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string Encipher(string plaintext)
        {
            Contract.Requires(this.textPlaintext != null);
            Contract.Requires(this.textPlaintext.Text != null);
            Contract.Requires(!this.textPlaintext.Text.Contains("\0"));
            Contract.Requires(this.settingsControl != null);
            Contract.Requires(this.settingsControl.Cipher != null);
            Contract.Requires(this.textCiphertext != null);

            string result = CipherMethods.DoCipher(this.settingsControl.Cipher, CipherTransformMode.Encrypt, plaintext);
            this.settingsControl.OnSettingsChanged();
            return result;
        }

        private string Decipher(string ciphertext)
        {
            Contract.Requires(this.textCiphertext != null);
            Contract.Requires(this.textCiphertext.Text != null);
            Contract.Requires(!this.textCiphertext.Text.Contains("\0"));
            Contract.Requires(this.settingsControl != null);
            Contract.Requires(this.settingsControl.Cipher != null);

            CipherTransformMode transformMode = CipherTransformMode.Decrypt;

            string result = CipherMethods.DoCipher(this.settingsControl.Cipher, transformMode, ciphertext);
            this.settingsControl.OnSettingsChanged();
            return result;
        }

        private void ComboCiphers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Contract.Requires(this.ciphers != null);

            ////this.ResumeLayout(true);
            this.panelCipherSettings.Controls.Remove(this.settingsControl);
            Contract.Assume(this.ciphers[(string)this.comboCiphers.SelectedItem] != null);
            object cipher = Activator.CreateInstance(this.ciphers[(string)this.comboCiphers.SelectedItem]);
            Contract.Assert(cipher != null);
            this.settingsControl = (CipherSettingsControl)cipher;
            this.settingsControl.Dock = DockStyle.Fill;
            this.panelCipherSettings.Controls.Add(this.settingsControl);
            this.panelCipherSettings.Refresh();

            ////this.ResumeLayout(false);
        }

        private void Randomize(object sender, EventArgs e)
        {
            Contract.Requires(this.settingsControl != null);

            this.settingsControl.Cipher.GenerateKey();
            this.settingsControl.Cipher.GenerateIV();

            this.settingsControl.OnSettingsChanged();
        }

        private void ButtonBrowsePlaintext_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.InitialDirectory = Path.GetDirectoryName(this.textInputFile.Text);
            this.openFileDialog1.FileName = Path.GetFileName(this.textInputFile.Text);

            DialogResult dialog = this.openFileDialog1.ShowDialog();
            if (dialog == System.Windows.Forms.DialogResult.OK)
            {
                this.textInputFile.Text = this.openFileDialog1.FileName;
            }
        }

        private void ButtonBrowseCiphertext_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.InitialDirectory = Path.GetDirectoryName(this.textOutputFile.Text);
            this.saveFileDialog1.FileName = Path.GetFileName(this.textOutputFile.Text);

            DialogResult dialog = this.saveFileDialog1.ShowDialog();
            if (dialog == System.Windows.Forms.DialogResult.OK)
            {
                this.textOutputFile.Text = this.saveFileDialog1.FileName;
            }
        }

        private void ButtonFileEncipher_Click(object sender, EventArgs e)
        {
            this.DoCipher(CipherTransformMode.Encrypt);
        }

        private void ButtonFileDecipher_Click(object sender, EventArgs e)
        {
            this.DoCipher(CipherTransformMode.Decrypt);
        }

        private void DoCipher(CipherTransformMode transformMode)
        {
            ErrorCode error = CipherMethods.DoCipher(
                this.settingsControl.Cipher,
                transformMode,
                this.textInputFile.Text,
                this.textOutputFile.Text,
                this.GetEncoding());

            if (error == ErrorCode.None)
            {
                MessageBox.Show(
                    this,
                    Resource.Finished,
                    (transformMode == CipherTransformMode.Encrypt ? Resource.EncryptionComplete : Resource.DecryptionComplete),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    this.RightToLeft == RightToLeft.Yes ? MessageBoxOptions.ServiceNotification | MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading : MessageBoxOptions.ServiceNotification);
            }
            else
            {
                ExceptionHandler(this, error);
            }
        }

        private Encoding GetEncoding()
        {
            return EncodingStrings.Encodings[(string)this.comboEncoding.SelectedItem];
        }

        private void ButtonAbout_Click(object sender, EventArgs e)
        {
            this.aboutFrame.Dock = DockStyle.Fill;
            this.aboutFrame.BringToFront();
            this.aboutFrame.Show();
        }
      
        private void TextPlaintext_TextChanged(object sender, EventArgs e)
        {
            if (!string.Equals(this.plaintext, this.textPlaintext.Text))
            {
                this.plaintext = this.textPlaintext.Text;
                this.ciphertext = this.Encipher(this.plaintext);
                this.textCiphertext.Text = this.ciphertext;
            }
        }

        private void TextCiphertext_TextChanged(object sender, System.EventArgs e)
        {
            if (!string.Equals(this.ciphertext, this.textCiphertext.Text))
            {
                this.ciphertext = this.textCiphertext.Text;
                this.plaintext = this.Encipher(this.ciphertext);
                this.textPlaintext.Text = this.plaintext;
            }
        }
    }
}