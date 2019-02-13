using System;
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

namespace BookMan.WPF
{
    /// <summary>
    /// Interaction logic for ErrorWindow.xaml
    /// </summary>
    internal partial class ErrorControl : UserControl
    {
        //private string lastExceptionMessage;
        //private string lastExceptionString;

        public ErrorControl()
        {
            SetLastException(new NotImplementedException("This is just a test!", new StackOverflowException("Don't panic!", new OutOfMemoryException("It's getting serious now!"))));

            InitializeComponent();
        }

        public static readonly DependencyProperty LastExceptionMessageProperty = DependencyProperty.Register("LastExceptionMessage", typeof(string), typeof(ErrorControl), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty LastExceptionStringProperty = DependencyProperty.Register("LastExceptionString", typeof(string), typeof(ErrorControl), new PropertyMetadata(string.Empty));


        internal void SetLastException(Exception ex)
        {
            this.LastExceptionMessage = ex.Message;
            this.LastExceptionString = ex.ToString();
        }

        public string LastExceptionMessage
        {
            get 
            {
                return (string)GetValue(LastExceptionMessageProperty); 
            }
            set 
            { 
                SetValue(LastExceptionMessageProperty, value); 
            }
        }

        public string LastExceptionString
        {
            get 
            {
                return (string)GetValue(LastExceptionStringProperty); 
            }
            set
            {
                SetValue(LastExceptionStringProperty, value); 
            }
        }
    }
}
