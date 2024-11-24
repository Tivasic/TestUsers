using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TestUsers.models;
using System.Windows.Controls;

namespace TestUsers
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public Users DataUser { get; set; }

        public AuthWindow()
        {
            InitializeComponent();
        }

        // Метод реализующий авторизацию пользователя.
        private void ButtonAuthClick(object sender, RoutedEventArgs e)
        {
            string login = Login.Text.Trim();
            string password = Password.Password.Trim();

            ValidateInput(login, password);
            DataUser = DataWorker.AuthUser(login, password);
            if (DataUser == null)
            {
                Snackbar.MessageQueue.Enqueue("Проверьте корректность данных");
            }
            else
            {
                var mainWindow = new MainWindow
                {
                    DataUser = DataUser
                };
                mainWindow.ChangeUserName();
                mainWindow.Show();
                Close();
            }
        }

        // Метод для валидации ввода логина и пароля.
        private void ValidateInput(string login, string password)
        {
            if (login.Length < 5)
            {
                SetValidationError(Login, "Введите логин");
            }
            else
            {
                ClearValidationError(Login);
            }

            if (password.Length < 5)
            {
                SetValidationError(Password, "Введите пароль");
            }
            else
            {
                ClearValidationError(Password);
            }
        }

        // Метод для установки ошибки валидации.
        private void SetValidationError(Control control, string errorMessage)
        {
            control.ToolTip = errorMessage;
            control.BorderBrush = Brushes.Red;
            if (control is PasswordBox box)
            {
                box.CaretBrush = Brushes.Red;
            }
        }

        // Метод для очистки ошибки валидации.
        private void ClearValidationError(Control control)
        {
            control.ToolTip = null;
            control.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89000000"));
            if (control is PasswordBox box)
            {
                box.CaretBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89000000"));
            }
        }

        // Метод перехода на окно регистрации.
        private void OpenRegisterWindowButtonClick(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegisterWindow();
            registerWindow.Show();
            Close();
        }

        // Метод отвечающий за отклик клавиши 'Enter'.
        private void TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ButtonAuthClick(sender, e);
            }
        }
    }
}
