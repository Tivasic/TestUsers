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
        public void ShowResult()
        {
            LabelResult.Content = TestResult + "%";
            LabelTimeResult.Content = TimeResult.ToString("mm\\:ss");
        }

        //Метод кнопки открытия главного меню.
        private void OpenMainWindowButtonClick(object sender, RoutedEventArgs e)
        {
            var mainPageControl = new UserControlMainPage();
            GridMain.Children.Add(mainPageControl);
        }
    }
}
