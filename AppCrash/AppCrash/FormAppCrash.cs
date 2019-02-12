namespace AppCrash
{
	using System;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Text;
	using System.Windows.Forms;
	using System.Threading;

	public class FormAppCrash : Form
	{
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox txtMessage;
		private System.Windows.Forms.Button btnCrash;

		public FormAppCrash()
		{
			InitializeComponent();

			StringBuilder sb = new StringBuilder();
			sb.Append("By default .NET 1.1 applications will show a Continue/Debug messagebox when a unhandled exception is thrown.");
			sb.Append(Environment.NewLine);
			sb.Append("This registry key controls the behaviour:");
			sb.Append(Environment.NewLine);
			sb.Append(@"HKEY_LOCAL_MACHINE\Software\Microsoft\.NETFramework\DbgJITDebugLaunchSetting");
			sb.Append(Environment.NewLine);
			sb.Append("It should be changed so that no messagebox is shown.");
			sb.Append(Environment.NewLine);
			sb.Append("See here:");
			sb.Append(Environment.NewLine);
			sb.Append(@"http://msdn.microsoft.com/en-us/library/2ac5yxx6(VS.71).aspx");
			sb.Append(Environment.NewLine);
			sb.Append("NOTE: WinForms (.net 1.1) can swallow the exception or wrap it in a custom exception handler.  See this:");
			sb.Append(Environment.NewLine);
			sb.Append(@"http://stackoverflow.com/questions/944/unhandled-exception-handler-in-net-1-1");
			sb.Append(Environment.NewLine);
			sb.Append("ProcDump should be configured to capture a dump:");
			sb.Append(Environment.NewLine);
			sb.Append("procdump -t {appname}.exe");
			this.txtMessage.Text = sb.ToString();
		}

		private delegate void VoidDelegate();

		private void ThrowException()
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke(new VoidDelegate(ThrowException));
				return;
			}

			throw new Exception("Unhandled exception has been thrown!");
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnCrash = new System.Windows.Forms.Button();
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnCrash
			// 
			this.btnCrash.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnCrash.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCrash.Location = new System.Drawing.Point(0, 160);
			this.btnCrash.Name = "btnCrash";
			this.btnCrash.Size = new System.Drawing.Size(578, 88);
			this.btnCrash.TabIndex = 4;
			this.btnCrash.Text = "Press to Crash!";
			this.btnCrash.Click += new System.EventHandler(this.btnCrash_Click);
			// 
			// txtMessage
			// 
			this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtMessage.Location = new System.Drawing.Point(0, 0);
			this.txtMessage.Multiline = true;
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.Size = new System.Drawing.Size(584, 152);
			this.txtMessage.TabIndex = 5;
			this.txtMessage.Text = "";
			// 
			// FormAppCrash
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(578, 248);
			this.Controls.Add(this.btnCrash);
			this.Controls.Add(this.txtMessage);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FormAppCrash";
			this.Text = "Crashing Application";
			this.ResumeLayout(false);

		}

		#endregion

		private void btnCrash_Click(object sender, System.EventArgs e)
		{
			this.ThrowException();
		}
	}
}
