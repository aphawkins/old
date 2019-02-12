﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Useful;

namespace BookMan.WPF
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    internal partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();

            textDBPath.Text = Settings.DatabasePath;
            if (Settings.DatabaseVersion != null)
            {
                labelDBVersion.Content = Settings.DatabaseVersion.ToString(4);
            }
            else
            {
                labelDBVersion.Content = "Unknown";
            }
            labelAppVersion.Content = AssemblyInformation.Version().ToString(4);
        }
    }
}
