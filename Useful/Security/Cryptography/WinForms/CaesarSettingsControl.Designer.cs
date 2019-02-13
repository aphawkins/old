namespace Useful.Windows.Forms.Controls
{
    public partial class CaesarSettingsControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboShift = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Shift";
            // 
            // comboShift
            // 
            this.comboShift.FormattingEnabled = true;
            this.comboShift.Location = new System.Drawing.Point(78, 6);
            this.comboShift.Name = "comboShift";
            this.comboShift.Size = new System.Drawing.Size(72, 21);
            this.comboShift.TabIndex = 5;
            this.comboShift.Text = "shift";
            this.comboShift.SelectedIndexChanged += new System.EventHandler(this.comboShift_SelectedIndexChanged);
            // 
            // CaesarSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboShift);
            this.Name = "CaesarSettings";
            this.Size = new System.Drawing.Size(161, 37);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboShift;
    }
}
