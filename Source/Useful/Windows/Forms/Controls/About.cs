//-----------------------------------------------------------------------
// <copyright file="About.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>An about control for showing application information.</summary>
//-----------------------------------------------------------------------

namespace Useful.Windows.Forms.Controls
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using Useful.Resources;

    /// <summary>
    /// An about control for showing application information.
    /// </summary>
    internal partial class About : UserControl
    {
        internal About()
        {
            this.InitializeComponent();

            this.SetValues();
        }

        private void SetValues()
        {
            this.labelProductValue.Text = AssemblyInformation.Product;
            this.labelVersionValue.Text = "Version: " + AssemblyInformation.Version.ToString();
            this.labelCompanyValue.Text = AssemblyInformation.Company;
            this.labelCopyrightValue.Text = AssemblyInformation.Copyright;
            this.labelMachineValue.Text = Environment.MachineName;
            this.labelClrValue.Text = Environment.Version.ToString();
            this.labelOSValue.Text = Environment.OSVersion.VersionString;
            this.labelOSTypeValue.Text = Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit";
            this.labelProcessTypeValue.Text = Environment.Is64BitProcess ? "64-bit" : "32-bit";

            using (Stream file = ResourceManager.LoadAboutFile())
            {
                this.richAbout.LoadFile(file, RichTextBoxStreamType.RichText);
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
