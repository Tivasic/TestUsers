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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        db db;
        public User DataUser { get; set; }
        public AuthWindow()
        {
            InitializeComponent();
            db = new db();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
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
                    
                    using (db context = new db())
                    {
                        DataUser = db.Users.Where(b => b.Login == login && b.Password == password).FirstOrDefault();

                    }

                    if (DataUser != null)
                    {
                        MessageBox.Show("Пользователь авторизовался");
                        MainWindow MainWindow = new MainWindow
                        {
                            DataUser = DataUser
                        };
                        MainWindow.ChangeUserName();
                        MainWindow.Show();
                        Close();
                    }
                    else MessageBox.Show("Пользователь не найден");
                }
            }
        }

        private void Button_Window_Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            Close();
        }
    }
}
