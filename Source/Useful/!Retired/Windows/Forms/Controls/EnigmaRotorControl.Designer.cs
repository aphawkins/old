//-----------------------------------------------------------------------
// <copyright file="EnigmaRotorControl.Designer.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>An Enigma Rotor Windows control.</summary>
//-----------------------------------------------------------------------

namespace Useful.Windows.Forms.Controls.Cryptography
{
    /// <summary>
    /// An Enigma Rotor Windows control.
    /// </summary>
    public partial class EnigmaRotorControl
    {
        ////private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboRotor1;
        private System.Windows.Forms.Label labelRotor1;
        private System.Windows.Forms.ComboBox comboInitialPosition1;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboRotor1 = new System.Windows.Forms.ComboBox();
            this.labelRotor1 = new System.Windows.Forms.Label();
            this.comboInitialPosition1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboRotor1
            // 
            this.comboRotor1.FormattingEnabled = true;
            this.comboRotor1.Location = new System.Drawing.Point(0, 16);
            this.comboRotor1.Name = "comboRotor1";
            this.comboRotor1.Size = new System.Drawing.Size(87, 21);
            this.comboRotor1.TabIndex = 2;
            this.comboRotor1.SelectedIndexChanged += new System.EventHandler(this.ComboRotor1_SelectedIndexChanged);
            // 
            // labelRotor1
            // 
            this.labelRotor1.AutoSize = true;
            this.labelRotor1.Location = new System.Drawing.Point(-3, 0);
            this.labelRotor1.Name = "labelRotor1";
            this.labelRotor1.Size = new System.Drawing.Size(44, 13);
            this.labelRotor1.TabIndex = 3;
            this.labelRotor1.Text = Resource.Position;
            // 
            // comboInitialPosition1
            // 
            this.comboInitialPosition1.FormattingEnabled = true;
            this.comboInitialPosition1.Location = new System.Drawing.Point(0, 43);
            this.comboInitialPosition1.Name = "comboInitialPosition1";
            this.comboInitialPosition1.Size = new System.Drawing.Size(87, 21);
            this.comboInitialPosition1.TabIndex = 13;
            this.comboInitialPosition1.SelectedIndexChanged += new System.EventHandler(this.ComboInitialPosition1_SelectedIndexChanged);
            // 
            // EnigmaRotorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboInitialPosition1);
            this.Controls.Add(this.labelRotor1);
            this.Controls.Add(this.comboRotor1);
            this.Name = "EnigmaRotorControl";
            this.Size = new System.Drawing.Size(94, 69);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
