//-----------------------------------------------------------------------
// <copyright file="MonoAlphabeticSettingsWPF.xaml.cs" company="APH Software">
// Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>The mono alphabetic settings form.</summary>
//-----------------------------------------------------------------------

namespace Useful.Wpf
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using Useful.Security.Cryptography;

    /// <summary>
    /// Form that binds to the mono alphabetic settings.
    /// </summary>
    public partial class MonoAlphabeticSettingsWpf : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MonoAlphabeticSettingsWpf"/> class.
        /// </summary>
        public MonoAlphabeticSettingsWpf()
        {
            this.MonoSettings = MonoAlphabeticSettingsObservableCollection.GetRandom();

            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the collection property to bind to.
        /// </summary>
        /// <value>The name of the settings collection.</value>
        public MonoAlphabeticSettingsObservableCollection MonoSettings
        {
            get;
            private set;
        }

        /// <summary>
        /// Handler for the reset button click event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object that contains the event data.</param>
        private void ResetButtonClick(object sender, RoutedEventArgs e)
        {
            this.MonoSettings.Reset();
        }

        /// <summary>
        /// Handler for the substitution dropdown closed event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object that contains the event data.</param>
        private void SubstitutionDropDownClosed(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            this.MonoSettings[(char)cb.Tag] = (char)cb.SelectedItem;
        }
    }
}