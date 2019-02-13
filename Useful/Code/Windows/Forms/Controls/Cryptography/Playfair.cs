using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Useful.Security.Cryptography;

namespace Useful.Windows.Security.Cryptography
{
	/// <summary>
	/// A Windows form that handles the Playfair cipher.
	/// </summary>
	public class Playfair : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textInput;
		private System.Windows.Forms.TextBox textOutput;
		private System.Windows.Forms.Button buttonEncipher;
		private System.Windows.Forms.Button buttonDecipher;
		private System.Windows.Forms.Button buttonCrack;
		private System.Windows.Forms.Button buttonClose;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textKeyString;

		private Useful.Security.Cryptography.Playfair m_playfair = new Useful.Security.Cryptography.Playfair();

		/// <summary>
		/// Creates an instance of this class.
		/// </summary>
		public Playfair()
		{
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Playfair));
			this.textInput = new System.Windows.Forms.TextBox();
			this.textOutput = new System.Windows.Forms.TextBox();
			this.buttonEncipher = new System.Windows.Forms.Button();
			this.buttonDecipher = new System.Windows.Forms.Button();
			this.buttonCrack = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.textKeyString = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
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
			// textKeyString
			// 
			resources.ApplyResources(this.textKeyString, "textKeyString");
			this.textKeyString.Name = "textKeyString";
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// Playfair
			// 
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textKeyString);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonCrack);
			this.Controls.Add(this.buttonDecipher);
			this.Controls.Add(this.buttonEncipher);
			this.Controls.Add(this.textOutput);
			this.Controls.Add(this.textInput);
			this.Name = "Playfair";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private void btnEncipher_Click(object sender, System.EventArgs e)
		{
			m_playfair.Keyword = textKeyString.Text;
			textOutput.Text = m_playfair.Encipher(textInput.Text);
		}

		private void btnDecipher_Click(object sender, System.EventArgs e)
		{
			m_playfair.Keyword = textKeyString.Text;
			textOutput.Text = m_playfair.Decipher(textInput.Text);
		}

		private void btnCrack_Click(object sender, System.EventArgs e)
		{
			//txtOutput.Text = oMono.Crack(txtInput.Text);
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
