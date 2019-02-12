using System;
namespace Useful.Windows.Forms.Controls
{
    partial class About
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
            this.richAbout = new System.Windows.Forms.RichTextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelProductValue = new System.Windows.Forms.Label();
            this.labelOS = new System.Windows.Forms.Label();
            this.labelOSValue = new System.Windows.Forms.Label();
            this.labelClr = new System.Windows.Forms.Label();
            this.labelClrValue = new System.Windows.Forms.Label();
            this.groupEnvironment = new System.Windows.Forms.GroupBox();
            this.labelProcessTypeValue = new System.Windows.Forms.Label();
            this.labelProcessType = new System.Windows.Forms.Label();
            this.labelOSTypeValue = new System.Windows.Forms.Label();
            this.labelOSType = new System.Windows.Forms.Label();
            this.labelMachineValue = new System.Windows.Forms.Label();
            this.labelMachine = new System.Windows.Forms.Label();
            this.groupProduct = new System.Windows.Forms.GroupBox();
            this.labelCopyrightValue = new System.Windows.Forms.Label();
            this.labelCompanyValue = new System.Windows.Forms.Label();
            this.labelVersionValue = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupEnvironment.SuspendLayout();
            this.groupProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // richAbout
            // 
            this.richAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richAbout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richAbout.Location = new System.Drawing.Point(0, 183);
            this.richAbout.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.richAbout.Name = "richAbout";
            this.richAbout.ReadOnly = true;
            this.richAbout.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richAbout.Size = new System.Drawing.Size(543, 294);
            this.richAbout.TabIndex = 0;
            this.richAbout.Text = "";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(0, 134);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(128, 43);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = global::Useful.Resource.Close;
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // labelProductValue
            // 
            this.labelProductValue.AutoSize = true;
            this.labelProductValue.Location = new System.Drawing.Point(6, 16);
            this.labelProductValue.Name = "labelProductValue";
            this.labelProductValue.Size = new System.Drawing.Size(74, 13);
            this.labelProductValue.TabIndex = 5;
            this.labelProductValue.Text = "<placeholder>";
            // 
            // labelOS
            // 
            this.labelOS.AutoSize = true;
            this.labelOS.Location = new System.Drawing.Point(6, 16);
            this.labelOS.Name = "labelOS";
            this.labelOS.Size = new System.Drawing.Size(22, 13);
            this.labelOS.TabIndex = 1;
            this.labelOS.Text = "OS";
            // 
            // labelOSValue
            // 
            this.labelOSValue.AutoSize = true;
            this.labelOSValue.Location = new System.Drawing.Point(88, 16);
            this.labelOSValue.Name = "labelOSValue";
            this.labelOSValue.Size = new System.Drawing.Size(74, 13);
            this.labelOSValue.TabIndex = 2;
            this.labelOSValue.Text = "<placeholder>";
            // 
            // labelClr
            // 
            this.labelClr.AutoSize = true;
            this.labelClr.Location = new System.Drawing.Point(6, 42);
            this.labelClr.Name = "labelClr";
            this.labelClr.Size = new System.Drawing.Size(70, 13);
            this.labelClr.TabIndex = 3;
            this.labelClr.Text = ".NET Version";
            // 
            // labelClrValue
            // 
            this.labelClrValue.AutoSize = true;
            this.labelClrValue.Location = new System.Drawing.Point(88, 42);
            this.labelClrValue.Name = "labelClrValue";
            this.labelClrValue.Size = new System.Drawing.Size(74, 13);
            this.labelClrValue.TabIndex = 4;
            this.labelClrValue.Text = "<placeholder>";
            // 
            // groupEnvironment
            // 
            this.groupEnvironment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupEnvironment.Controls.Add(this.labelProcessTypeValue);
            this.groupEnvironment.Controls.Add(this.labelProcessType);
            this.groupEnvironment.Controls.Add(this.labelOSTypeValue);
            this.groupEnvironment.Controls.Add(this.labelOSType);
            this.groupEnvironment.Controls.Add(this.labelMachineValue);
            this.groupEnvironment.Controls.Add(this.labelMachine);
            this.groupEnvironment.Controls.Add(this.labelOS);
            this.groupEnvironment.Controls.Add(this.labelOSValue);
            this.groupEnvironment.Controls.Add(this.labelClrValue);
            this.groupEnvironment.Controls.Add(this.labelClr);
            this.groupEnvironment.Location = new System.Drawing.Point(134, 88);
            this.groupEnvironment.Name = "groupEnvironment";
            this.groupEnvironment.Size = new System.Drawing.Size(406, 89);
            this.groupEnvironment.TabIndex = 6;
            this.groupEnvironment.TabStop = false;
            this.groupEnvironment.Text = "Environment";
            // 
            // labelProcessTypeValue
            // 
            this.labelProcessTypeValue.AutoSize = true;
            this.labelProcessTypeValue.Location = new System.Drawing.Point(88, 55);
            this.labelProcessTypeValue.Name = "labelProcessTypeValue";
            this.labelProcessTypeValue.Size = new System.Drawing.Size(74, 13);
            this.labelProcessTypeValue.TabIndex = 10;
            this.labelProcessTypeValue.Text = "<placeholder>";
            // 
            // labelProcessType
            // 
            this.labelProcessType.AutoSize = true;
            this.labelProcessType.Location = new System.Drawing.Point(6, 55);
            this.labelProcessType.Name = "labelProcessType";
            this.labelProcessType.Size = new System.Drawing.Size(72, 13);
            this.labelProcessType.TabIndex = 9;
            this.labelProcessType.Text = "Process Type";
            // 
            // labelOSTypeValue
            // 
            this.labelOSTypeValue.AutoSize = true;
            this.labelOSTypeValue.Location = new System.Drawing.Point(88, 29);
            this.labelOSTypeValue.Name = "labelOSTypeValue";
            this.labelOSTypeValue.Size = new System.Drawing.Size(74, 13);
            this.labelOSTypeValue.TabIndex = 8;
            this.labelOSTypeValue.Text = "<placeholder>";
            // 
            // labelOSType
            // 
            this.labelOSType.AutoSize = true;
            this.labelOSType.Location = new System.Drawing.Point(6, 29);
            this.labelOSType.Name = "labelOSType";
            this.labelOSType.Size = new System.Drawing.Size(49, 13);
            this.labelOSType.TabIndex = 7;
            this.labelOSType.Text = "OS Type";
            // 
            // labelMachineValue
            // 
            this.labelMachineValue.AutoSize = true;
            this.labelMachineValue.Location = new System.Drawing.Point(88, 68);
            this.labelMachineValue.Name = "labelMachineValue";
            this.labelMachineValue.Size = new System.Drawing.Size(74, 13);
            this.labelMachineValue.TabIndex = 6;
            this.labelMachineValue.Text = "<placeholder>";
            // 
            // labelMachine
            // 
            this.labelMachine.AutoSize = true;
            this.labelMachine.Location = new System.Drawing.Point(6, 68);
            this.labelMachine.Name = "labelMachine";
            this.labelMachine.Size = new System.Drawing.Size(48, 13);
            this.labelMachine.TabIndex = 5;
            this.labelMachine.Text = "Machine";
            // 
            // groupProduct
            // 
            this.groupProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupProduct.Controls.Add(this.labelCopyrightValue);
            this.groupProduct.Controls.Add(this.labelCompanyValue);
            this.groupProduct.Controls.Add(this.labelVersionValue);
            this.groupProduct.Controls.Add(this.labelProductValue);
            this.groupProduct.Location = new System.Drawing.Point(134, 4);
            this.groupProduct.Name = "groupProduct";
            this.groupProduct.Size = new System.Drawing.Size(406, 78);
            this.groupProduct.TabIndex = 7;
            this.groupProduct.TabStop = false;
            this.groupProduct.Text = "Product";
            // 
            // labelCopyrightValue
            // 
            this.labelCopyrightValue.AutoSize = true;
            this.labelCopyrightValue.Location = new System.Drawing.Point(6, 55);
            this.labelCopyrightValue.Name = "labelCopyrightValue";
            this.labelCopyrightValue.Size = new System.Drawing.Size(74, 13);
            this.labelCopyrightValue.TabIndex = 8;
            this.labelCopyrightValue.Text = "<placeholder>";
            // 
            // labelCompanyValue
            // 
            this.labelCompanyValue.AutoSize = true;
            this.labelCompanyValue.Location = new System.Drawing.Point(6, 42);
            this.labelCompanyValue.Name = "labelCompanyValue";
            this.labelCompanyValue.Size = new System.Drawing.Size(74, 13);
            this.labelCompanyValue.TabIndex = 7;
            this.labelCompanyValue.Text = "<placeholder>";
            // 
            // labelVersionValue
            // 
            this.labelVersionValue.AutoSize = true;
            this.labelVersionValue.Location = new System.Drawing.Point(6, 29);
            this.labelVersionValue.Name = "labelVersionValue";
            this.labelVersionValue.Size = new System.Drawing.Size(74, 13);
            this.labelVersionValue.TabIndex = 6;
            this.labelVersionValue.Text = "<placeholder>";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = global::Useful.Resource.Hawky_128_4;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(128, 128);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(128, 128);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupProduct);
            this.Controls.Add(this.groupEnvironment);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.richAbout);
            this.Name = "About";
            this.Size = new System.Drawing.Size(543, 477);
            this.groupEnvironment.ResumeLayout(false);
            this.groupEnvironment.PerformLayout();
            this.groupProduct.ResumeLayout(false);
            this.groupProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richAbout;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelProductValue;
        private System.Windows.Forms.Label labelOS;
        private System.Windows.Forms.Label labelOSValue;
        private System.Windows.Forms.Label labelClr;
        private System.Windows.Forms.Label labelClrValue;
        private System.Windows.Forms.GroupBox groupEnvironment;
        private System.Windows.Forms.GroupBox groupProduct;
        private System.Windows.Forms.Label labelMachineValue;
        private System.Windows.Forms.Label labelMachine;
        private System.Windows.Forms.Label labelVersionValue;
        private System.Windows.Forms.Label labelCompanyValue;
        private System.Windows.Forms.Label labelCopyrightValue;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelOSTypeValue;
        private System.Windows.Forms.Label labelOSType;
        private System.Windows.Forms.Label labelProcessTypeValue;
        private System.Windows.Forms.Label labelProcessType;
    }
}
