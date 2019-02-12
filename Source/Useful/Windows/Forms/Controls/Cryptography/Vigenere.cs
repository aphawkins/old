using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Useful.Security.Cryptography;

namespace Useful.Windows.Security.Cryptography
{
	/// <summary>
	/// Summary description for Vigenere.
	/// </summary>
	public class Vigenere : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textInput;
		private System.Windows.Forms.TextBox textOutput;
		private System.Windows.Forms.TextBox textKeyword;
		private System.Windows.Forms.Button buttonEncipher;
		private System.Windows.Forms.Button buttonDecipher;
		private System.Windows.Forms.Button buttonCrack;
		private System.Windows.Forms.Button buttonClose;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Vigenere()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vigenere));
			this.buttonEncipher = new System.Windows.Forms.Button();
			this.textInput = new System.Windows.Forms.TextBox();
			this.textOutput = new System.Windows.Forms.TextBox();
			this.textKeyword = new System.Windows.Forms.TextBox();
			this.buttonDecipher = new System.Windows.Forms.Button();
			this.buttonCrack = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonEncipher
			// 
			resources.ApplyResources(this.buttonEncipher, "buttonEncipher");
			this.buttonEncipher.Name = "buttonEncipher";
			this.buttonEncipher.Click += new System.EventHandler(this.btnEncipher_Click);
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
			// textKeyword
			// 
			resources.ApplyResources(this.textKeyword, "textKeyword");
			this.textKeyword.Name = "textKeyword";
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
			// Vigenere
			// 
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonCrack);
			this.Controls.Add(this.buttonDecipher);
			this.Controls.Add(this.textKeyword);
			this.Controls.Add(this.textOutput);
			this.Controls.Add(this.textInput);
			this.Controls.Add(this.buttonEncipher);
			this.Name = "Vigenere";
			this.Load += new System.EventHandler(this.Vigenere_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private void Vigenere_Load(object sender, System.EventArgs e)
		{
			//this.MdiParent = MDI;
		}

		private void btnEncipher_Click(object sender, System.EventArgs e)
		{
			textOutput.Text = Useful.Security.Cryptography.Vigenere.Encipher(textInput.Text, textKeyword.Text);
		}

		private void btnDecipher_Click(object sender, System.EventArgs e)
		{
			textOutput.Text = Useful.Security.Cryptography.Vigenere.Decipher(textInput.Text, textKeyword.Text);		
		}

		private void btnCrack_Click(object sender, System.EventArgs e)
		{
			textKeyword.Text = Useful.Security.Cryptography.Vigenere.Crack(textInput.Text);
			textOutput.Text = Useful.Security.Cryptography.Vigenere.Decipher(textInput.Text, textKeyword.Text);
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

	}
}
