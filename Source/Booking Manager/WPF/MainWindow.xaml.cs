namespace BookMan.WPF
{
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
    using System.Windows.Media.Animation;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Threading;
    using System.Data;
    using System.IO;
    using System.Diagnostics;
    using BookMan.Data;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    internal partial class MainWindow : Window
    {
        private Mutex singleInstanceMutex;
        private UserControl currentPanel;
        private readonly TimeSpan AnimationSpan = new TimeSpan(0, 0, 0, 0, 500);

        public MainWindow()
        {
            this.Loaded += new RoutedEventHandler(Window_Loaded);

            bool firstInstance;

            singleInstanceMutex = new Mutex(true, @"Global\" + AssemblyInformation.Guid().ToString(), out firstInstance);
            GC.KeepAlive(singleInstanceMutex);

            // Check for other instances of the application
            if (!firstInstance)
            {
                Console.WriteLine("Other instance detected; aborting.");
                //Console.ReadKey();
                Application.Current.Shutdown();
            }

            InitializeComponent();

            UserControl nextPanel = this.bookingsPanel;

            try
            {
                // TODO: On exception quit
                Settings.DatabaseVersion = DataAccess.UpgradeDatabase();

                Version appVersion = AssemblyInformation.Version();

                if (appVersion < Settings.DatabaseVersion)
                {
                    // TODO: You need to upgrade! message
                    // TODO: Error message panel
                    throw new BookManException("You need to upgrade!");
                }
            }
            catch (Exception ex)
            {
                nextPanel = this.errorPanel;
                this.errorPanel.SetLastException(ex);
            }

            SwitchPanel(nextPanel);
        }

        void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // SwitchPanel(this.peopleData);

            //Rectangle r = new Rectangle();
            //r.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            //r.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            
            //ColorAnimation ca = new ColorAnimation(Color.FromArgb(255, 0, 0, 0), Color.FromArgb(0, 0, 0, 255), new Duration(new TimeSpan(0, 0, 5)));

            //Storyboard s = new Storyboard();
            //Storyboard.SetTargetName(ca, "r");
            //Storyboard.SetTargetProperty(ca, new PropertyPath("Fill"));
            //s.Children.Add(ca);
            //s.Begin();
        }

        private void buttonPeople_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // TODO: Run on thread
                this.peoplePanel.TestLoad();

                SwitchPanel(this.peoplePanel);
            }
            catch (Exception ex)
            {
                this.errorPanel.SetLastException(ex);
                SwitchPanel(this.errorPanel);
            }
        }

        private void buttonBookings_Click(object sender, RoutedEventArgs e)
        {
            SwitchPanel(this.bookingsPanel);
        }

        private void buttonSettings_Click(object sender, RoutedEventArgs e)
        {
            SwitchPanel(this.settingsPanel);
        }

        private void buttonError_Click(object sender, RoutedEventArgs e)
        {
            SwitchPanel(this.errorPanel);
        }

        private void buttonStyle_Click(object sender, RoutedEventArgs e)
        {
            SwitchPanel(this.stylePanel);
        }

        private void SwitchPanel(UserControl next)
        {
            if (next == currentPanel)
            {
                return;
            }

            Storyboard sb = new Storyboard();

            sb.Children.Add(SlideNextIn(next));

            if (this.currentPanel != null)
            {
                sb.Children.Add(SlideCurrentOut());
            }

            sb.Children.Add(FadeNextIn(next));

            if (this.currentPanel != null)
            {
                sb.Children.Add(FadeCurrentOut());
            }

            sb.Begin();

            this.currentPanel = next;
            // this.currentButton = button;
        }

        private ThicknessAnimation SlideNextIn(UserControl next)
        {
            ThicknessAnimation slideIn = new ThicknessAnimation
            {
                From = new Thickness(-grid1.ColumnDefinitions[1].ActualWidth, 0, grid1.ColumnDefinitions[1].ActualWidth, 0),
                To = new Thickness(0, 0, 0, 0),
                // AccelerationRatio = 0.25,
                FillBehavior = FillBehavior.Stop,
                // DecelerationRatio = 0.25,
                Duration = new Duration(AnimationSpan)
            };
            Storyboard.SetTarget(slideIn, next);
            Storyboard.SetTargetProperty(slideIn, new PropertyPath(MarginProperty));

            return slideIn;
        }

        private ThicknessAnimation SlideCurrentOut()
        {
            if (this.currentPanel == null)
            {
                return null;
            }

            ThicknessAnimation slideOut = new ThicknessAnimation
            {
                From = new Thickness(0, 0, 0, 0),
                To = new Thickness(grid1.ColumnDefinitions[1].ActualWidth, 0, -grid1.ColumnDefinitions[1].ActualWidth, 0),
                // AccelerationRatio = 0.25,
                FillBehavior = FillBehavior.Stop,
                // DecelerationRatio = 0.25,
                Duration = new Duration(AnimationSpan)
            };
            Storyboard.SetTarget(slideOut, this.currentPanel);
            Storyboard.SetTargetProperty(slideOut, new PropertyPath(MarginProperty));

            return slideOut;
        }

        private DoubleAnimation FadeNextIn(UserControl next)
        {
            DoubleAnimation fadeIn = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = new Duration(AnimationSpan)
            };
            Storyboard.SetTarget(fadeIn, next);
            Storyboard.SetTargetProperty(fadeIn, new PropertyPath(OpacityProperty));
            return fadeIn;
        }

        private DoubleAnimation FadeCurrentOut()
        {
            if (this.currentPanel == null)
            {
                return null;
            }

            DoubleAnimation fadeOut = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = new Duration(AnimationSpan)
            };
            Storyboard.SetTarget(fadeOut, this.currentPanel);
            Storyboard.SetTargetProperty(fadeOut, new PropertyPath(OpacityProperty));
            return fadeOut;
        }
    }
}
