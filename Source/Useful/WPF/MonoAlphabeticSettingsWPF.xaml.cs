using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Useful.Security.Cryptography;

namespace Useful.Useful.WPF
{
    /// <summary>
    /// Interaction logic for MonoAlphabeticSettings.xaml
    /// </summary>
    public partial class MonoAlphabeticSettingsWPF : UserControl
    {
        private MonoAlphabeticSettings monoSettings = new MonoAlphabeticSettings();

        public MonoAlphabeticSettingsWPF()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var v in monoSettings)
            {

            }
        }
    }
}
