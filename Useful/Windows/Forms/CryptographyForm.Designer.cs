//-----------------------------------------------------------------------
// <copyright file="CryptographyForm.Designer.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>A Windows form for doing encryption.</summary>
//-----------------------------------------------------------------------

namespace Useful.Windows.Forms
{
    using System.Windows.Forms;
    using Useful.Windows.Forms.Controls;

    /// <summary>
    /// A Windows form for doing encryption.
    /// </summary>
    public partial class CryptographyForm
    {
        ////private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textPlaintext;
        private System.Windows.Forms.TextBox textCiphertext;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboCiphers;
        private System.Windows.Forms.Label labelCiphers;
        private System.Windows.Forms.Panel panelCipherSettings;
        private Panel panel2;
        private Label label1;
        private Label label2;
        private Button buttonRandomize;

        /// <summary>
        /// States if this object has been disposed.
        /// </summary>
        private bool isDisposed;

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
                    // this.components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }

            this.isDisposed = true;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CryptographyForm));
            this.textPlaintext = new System.Windows.Forms.TextBox();
            this.textCiphertext = new System.Windows.Forms.TextBox();
            this.panelCipherSettings = new System.Windows.Forms.Panel();
            this.labelCiphers = new System.Windows.Forms.Label();
            this.comboCiphers = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.buttonRandomize = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabEntryType = new System.Windows.Forms.TabControl();
            this.tabFreeText = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabFile = new System.Windows.Forms.TabPage();
            this.labelEncoding = new System.Windows.Forms.Label();
            this.comboEncoding = new System.Windows.Forms.ComboBox();
            this.buttonFileEncipher = new System.Windows.Forms.Button();
            this.buttonFileDecipher = new System.Windows.Forms.Button();
            this.labelOutput = new System.Windows.Forms.Label();
            this.labelInput = new System.Windows.Forms.Label();
            this.textOutputFile = new System.Windows.Forms.TextBox();
            this.textInputFile = new System.Windows.Forms.TextBox();
            this.buttonBrowseCiphertext = new System.Windows.Forms.Button();
            this.buttonBrowsePlaintext = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel2.SuspendLayout();
            this.tabEntryType.SuspendLayout();
            this.tabFreeText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // aboutFrame
            // 
            this.aboutFrame.Location = new System.Drawing.Point(382, -350);
            this.aboutFrame.Name = "aboutFrame";
            this.aboutFrame.Size = new System.Drawing.Size(193, 135);
            this.aboutFrame.TabIndex = 10;
            // 
            // textPlaintext
            // 
            this.textPlaintext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPlaintext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textPlaintext.Location = new System.Drawing.Point(0, 20);
            this.textPlaintext.Margin = new System.Windows.Forms.Padding(2);
            this.textPlaintext.Multiline = true;
            this.textPlaintext.Name = "textPlaintext";
            this.textPlaintext.Size = new System.Drawing.Size(635, 99);
            this.textPlaintext.TabIndex = 1;
            this.textPlaintext.TextChanged += new System.EventHandler(this.TextPlaintext_TextChanged);
            // 
            // textCiphertext
            // 
            this.textCiphertext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textCiphertext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textCiphertext.Location = new System.Drawing.Point(0, 32);
            this.textCiphertext.Margin = new System.Windows.Forms.Padding(2);
            this.textCiphertext.Multiline = true;
            this.textCiphertext.Name = "textCiphertext";
            this.textCiphertext.Size = new System.Drawing.Size(635, 99);
            this.textCiphertext.TabIndex = 3;
            this.textCiphertext.TextChanged += new System.EventHandler(this.TextCiphertext_TextChanged);
            // 
            // panelCipherSettings
            // 
            this.panelCipherSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCipherSettings.Location = new System.Drawing.Point(0, 38);
            this.panelCipherSettings.Margin = new System.Windows.Forms.Padding(2);
            this.panelCipherSettings.Name = "panelCipherSettings";
            this.panelCipherSettings.Size = new System.Drawing.Size(647, 162);
            this.panelCipherSettings.TabIndex = 4;
            // 
            // labelCiphers
            // 
            this.labelCiphers.AutoSize = true;
            this.labelCiphers.Location = new System.Drawing.Point(11, 11);
            this.labelCiphers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCiphers.Name = "labelCiphers";
            this.labelCiphers.Size = new System.Drawing.Size(49, 14);
            this.labelCiphers.TabIndex = 2;
            this.labelCiphers.Text = "Cipher";
            // 
            // comboCiphers
            // 
            this.comboCiphers.FormattingEnabled = true;
            this.comboCiphers.Location = new System.Drawing.Point(64, 8);
            this.comboCiphers.Margin = new System.Windows.Forms.Padding(2);
            this.comboCiphers.Name = "comboCiphers";
            this.comboCiphers.Size = new System.Drawing.Size(178, 22);
            this.comboCiphers.TabIndex = 0;
            this.comboCiphers.SelectedIndexChanged += new System.EventHandler(this.ComboCiphers_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 6);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(412, 255);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(337, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = global::Useful.Resource.Encipher;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.buttonAbout);
            this.panel2.Controls.Add(this.buttonRandomize);
            this.panel2.Controls.Add(this.comboCiphers);
            this.panel2.Controls.Add(this.panelCipherSettings);
            this.panel2.Controls.Add(this.labelCiphers);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(647, 202);
            this.panel2.TabIndex = 5;
            // 
            // buttonAbout
            // 
            this.buttonAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAbout.Location = new System.Drawing.Point(614, 3);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(30, 30);
            this.buttonAbout.TabIndex = 9;
            this.buttonAbout.Text = global::Useful.Resource.QuestionMark;
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.ButtonAbout_Click);
            // 
            // buttonRandomize
            // 
            this.buttonRandomize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRandomize.Location = new System.Drawing.Point(524, 3);
            this.buttonRandomize.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRandomize.Name = "buttonRandomize";
            this.buttonRandomize.Size = new System.Drawing.Size(85, 30);
            this.buttonRandomize.TabIndex = 8;
            this.buttonRandomize.Text = global::Useful.Resource.Randomize;
            this.buttonRandomize.UseVisualStyleBackColor = true;
            this.buttonRandomize.Click += new System.EventHandler(this.Randomize);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Plaintext";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ciphertext";
            // 
            // tabEntryType
            // 
            this.tabEntryType.Controls.Add(this.tabFreeText);
            this.tabEntryType.Controls.Add(this.tabFile);
            this.tabEntryType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabEntryType.Location = new System.Drawing.Point(0, 0);
            this.tabEntryType.Margin = new System.Windows.Forms.Padding(2);
            this.tabEntryType.Name = "tabEntryType";
            this.tabEntryType.SelectedIndex = 0;
            this.tabEntryType.Size = new System.Drawing.Size(647, 287);
            this.tabEntryType.TabIndex = 8;
            // 
            // tabFreeText
            // 
            this.tabFreeText.Controls.Add(this.splitContainer1);
            this.tabFreeText.Location = new System.Drawing.Point(4, 23);
            this.tabFreeText.Margin = new System.Windows.Forms.Padding(2);
            this.tabFreeText.Name = "tabFreeText";
            this.tabFreeText.Padding = new System.Windows.Forms.Padding(2);
            this.tabFreeText.Size = new System.Drawing.Size(639, 260);
            this.tabFreeText.TabIndex = 0;
            this.tabFreeText.Text = global::Useful.Resource.FreeText;
            this.tabFreeText.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(2, 2);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textPlaintext);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textCiphertext);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(635, 256);
            this.splitContainer1.SplitterDistance = 121;
            this.splitContainer1.TabIndex = 9;
            // 
            // tabFile
            // 
            this.tabFile.Controls.Add(this.labelEncoding);
            this.tabFile.Controls.Add(this.comboEncoding);
            this.tabFile.Controls.Add(this.buttonFileEncipher);
            this.tabFile.Controls.Add(this.buttonFileDecipher);
            this.tabFile.Controls.Add(this.labelOutput);
            this.tabFile.Controls.Add(this.labelInput);
            this.tabFile.Controls.Add(this.textOutputFile);
            this.tabFile.Controls.Add(this.textInputFile);
            this.tabFile.Controls.Add(this.buttonBrowseCiphertext);
            this.tabFile.Controls.Add(this.buttonBrowsePlaintext);
            this.tabFile.Location = new System.Drawing.Point(4, 23);
            this.tabFile.Margin = new System.Windows.Forms.Padding(2);
            this.tabFile.Name = "tabFile";
            this.tabFile.Padding = new System.Windows.Forms.Padding(2);
            this.tabFile.Size = new System.Drawing.Size(639, 260);
            this.tabFile.TabIndex = 1;
            this.tabFile.Text = global::Useful.Resource.File;
            this.tabFile.UseVisualStyleBackColor = true;
            // 
            // labelEncoding
            // 
            this.labelEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEncoding.AutoSize = true;
            this.labelEncoding.Location = new System.Drawing.Point(208, 132);
            this.labelEncoding.Name = "labelEncoding";
            this.labelEncoding.Size = new System.Drawing.Size(112, 14);
            this.labelEncoding.TabIndex = 9;
            this.labelEncoding.Text = "Output encoding";
            // 
            // comboEncoding
            // 
            this.comboEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboEncoding.FormattingEnabled = true;
            this.comboEncoding.Location = new System.Drawing.Point(326, 129);
            this.comboEncoding.Name = "comboEncoding";
            this.comboEncoding.Size = new System.Drawing.Size(223, 22);
            this.comboEncoding.TabIndex = 8;
            // 
            // buttonFileEncipher
            // 
            this.buttonFileEncipher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFileEncipher.Location = new System.Drawing.Point(430, 207);
            this.buttonFileEncipher.Name = "buttonFileEncipher";
            this.buttonFileEncipher.Size = new System.Drawing.Size(97, 40);
            this.buttonFileEncipher.TabIndex = 7;
            this.buttonFileEncipher.Text = global::Useful.Resource.Encipher;
            this.buttonFileEncipher.UseVisualStyleBackColor = true;
            this.buttonFileEncipher.Click += new System.EventHandler(this.ButtonFileEncipher_Click);
            // 
            // buttonFileDecipher
            // 
            this.buttonFileDecipher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFileDecipher.Location = new System.Drawing.Point(533, 207);
            this.buttonFileDecipher.Name = "buttonFileDecipher";
            this.buttonFileDecipher.Size = new System.Drawing.Size(97, 40);
            this.buttonFileDecipher.TabIndex = 6;
            this.buttonFileDecipher.Text = global::Useful.Resource.Decipher;
            this.buttonFileDecipher.UseVisualStyleBackColor = true;
            this.buttonFileDecipher.Click += new System.EventHandler(this.ButtonFileDecipher_Click);
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.Location = new System.Drawing.Point(8, 95);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(84, 14);
            this.labelOutput.TabIndex = 5;
            this.labelOutput.Text = "Output file";
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(8, 34);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(77, 14);
            this.labelInput.TabIndex = 4;
            this.labelInput.Text = "Input file";
            // 
            // textOutputFile
            // 
            this.textOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textOutputFile.Location = new System.Drawing.Point(98, 92);
            this.textOutputFile.Name = "textOutputFile";
            this.textOutputFile.Size = new System.Drawing.Size(451, 22);
            this.textOutputFile.TabIndex = 3;
            // 
            // textInputFile
            // 
            this.textInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textInputFile.Location = new System.Drawing.Point(98, 31);
            this.textInputFile.Name = "textInputFile";
            this.textInputFile.Size = new System.Drawing.Size(451, 22);
            this.textInputFile.TabIndex = 2;
            // 
            // buttonBrowseCiphertext
            // 
            this.buttonBrowseCiphertext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseCiphertext.Location = new System.Drawing.Point(555, 91);
            this.buttonBrowseCiphertext.Name = "buttonBrowseCiphertext";
            this.buttonBrowseCiphertext.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseCiphertext.TabIndex = 1;
            this.buttonBrowseCiphertext.Text = global::Useful.Resource.Browse;
            this.buttonBrowseCiphertext.UseVisualStyleBackColor = true;
            this.buttonBrowseCiphertext.Click += new System.EventHandler(this.ButtonBrowseCiphertext_Click);
            // 
            // buttonBrowsePlaintext
            // 
            this.buttonBrowsePlaintext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowsePlaintext.Location = new System.Drawing.Point(555, 30);
            this.buttonBrowsePlaintext.Name = "buttonBrowsePlaintext";
            this.buttonBrowsePlaintext.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowsePlaintext.TabIndex = 0;
            this.buttonBrowsePlaintext.Text = global::Useful.Resource.Browse;
            this.buttonBrowsePlaintext.UseVisualStyleBackColor = true;
            this.buttonBrowsePlaintext.Click += new System.EventHandler(this.ButtonBrowsePlaintext_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabEntryType);
            this.splitContainer2.Size = new System.Drawing.Size(647, 491);
            this.splitContainer2.SplitterDistance = 202;
            this.splitContainer2.SplitterWidth = 2;
            this.splitContainer2.TabIndex = 9;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // CryptographyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 491);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.aboutFrame);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CryptographyForm";
            this.Text = "Cryptography";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabEntryType.ResumeLayout(false);
            this.tabFreeText.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabFile.ResumeLayout(false);
            this.tabFile.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabEntryType;
        private TabPage tabFreeText;
        private TabPage tabFile;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private Button buttonBrowseCiphertext;
        private Button buttonBrowsePlaintext;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private Button buttonFileEncipher;
        private Button buttonFileDecipher;
        private Label labelOutput;
        private Label labelInput;
        private TextBox textOutputFile;
        private TextBox textInputFile;
        private Label labelEncoding;
        private ComboBox comboEncoding;
        private Button buttonAbout;
    }
}