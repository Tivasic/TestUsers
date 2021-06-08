using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TestUsers.models;

namespace TestUsers
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public User DataUser { get; set; }
        public AuthWindow()
        {
            InitializeComponent();
        }

        //Метод реализующий авторизацию пользователя.
        public void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text.Trim();
            string password = Password.Password.Trim();

            if (login.Length < 5)
            {
                Login.ToolTip = "Введите логин";
                Login.BorderBrush = Brushes.Red;
                Login.CaretBrush = Brushes.Red;
            }
            else
            {
                Login.ToolTip = null;
                Login.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89000000"));
            }

            if (password.Length < 5)
            {
                Password.ToolTip = "Введите пароль";
                Password.BorderBrush = Brushes.Red;
            }
            else
            {
                Password.ToolTip = null;
                Password.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89000000"));
            }

            if (login.Length >= 5)
            {
                if (password.Length >= 5)
                {
                    DataUser = DataWorker.AuthUser(login, password);

                    if (DataUser != null)
                    {
                        this.TextResult.Text = "Вы успешно авторизовались!";
                    }
                    else this.TextResult.Text = "Пользователь не найден";
                }
            }
            else this.TextResult.Text = "Некорректные данные!";
        }

        //Метод перехода на окно регистрации.
        private void Hyperlink_Window_Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }

        //Метод кнопки на диалоговом окне.
        private void Dialog_Button(object sender, RoutedEventArgs e)
        {
            if (TextResult.Text == "Вы успешно авторизовались!")
            {
                MainWindow MainWindow = new MainWindow
                {
                    DataUser = DataUser
                };
                MainWindow.ChangeUserName();
                MainWindow.Show();
                this.Close();
            }
        }

        //Метод отвечающий за отклик клавиши 'Enter'.
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Auth_Click(sender, e);
                DialogResult.IsOpen = true;
            }
        }
    }
}