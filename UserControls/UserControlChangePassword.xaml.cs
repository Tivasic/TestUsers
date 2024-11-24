using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TestUsers.models;

namespace TestUsers
{
    /// <summary>
    /// Логика взаимодействия для UserControlChangePassword.xaml
    /// </summary>
    public partial class UserControlChangePassword : UserControl
    {
        public Users DataUser { get; set; }

        public UserControlChangePassword()
        {
            InitializeComponent();
        }

        // Метод очистки поля пароля.
        private void ClearCurrentPasswordBorder()
        {
            CurrentPassword.ToolTip = null;
            CurrentPasswordBorder.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#89000000");
        }

        // Метод валидации паролей.
        private bool ValidatePasswords(string currentPassword, string newPassword1, string newPassword2)
        {
            if (DataUser.Password.Trim() != currentPassword)
            {
                CurrentPassword.ToolTip = "Введенный пароль не совпадает с текущим";
                CurrentPasswordBorder.BorderBrush = Brushes.Red;
                return false;
            }

            ClearCurrentPasswordBorder();

            RegisterWindow registerWindow = new RegisterWindow();
            return registerWindow.CheckPassword(Password_1, Password_2, PasswordBorder_1, PasswordBorder_2, newPassword1, newPassword2);
        }

        // Метод изменения пароля.
        private void ChangePassword(string newPassword)
        {
            DataUser = DataWorker.ChangePassword(DataUser, newPassword);
            Snackbar.MessageQueue.Enqueue("Вы успешно сменили пароль");
        }

        // Обработчик кнопки подтверждения смены данных.
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string currentPassword = CurrentPassword.Password.Trim();
            string newPassword1 = Password_1.Password.Trim();
            string newPassword2 = Password_2.Password.Trim();

            if (ValidatePasswords(currentPassword, newPassword1, newPassword2))
            {
                ChangePassword(newPassword1);
            }
            else
            {
                Snackbar.MessageQueue.Enqueue("Проверьте корректность данных");
            }
        }
    }
}

