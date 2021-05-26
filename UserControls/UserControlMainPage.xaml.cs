using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace TestUsers
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class UserControlMainPage: UserControl
    {
        public UserControlMainPage()
        {
            InitializeComponent();
        }

        private void AboutCompanyBorder_MouseLeftClick(object sender, RoutedEventArgs e)
        {
            Process.Start("http://www.kg.ru/company/about/");
        }

        private void YourFeedbackBorder_MouseLeftClick(object sender, RoutedEventArgs e)
        {
            Process.Start("http://www.kg.ru/contacts/");
        }

        private void AboutTestBorder_MouseLeftClick(object sender, MouseButtonEventArgs e)
        {
            UserControl usc;
            usc = new UserControlManual();
            GridMain.Children.Add(usc);
        }
    }
}
