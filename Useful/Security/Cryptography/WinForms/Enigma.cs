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
	/// A Windows form that handles the Enigma cipher.
	/// </summary>
	public class Enigma : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textInput;
		private System.Windows.Forms.TextBox textOutput;
		private System.Windows.Forms.Button buttonEncipher;
        private System.Windows.Forms.Button buttonDecipher;
		private System.Windows.Forms.Button buttonClose;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ComboBox comboWheel3;
		private System.Windows.Forms.ComboBox comboWheel2;
		private System.Windows.Forms.ComboBox comboWheel1;
		private System.Windows.Forms.GroupBox groupWheels;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboPosition3;
		private System.Windows.Forms.ComboBox comboPosition2;
        private System.Windows.Forms.ComboBox comboPosition1;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;

		private Useful.Security.Cryptography.Enigma enigma = new Useful.Security.Cryptography.Enigma();
		private static CultureInfo m_culture = new CultureInfo("en-GB");

		/// <summary>
		/// Creates an instance of this class.
		/// </summary>
		public Enigma()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Enigma));
            this.textInput = new System.Windows.Forms.TextBox();
            this.textOutput = new System.Windows.Forms.TextBox();
            this.buttonEncipher = new System.Windows.Forms.Button();
            this.buttonDecipher = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.comboWheel3 = new System.Windows.Forms.ComboBox();
            this.comboWheel2 = new System.Windows.Forms.ComboBox();
            this.comboWheel1 = new System.Windows.Forms.ComboBox();
            this.groupWheels = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboPosition1 = new System.Windows.Forms.ComboBox();
            this.comboPosition2 = new System.Windows.Forms.ComboBox();
            this.comboPosition3 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupWheels.SuspendLayout();
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
            // buttonClose
            // 
            resources.ApplyResources(this.buttonClose, "buttonClose");
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // comboWheel3
            // 
            this.comboWheel3.FormattingEnabled = true;
            resources.ApplyResources(this.comboWheel3, "comboWheel3");
            this.comboWheel3.Name = "comboWheel3";
            // 
            // comboWheel2
            // 
            this.comboWheel2.FormattingEnabled = true;
            resources.ApplyResources(this.comboWheel2, "comboWheel2");
            this.comboWheel2.Name = "comboWheel2";
            // 
            // comboWheel1
            // 
            this.comboWheel1.FormattingEnabled = true;
            resources.ApplyResources(this.comboWheel1, "comboWheel1");
            this.comboWheel1.Name = "comboWheel1";
            // 
            // groupWheels
            // 
            this.groupWheels.Controls.Add(this.label6);
            this.groupWheels.Controls.Add(this.label4);
            this.groupWheels.Controls.Add(this.comboPosition1);
            this.groupWheels.Controls.Add(this.comboPosition2);
            this.groupWheels.Controls.Add(this.comboPosition3);
            this.groupWheels.Controls.Add(this.label3);
            this.groupWheels.Controls.Add(this.label2);
            this.groupWheels.Controls.Add(this.label1);
            this.groupWheels.Controls.Add(this.comboWheel3);
            this.groupWheels.Controls.Add(this.comboWheel2);
            this.groupWheels.Controls.Add(this.comboWheel1);
            resources.ApplyResources(this.groupWheels, "groupWheels");
            this.groupWheels.Name = "groupWheels";
            this.groupWheels.TabStop = false;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // comboPosition1
            // 
            this.comboPosition1.FormattingEnabled = true;
            resources.ApplyResources(this.comboPosition1, "comboPosition1");
            this.comboPosition1.Name = "comboPosition1";
            // 
            // comboPosition2
            // 
            this.comboPosition2.FormattingEnabled = true;
            resources.ApplyResources(this.comboPosition2, "comboPosition2");
            this.comboPosition2.Name = "comboPosition2";
            // 
            // comboPosition3
            // 
            this.comboPosition3.FormattingEnabled = true;
            resources.ApplyResources(this.comboPosition3, "comboPosition3");
            this.comboPosition3.Name = "comboPosition3";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Enigma
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.groupWheels);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonDecipher);
            this.Controls.Add(this.buttonEncipher);
            this.Controls.Add(this.textOutput);
            this.Controls.Add(this.textInput);
            this.Name = "Enigma";
            this.Load += new System.EventHandler(this.frmEnigma_Load);
            this.groupWheels.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnEncipher_Click(object sender, System.EventArgs e)
		{
            enigma.SetWheelLetter(EnigmaWheelPosition.One, comboPosition1.Text[0]);
            enigma.SetWheelLetter(EnigmaWheelPosition.Two, comboPosition2.Text[0]);
            enigma.SetWheelLetter(EnigmaWheelPosition.Three, comboPosition3.Text[0]);

            textOutput.Text = enigma.Encipher(textInput.Text);
            
            comboPosition1.Text = enigma.GetWheelLetter(EnigmaWheelPosition.One).ToString();
            comboPosition2.Text = enigma.GetWheelLetter(EnigmaWheelPosition.Two).ToString();
            comboPosition3.Text = enigma.GetWheelLetter(EnigmaWheelPosition.Three).ToString();
		}

		private void btnDecipher_Click(object sender, System.EventArgs e)
		{
            enigma.SetWheelLetter(EnigmaWheelPosition.One, comboPosition1.Text[0]);
            enigma.SetWheelLetter(EnigmaWheelPosition.Two, comboPosition2.Text[0]);
            enigma.SetWheelLetter(EnigmaWheelPosition.Three, comboPosition3.Text[0]);

            textOutput.Text = enigma.Decipher(textInput.Text);

            comboPosition1.Text = enigma.GetWheelLetter(EnigmaWheelPosition.One).ToString();
            comboPosition2.Text = enigma.GetWheelLetter(EnigmaWheelPosition.Two).ToString();
            comboPosition3.Text = enigma.GetWheelLetter(EnigmaWheelPosition.Three).ToString();
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void SetCodeBookSettings()
		{
            //Code book settings
            EnigmaScramblerNumber Fast = EnigmaScramblerNumber.One;
            EnigmaScramblerNumber Medium = EnigmaScramblerNumber.One;
            EnigmaScramblerNumber Slow = EnigmaScramblerNumber.One;

			switch ((string)comboWheel1.SelectedItem)
			{
				case "I":
				{
                    Fast = EnigmaScramblerNumber.One;
					break;
				}
				case "II":
				{
                    Fast = EnigmaScramblerNumber.Two;
					break;
				}
				case "III":
				{
                    Fast = EnigmaScramblerNumber.Three;
					break;
				}
			}
			switch ((string)comboWheel2.SelectedItem)
			{
				case "I":
				{
                    Medium = EnigmaScramblerNumber.One;
					break;
				}
				case "II":
				{
                    Medium = EnigmaScramblerNumber.Two;
					break;
				}
				case "III":
				{
                    Medium = EnigmaScramblerNumber.Three;
					break;
				}
			}
			switch ((string)comboWheel3.SelectedItem)
			{
				case "I":
				{
                    Slow = EnigmaScramblerNumber.One;
					break;
				}
				case "II":
				{
                    Slow = EnigmaScramblerNumber.Two;
					break;
				}
				case "III":
				{
                    Slow = EnigmaScramblerNumber.Three;
					break;
				}
			}
			//Code book settings
			enigma.SetWheelOrder(EnigmaWheelPosition.One, Fast);
            enigma.SetWheelOrder(EnigmaWheelPosition.Two, Medium);
            enigma.SetWheelOrder(EnigmaWheelPosition.Three, Slow);

            comboPosition1.Text = 'L'.ToString();
            comboPosition2.Text = 'G'.ToString();
            comboPosition3.Text = 'A'.ToString();

            enigma.SetWheelLetter(EnigmaWheelPosition.One, comboPosition1.Text[0]);
            enigma.SetWheelLetter(EnigmaWheelPosition.Two, comboPosition2.Text[0]);
            enigma.SetWheelLetter(EnigmaWheelPosition.Three, comboPosition3.Text[0]);

            char[][] Plugs = new char[6][]
			{
				new char[] {'A','S'},
				new char[] {'E','I'},
				new char[] {'J','N'},
				new char[] {'K','L'},
				new char[] {'M','U'},
				new char[] {'T','O'}
			};

            enigma.PlugBoard(Plugs);
		}

		private void frmEnigma_Load(object sender, System.EventArgs e)
		{
			string s;
			comboWheel1.Items.Clear();
			comboWheel1.Items.Add("I");
			comboWheel1.Items.Add("II");
			comboWheel1.Items.Add("III");
			comboWheel1.SelectedItem = "I";
			comboWheel2.Items.Clear();
			comboWheel2.Items.Add("I");
			comboWheel2.Items.Add("II");
			comboWheel2.Items.Add("III");
			comboWheel2.SelectedItem = "II";
			comboWheel3.Items.Clear();
			comboWheel3.Items.Add("I");
			comboWheel3.Items.Add("II");
			comboWheel3.Items.Add("III");
			comboWheel3.SelectedItem = "III";

			comboPosition1.Items.Clear();
			comboPosition2.Items.Clear();
			comboPosition3.Items.Clear();

			for (int i = 0 ; i < 26 ; i++)
			{
				s = Convert.ToString((char)(i + 'A'), m_culture);
				comboPosition1.Items.Add(s);
				comboPosition2.Items.Add(s);
				comboPosition3.Items.Add(s);
			}

            SetCodeBookSettings();
		}
	}
}
