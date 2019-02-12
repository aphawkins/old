using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;

using Useful;

namespace Useful.Windows
{
	/// <summary>
	/// A Windows form for converting length
	/// </summary>
	public class Length : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textValue;
		private System.Windows.Forms.Label labelValue;
		private System.Windows.Forms.ComboBox comboFrom;
		private System.Windows.Forms.Label labelFrom;
		private System.Windows.Forms.Label labelTo;
		private System.Windows.Forms.ComboBox comboTo;
		private System.Windows.Forms.TextBox textResult;
		private System.Windows.Forms.Label labelResult;
		private System.Windows.Forms.Button buttonCalc;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private CultureInfo m_culture = new CultureInfo("en-GB");

		/// <summary>
		/// Creates an instance of this class.
		/// </summary>
		public Length()
		{
			InitializeComponent();

			Populate();
		}

		private void Populate()
		{
			foreach (string name in Enum.GetNames(typeof(Useful.Length)))
			{
				comboFrom.Items.Add(name);
				comboTo.Items.Add(name);
			}
			comboFrom.SelectedIndex = 0;
			comboTo.SelectedIndex = 1;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Length));
			this.textValue = new System.Windows.Forms.TextBox();
			this.labelValue = new System.Windows.Forms.Label();
			this.comboFrom = new System.Windows.Forms.ComboBox();
			this.labelFrom = new System.Windows.Forms.Label();
			this.labelTo = new System.Windows.Forms.Label();
			this.comboTo = new System.Windows.Forms.ComboBox();
			this.textResult = new System.Windows.Forms.TextBox();
			this.labelResult = new System.Windows.Forms.Label();
			this.buttonCalc = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textValue
			// 
			resources.ApplyResources(this.textValue, "textValue");
			this.textValue.Name = "textValue";
			// 
			// labelValue
			// 
			resources.ApplyResources(this.labelValue, "labelValue");
			this.labelValue.Name = "labelValue";
			// 
			// comboFrom
			// 
			this.comboFrom.FormattingEnabled = true;
			resources.ApplyResources(this.comboFrom, "comboFrom");
			this.comboFrom.Name = "comboFrom";
			// 
			// labelFrom
			// 
			resources.ApplyResources(this.labelFrom, "labelFrom");
			this.labelFrom.Name = "labelFrom";
			// 
			// labelTo
			// 
			resources.ApplyResources(this.labelTo, "labelTo");
			this.labelTo.Name = "labelTo";
			// 
			// comboTo
			// 
			this.comboTo.FormattingEnabled = true;
			resources.ApplyResources(this.comboTo, "comboTo");
			this.comboTo.Name = "comboTo";
			// 
			// textResult
			// 
			resources.ApplyResources(this.textResult, "textResult");
			this.textResult.Name = "textResult";
			// 
			// labelResult
			// 
			resources.ApplyResources(this.labelResult, "labelResult");
			this.labelResult.Name = "labelResult";
			// 
			// buttonCalc
			// 
			resources.ApplyResources(this.buttonCalc, "buttonCalc");
			this.buttonCalc.Name = "buttonCalc";
			this.buttonCalc.Click += new System.EventHandler(this.btnCalc_Click);
			// 
			// Length
			// 
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.buttonCalc);
			this.Controls.Add(this.labelResult);
			this.Controls.Add(this.textResult);
			this.Controls.Add(this.textValue);
			this.Controls.Add(this.comboTo);
			this.Controls.Add(this.labelTo);
			this.Controls.Add(this.labelFrom);
			this.Controls.Add(this.comboFrom);
			this.Controls.Add(this.labelValue);
			this.Name = "Length";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private void btnCalc_Click(object sender, System.EventArgs e)
		{
			Enum from = (Enum)Enum.Parse(typeof(Useful.Length), comboFrom.SelectedItem.ToString());
			Enum to = (Enum)Enum.Parse(typeof(Useful.Length), comboTo.SelectedIndex.ToString(m_culture));
			textResult.Text = Useful.Conversion.ConvertLength((Useful.Length)from, (Useful.Length)to, double.Parse(textValue.Text, m_culture)).ToString(m_culture);
		}
	}
}
