using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TestUsers
{
    /// <summary>
    /// Логика взаимодействия для UserControlMainPage.xaml
    /// </summary>
    public partial class UserControlMainPage: UserControl
    {
        public UserControlMainPage()
        {
            InitializeComponent();
        }

        //Метод перехода на страницу сайта.
        private void AboutCompanyBorder_MouseLeftClick(object sender, RoutedEventArgs e)
        {
            Process.Start("http://www.kg.ru/company/about/");
        }

        //Метод перехода на страницу сайта.
        private void YourFeedbackBorder_MouseLeftClick(object sender, RoutedEventArgs e)
        {
            Process.Start("http://www.kg.ru/contacts/");
        }

        //Метод перехода на страницу сайта
        private void AboutTestBorder_MouseLeftClick(object sender, MouseButtonEventArgs e)
        {
            UserControl usc;
            usc = new UserControlManual();
            GridMain.Children.Add(usc);
        }
    }
}
