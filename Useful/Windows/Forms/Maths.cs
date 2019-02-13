using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;

using Useful;

namespace Useful.Windows
{
	/// <summary>
	/// A Windows form that handles mathematic functions.
	/// </summary>
	public class Maths : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Initializes a new instance of this class.
		/// </summary>
		public Maths()
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Maths));
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			resources.ApplyResources(this.button1, "button1");
			this.button1.Name = "button1";
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// button2
			// 
			resources.ApplyResources(this.button2, "button2");
			this.button2.Name = "button2";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Maths
			// 
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Name = "Maths";
			this.ResumeLayout(false);

		}
		#endregion

		//private void button1_Click(object sender, System.EventArgs e)
		//{
		//    Useful.Maths.IntegerFactorization o = new Useful.Maths.IntegerFactorization();
//			StringBuilder sb = new StringBuilder();
//			int i;
//			for (i = 0 ; i < o.Number1.Length ; i++)
//			{
//				sb.Append(o.Number1[i]);
//			}
//			label1.Text = sb.ToString();
//
//			sb = new StringBuilder();
//			for (i = 0 ; i < o.Number2.Length ; i++)
//			{
//				sb.Append(o.Number2[i]);
//			}
//			label2.Text = sb.ToString();

//			label1.Text = o.Number1.ToString();
//			label2.Text = o.Number2.ToString();
		//}

		private void button2_Click(object sender, System.EventArgs e)
		{
			UIntHuge x = new UIntHuge(new byte[3] {1, 9, 1});
			UIntHuge y = new UIntHuge(new byte[3] {1, 9, 1});

			bool result = (x == y);
			MessageBox.Show(result.ToString(), Useful.Windows.Resource.Result, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
		}
	}
}
