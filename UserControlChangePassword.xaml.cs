using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для UserControlChangePassword.xaml
    /// </summary>
    public partial class UserControlChangePassword : UserControl
    {
        db db;
        public User DataUser { get; set; }
        public UserControlChangePassword()
        {
            InitializeComponent();
            db = new db();
        }

        public void Clear_CurrentPasswordBorder()
        {
            CurrentPassword.ToolTip = null;
           CurrentPasswordBorder.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89000000"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string current_password = CurrentPassword.Password.Trim();
            string password_1 = Password_1.Password.Trim();
            string password_2 = Password_2.Password.Trim();
            bool check_password;

            RegisterWindow registerWindow = new RegisterWindow();

            if (DataUser.Password == current_password)
            {
                Clear_CurrentPasswordBorder();
                check_password = registerWindow.Check_Password(this.Password_1, this.Password_2, this.PasswordBorder_1, this.PasswordBorder_2, password_1, password_2);
            }
            else
            {
                CurrentPassword.ToolTip = "Введенный пароль не совпадает с текущим";
                CurrentPasswordBorder.BorderBrush = Brushes.Red;
                check_password = false;
            }

            if (check_password)
            {
                db.Users.Attach(DataUser);
                DataUser.Password = password_1;
                db.SaveChanges();
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
