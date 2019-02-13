namespace Useful.Windows.Forms.Controls
{
	/// <summary>
	/// A Windows control that is a base for other service controls.
	/// </summary>
	public partial class ServiceControl
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.checkAvailable = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// checkAvailable
			// 
			this.checkAvailable.AutoSize = true;
			this.checkAvailable.Location = new System.Drawing.Point(3, 3);
			this.checkAvailable.Name = "checkAvailable";
			this.checkAvailable.Size = new System.Drawing.Size(69, 17);
			this.checkAvailable.TabIndex = 2;
			this.checkAvailable.Text = "Available";
			this.checkAvailable.UseVisualStyleBackColor = true;
			// 
			// ServiceControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.checkAvailable);
			this.Name = "ServiceControl";
			this.Size = new System.Drawing.Size(182, 150);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkAvailable;
	}
}
