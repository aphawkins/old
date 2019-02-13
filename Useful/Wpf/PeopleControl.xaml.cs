
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
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Data;
    using BookMan.Data;

    /// <summary>
    /// Interaction logic for People.xaml
    /// </summary>
    internal partial class PeopleControl : UserControl
    {
        DataAccess a;
        Guid requestId;

        public PeopleControl()
        {
            InitializeComponent();

            this.a = new DataAccess();
            this.a.GetPersonDatasetCompleted += new EventHandler<GetPersonDatasetEventArgs>(a_GetPersonDatasetCompleted);
        }

        void MainWindow_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            // throw new NotImplementedException();
        }

        public void TestLoad()
        {
            this.requestId = Guid.NewGuid();

            a.GetPersonAsync(1, this.requestId);
        }

        private void a_GetPersonDatasetCompleted(object sender, GetPersonDatasetEventArgs e)
        {
            Guid taskId = (Guid)e.UserState;

            if (e.Cancelled 
                || e.Error != null
                || this.requestId != taskId)
            {
                return;
            }

            this.DataContext = e.PersonDataset.Tables[0];
        }
    }
}
