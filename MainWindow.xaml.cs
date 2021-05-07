using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public User DataUser { get; set; }
 
        public MainWindow()
        {

            InitializeComponent();
            UserControl usc;
            usc = new UserControlMainPage();
            GridMain.Children.Add(usc);
        }

        public void ChangeUserName()
        {
            if (DataUser == null)
            {
                this.UserName.Text = "User";
            }
            else
            {
                this.UserName.Text = DataUser.Name + " " + DataUser.Surname;
            }
        }

        public void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            UserControl usc;
            ChangeUserName();
            GridMain.Children.Clear();
            string CurrentItem;
            CurrentItem = (((ListViewItem)((ListView)sender).SelectedItem).Name);

            if (CurrentItem == "StartTest")
            {
                usc = new UserControlTestPage();
                GridMain.Children.Add(usc);

            }

            if (CurrentItem == "MainPage")
            {
                usc = new UserControlMainPage();
                GridMain.Children.Add(usc);

            }
            if (CurrentItem == "Manual")
            {
                usc = new UserControlManual();
                GridMain.Children.Add(usc);
            }

            if (CurrentItem == "PersonalAccount")
            {
                UserControlPersonalAccount usc1 = new UserControlPersonalAccount
                {
                    DataUser = DataUser
                };
                usc1.FillingFields();
                GridMain.Children.Add(usc1);
            }
        }

        private void Button_Click_Account_Exit(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Close();
        }

        private void Button_Click_Programm_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}