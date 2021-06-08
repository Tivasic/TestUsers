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
        public User DataUser { get; set; }
        public UserControlChangePassword()
        {
            InitializeComponent();
        }

        //Метод очистки поля пароля.
        public void ClearCurrentPasswordBorder()
        {
            CurrentPassword.ToolTip = null;
           CurrentPasswordBorder.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89000000"));
        }

        //Метод отвечающий за кнопку подтверждения смены данных.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.ChangeUserName();
            string Current_Password = CurrentPassword.Password.Trim();
            string NewPassword_1 = Password_1.Password.Trim();
            string NewPassword_2 = Password_2.Password.Trim();
            bool check_password;

            RegisterWindow registerWindow = new RegisterWindow();

            if (DataUser.Password.Trim() == Current_Password)
            {
                ClearCurrentPasswordBorder();
                check_password = registerWindow.CheckPassword(this.Password_1, this.Password_2, this.PasswordBorder_1, this.PasswordBorder_2, NewPassword_1, NewPassword_2);
            }
            else
            {
                CurrentPassword.ToolTip = "Введенный пароль не совпадает с текущим";
                CurrentPasswordBorder.BorderBrush = Brushes.Red;
                check_password = false;
            }

            if (check_password)
            {
                DataUser = DataWorker.ChangePassword(DataUser, NewPassword_1);
                MainWindow mainWindow = new MainWindow
                {
                   DataUser = DataUser
                };
                TextResult.Text = "Вы успешно сменили пароль";
            }
            else
            {
                TextResult.Text = "Повторите попытку";
            }
        }
    }
}
