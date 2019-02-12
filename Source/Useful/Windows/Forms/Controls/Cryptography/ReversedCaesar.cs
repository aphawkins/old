using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Useful.Security.Cryptography;

namespace Useful.Windows.Security.Cryptography
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class ReversedCaesar : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox comboShift;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonEncipher;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.TextBox textInput;
		private System.Windows.Forms.TextBox textOutput;

//		private frmProgress frmProgress;
		private System.Windows.Forms.Button buttonDecipher;
		private System.Windows.Forms.Button buttonCrack;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ReversedCaesar()
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
				if (components != null) 
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReversedCaesar));
			this.buttonEncipher = new System.Windows.Forms.Button();
			this.textInput = new System.Windows.Forms.TextBox();
			this.textOutput = new System.Windows.Forms.TextBox();
			this.comboShift = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonClose = new System.Windows.Forms.Button();
			this.buttonDecipher = new System.Windows.Forms.Button();
			this.buttonCrack = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonEncipher
			// 
			resources.ApplyResources(this.buttonEncipher, "buttonEncipher");
			this.buttonEncipher.Name = "buttonEncipher";
			this.buttonEncipher.Click += new System.EventHandler(this.buttonEncipher_Click);
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
			// comboShift
			// 
			this.comboShift.FormattingEnabled = true;
			resources.ApplyResources(this.comboShift, "comboShift");
			this.comboShift.Name = "comboShift";
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// buttonClose
			// 
			resources.ApplyResources(this.buttonClose, "buttonClose");
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// buttonDecipher
			// 
			resources.ApplyResources(this.buttonDecipher, "buttonDecipher");
			this.buttonDecipher.Name = "buttonDecipher";
			this.buttonDecipher.Click += new System.EventHandler(this.buttonDecipher_Click);
			// 
			// buttonCrack
			// 
			resources.ApplyResources(this.buttonCrack, "buttonCrack");
			this.buttonCrack.Name = "buttonCrack";
			this.buttonCrack.Click += new System.EventHandler(this.buttonCrack_Click);
			// 
			// ReversedCaesar
			// 
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.buttonCrack);
			this.Controls.Add(this.buttonDecipher);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboShift);
			this.Controls.Add(this.textOutput);
			this.Controls.Add(this.textInput);
			this.Controls.Add(this.buttonEncipher);
			this.Name = "ReversedCaesar";
			this.Load += new System.EventHandler(this.formCaesar_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private void buttonEncipher_Click(object sender, System.EventArgs e)
		{
			char shift = comboShift.Text[0];
			textOutput.Text = Useful.Security.Cryptography.ReversedCaesar.Encipher(textInput.Text, shift);
		}

		private void buttonDecipher_Click(object sender, System.EventArgs e)
		{
			char shift = comboShift.Text[0];
			textOutput.Text = Useful.Security.Cryptography.ReversedCaesar.Decipher(textInput.Text, shift);
		}

		private void formCaesar_Load(object sender, System.EventArgs e)
		{
			//Populate the shift
			comboShift.Items.Clear();
			for (char i = 'A' ; i <= 'Z' ; i++ )
			{
				comboShift.Items.Add(i);
			}
			comboShift.Text = 'A'.ToString();
		}


		private void buttonClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void buttonCrack_Click(object sender, System.EventArgs e)
		{
			comboShift.Text = Useful.Security.Cryptography.ReversedCaesar.Crack(textInput.Text).ToString();
			textOutput.Text = Useful.Security.Cryptography.ReversedCaesar.Decipher(comboShift.Text[0], comboShift.Text[0]).ToString();
		}
	}
}
