using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;

using Useful.Security.Cryptography;

namespace Useful.Windows.Security.Cryptography
{
	/// <summary>
	/// A Windows form that handles the Mono Aplhabetic substitution cipher.
	/// </summary>
	public class MonoAlphabetic : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textInput;
		private System.Windows.Forms.TextBox textOutput;
		private System.Windows.Forms.Button buttonEncipher;
		private System.Windows.Forms.Button buttonDecipher;
		private System.Windows.Forms.Button buttonCrack;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboWrongLetter;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboCorrectLetter;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button buttonSwap;

		private Useful.Security.Cryptography.MonoAlphabetic m_mono = new Useful.Security.Cryptography.MonoAlphabetic();
		private CultureInfo m_culture = new CultureInfo("en-GB");

		/// <summary>
		/// Initializes a new instance of this class.
		/// </summary>
		public MonoAlphabetic()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonoAlphabetic));
			this.textInput = new System.Windows.Forms.TextBox();
			this.textOutput = new System.Windows.Forms.TextBox();
			this.buttonEncipher = new System.Windows.Forms.Button();
			this.buttonDecipher = new System.Windows.Forms.Button();
			this.buttonCrack = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.comboWrongLetter = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.comboCorrectLetter = new System.Windows.Forms.ComboBox();
			this.buttonSwap = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textInput
			// 
			resources.ApplyResources(this.textInput, "textInput");
			this.textInput.Name = "textInput";
			// 
			// textOutput
			// 
			resources.ApplyResources(this.textOutput, "textOutput");
			this.textOutput.Name = "textOutput";
			// 
			// buttonEncipher
			// 
			resources.ApplyResources(this.buttonEncipher, "buttonEncipher");
			this.buttonEncipher.Name = "buttonEncipher";
			this.buttonEncipher.Click += new System.EventHandler(this.btnEncipher_Click);
			// 
			// buttonDecipher
			// 
			resources.ApplyResources(this.buttonDecipher, "buttonDecipher");
			this.buttonDecipher.Name = "buttonDecipher";
			this.buttonDecipher.Click += new System.EventHandler(this.btnDecipher_Click);
			// 
			// buttonCrack
			// 
			resources.ApplyResources(this.buttonCrack, "buttonCrack");
			this.buttonCrack.Name = "buttonCrack";
			this.buttonCrack.Click += new System.EventHandler(this.btnCrack_Click);
			// 
			// buttonClose
			// 
			resources.ApplyResources(this.buttonClose, "buttonClose");
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// comboWrongLetter
			// 
			this.comboWrongLetter.FormattingEnabled = true;
			resources.ApplyResources(this.comboWrongLetter, "comboWrongLetter");
			this.comboWrongLetter.Name = "comboWrongLetter";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// comboCorrectLetter
			// 
			this.comboCorrectLetter.FormattingEnabled = true;
			resources.ApplyResources(this.comboCorrectLetter, "comboCorrectLetter");
			this.comboCorrectLetter.Name = "comboCorrectLetter";
			// 
			// buttonSwap
			// 
			resources.ApplyResources(this.buttonSwap, "buttonSwap");
			this.buttonSwap.Name = "buttonSwap";
			this.buttonSwap.Click += new System.EventHandler(this.btnSwap_Click);
			// 
			// MonoAlphabetic
			// 
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.buttonSwap);
			this.Controls.Add(this.comboCorrectLetter);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.comboWrongLetter);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonCrack);
			this.Controls.Add(this.buttonDecipher);
			this.Controls.Add(this.buttonEncipher);
			this.Controls.Add(this.textOutput);
			this.Controls.Add(this.textInput);
			this.Name = "MonoAlphabetic";
			this.Load += new System.EventHandler(this.frmMonoAlphabetic_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private void btnEncipher_Click(object sender, System.EventArgs e)
		{
			textOutput.Text = m_mono.Encipher(textInput.Text);
		}

		private void btnDecipher_Click(object sender, System.EventArgs e)
		{
			textOutput.Text = m_mono.Decipher(textInput.Text);
		}

		private void btnCrack_Click(object sender, System.EventArgs e)
		{
			textOutput.Text = m_mono.Crack(textInput.Text);
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmMonoAlphabetic_Load(object sender, System.EventArgs e)
		{
			char letter;
			for (int i = 0 ; i < 26 ; i++)
			{
				letter = (char)(i + 'A');
				comboWrongLetter.Items.Add(letter);
				comboCorrectLetter.Items.Add(letter);
			}
  
			comboWrongLetter.SelectedText = 'A'.ToString();
			comboCorrectLetter.SelectedText = 'A'.ToString();
		}

		private void btnSwap_Click(object sender, System.EventArgs e)
		{
			m_mono.SwapPlaintextLetter(Convert.ToChar(comboWrongLetter.Text, m_culture), Convert.ToChar(comboCorrectLetter.Text, new CultureInfo("en-GB")));
			textOutput.Text = m_mono.Decipher(textInput.Text);
		}
	}
}
