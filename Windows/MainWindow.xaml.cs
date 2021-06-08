using System.Windows;
using System.Windows.Controls;

namespace TestUsers
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
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

        //Метод отображающий имя и фамилия пользователя в шапке программы.
        public void ChangeUserName()
        {
            if (DataUser == null)
            {
                this.UserName.Text = "User";
            }
            else
            {
                this.UserName.Text = DataUser.Name.Trim() + " " + DataUser.Surname.Trim();
            }
        }

        //Метод реализующий функционал меню.
        public void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            UserControl usc;
            ChangeUserName();
            GridMain.Children.Clear();
            string CurrentItem;
            CurrentItem = (((ListViewItem)((ListView)sender).SelectedItem).Name);

            if (CurrentItem == "TestSelection")
            {
                usc = new UserControlTestSelection();
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

        //Метод отвечающий за выход из учетной записи.
        private void Button_Click_Account_Exit(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Close();
        }

        //Метод отвечающий за выход из программы.
        private void Button_Click_Programm_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}