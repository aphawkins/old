using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Useful.Security.Cryptography;

namespace Useful.Windows.Security.Cryptography
{
	/// <summary>
	/// Summary description for frmAtBash.
	/// </summary>
	public class ROT13 : System.Windows.Forms.Form
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

		public ROT13()
		{
			InitializeComponent();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ROT13));
			this.textInput = new System.Windows.Forms.TextBox();
			this.textOutput = new System.Windows.Forms.TextBox();
			this.buttonEncipher = new System.Windows.Forms.Button();
			this.buttonDecipher = new System.Windows.Forms.Button();
			this.buttonCrack = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
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
			// ROT13
			// 
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonCrack);
			this.Controls.Add(this.buttonDecipher);
			this.Controls.Add(this.buttonEncipher);
			this.Controls.Add(this.textOutput);
			this.Controls.Add(this.textInput);
			this.Name = "ROT13";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private void btnEncipher_Click(object sender, System.EventArgs e)
		{
			textOutput.Text = Useful.Security.Cryptography.ROT13.Encipher(textInput.Text);
		}

		private void btnDecipher_Click(object sender, System.EventArgs e)
		{
			textOutput.Text = Useful.Security.Cryptography.ROT13.Decipher(textInput.Text);
		}

		private void btnCrack_Click(object sender, System.EventArgs e)
		{
			textOutput.Text = Useful.Security.Cryptography.ROT13.Crack(textInput.Text);
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
