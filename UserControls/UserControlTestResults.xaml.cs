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
using TestUsers.models;

namespace TestUsers.UserControls
{
    /// <summary>
    /// Логика взаимодействия для UserControlTestResults.xaml
    /// </summary>
    public partial class UserControlTestResults : UserControl
    {
        public int TestResult { get; set; }
        public TimeSpan TimeResult { get; set; }
        public string TestName { get; set; }
        public int CorrectAnswersCount { get; set; }
        public DateTime TestDate { get; set; }
        public TimeSpan TestDuration { get; set; }

        public UserControlTestResults()
        {
            InitializeComponent();
            LoadResults();
        }

        private void LoadResults()
        {
            var results = DataWorker.LoadResults();
            ResultsDataGrid.ItemsSource = results;
        }
    }
}
