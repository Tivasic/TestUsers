using System;
using System.Windows;
using System.Windows.Controls;

namespace TestUsers
{
    /// <summary>
    /// Логика взаимодействия для UserControlResult.xaml
    /// </summary>
    public partial class UserControlResult : UserControl
    {
        public TimeSpan TimeResult { get; set; }
        public int TestResult { get; set; }

        public UserControlResult()
        {
            InitializeComponent();
        }

        //Метод записи результатов тестов в поля на форме.
        public void RecordResult()
        {
            LabelResult.Content = TestResult + "%";
            LabelTimeResult.Content = TimeResult.ToString("mm\\:ss");
        }

        //Метод кнопки открытия главного меню.
        private void OpenMainWindowButton_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc;
            usc = new UserControlMainPage();
            GridMain.Children.Add(usc);
        }
    }
}
