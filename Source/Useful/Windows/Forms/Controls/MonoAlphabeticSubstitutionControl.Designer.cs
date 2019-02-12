//-----------------------------------------------------------------------
// <copyright file="MonoAlphabeticSubstitutionControl.Designer.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>The Monoalphabetic algorithm settings Windows control for a substitution.</summary>
//-----------------------------------------------------------------------

namespace Useful.Windows.Forms.Controls.Cryptography
{
    /// <summary>
    /// The Monoalphabetic algorithm settings Windows control for a substitution.
    /// </summary>
    public partial class MonoAlphabeticSubstitutionControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.Windows.Forms.TextBox textFrom;
        private System.Windows.Forms.ComboBox comboTo;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textFrom = new System.Windows.Forms.TextBox();
            this.comboTo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textFrom
            // 
            this.textFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textFrom.Dock = System.Windows.Forms.DockStyle.Top;
            this.textFrom.Enabled = false;
            this.textFrom.Location = new System.Drawing.Point(0, 0);
            this.textFrom.Name = "textFrom";
            this.textFrom.Size = new System.Drawing.Size(35, 20);
            this.textFrom.TabIndex = 0;
            this.textFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // comboTo
            // 
            this.comboTo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.comboTo.FormattingEnabled = true;
            this.comboTo.Location = new System.Drawing.Point(0, 21);
            this.comboTo.Name = "comboTo";
            this.comboTo.Size = new System.Drawing.Size(35, 21);
            this.comboTo.TabIndex = 1;
            this.comboTo.SelectedIndexChanged += new System.EventHandler(this.ComboTo_SelectedIndexChanged);
            // 
            // MonoAlphabeticSubstitutionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboTo);
            this.Controls.Add(this.textFrom);
            this.Name = "MonoAlphabeticSubstitutionControl";
            this.Size = new System.Drawing.Size(35, 42);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
