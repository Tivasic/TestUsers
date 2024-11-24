using System.Windows;
using System.Windows.Controls;
using TestUsers.UserControls;


namespace TestUsers
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Users DataUser { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            LoadInitialUserControl();
        }

        // Метод для загрузки начального UserControl.
        private void LoadInitialUserControl()
        {
            var initialControl = new UserControlMainPage();
            GridMain.Children.Add(initialControl);
        }

        public void BlockUserInteraction(bool block)
        {
            ListViewMenu.Visibility = block ? Visibility.Visible : Visibility.Collapsed;
        }

        // Метод отображающий имя и фамилию пользователя в шапке программы.
        public void ChangeUserName()
        {
            UserName.Text = DataUser.Name.Trim() + " " + DataUser.Surname.Trim();
        }

        // Метод реализующий функционал меню.
        public void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListView listView && listView.SelectedItem is ListViewItem selectedItem)
            {
                var selectedItemName = selectedItem.Name;
                UserControl newControl = null;

                switch (selectedItemName)
                {
                    case "TestSelection":
                        newControl = CreateUserControlTestSelection();
                        break;
                    case "MainPage":
                        newControl = new UserControlMainPage();
                        break;
                    case "Manual":
                        newControl = new UserControlManual();
                        break;
                    case "PersonalAccount":
                        newControl = CreatePersonalAccountControl();
                        break;
                    case "TestResults":
                        newControl = new UserControlTestResults();
                        break;
                    default:
                        break;
                }

                if (newControl != null)
                {
                    GridMain.Children.Clear();
                    GridMain.Children.Add(newControl);
                }
            }
        }

        // Создание и заполнение UserControlPersonalAccount.
        private UserControlTestSelection CreateUserControlTestSelection()
        {
            var testSelection = new UserControlTestSelection
            {
                DataUser = DataUser
            };
            return testSelection;

        }

        // Создание и заполнение UserControlPersonalAccount.
        private UserControlPersonalAccount CreatePersonalAccountControl()
        {
            var personalAccountControl = new UserControlPersonalAccount
            {
                DataUser = DataUser
            };
            personalAccountControl.FillingFields();
            return personalAccountControl;
        }

        // Метод отвечающий за выход из учетной записи.
        private void ButtonClickAccountExit(object sender, RoutedEventArgs e)
        {
            var authWindow = new AuthWindow();
            authWindow.Show();
            Close();
        }

        // Метод отвечающий за выход из программы.
        private void ButtonClickProgrammExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
