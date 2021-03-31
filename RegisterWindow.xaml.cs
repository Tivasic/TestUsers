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
using System.Windows.Shapes;

namespace TestUsers
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        db db;
        public RegisterWindow()
        {
            InitializeComponent();
            db = new db();
        }

        private void Clear_PasswordBorder_1()
        {
            PasswordBorder_1.ToolTip = null;
            PasswordBorder_1.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89000000"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = null;
            regex = new System.Text.RegularExpressions.Regex("^([0-9])*$");

            string login = Login.Text.Trim();
            string password_1 = Password_1.Password.Trim();
            string password_2 = Password_2.Password.Trim();
            string name = Name.Text.Trim();
            string surname = Surname.Text.Trim();
            string company = Company.Text.Trim();

            if (login.Length < 5)
            {
                Login.ToolTip = "Это поле введено некорректно!";
                LoginBorder.BorderBrush = Brushes.Red;
            }
            else
            {
                Login.ToolTip = null;
                LoginBorder.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89000000"));
            }

            if (password_1.Length >= 5)
            {
                bool en = true;
                bool number = false;

                for (int i = 0; i < password_1.Length; i++)
                {
                    if (password_1[i] >= 'А' & password_1[i] <= 'Я') en = false;
                    if (password_1[i] >= '0' & password_1[i] <= '9') number = true;
                }
                if (!en)
                {
                    Password_1.ToolTip = "Доступна английская раскладка";
                    PasswordBorder_1.BorderBrush = Brushes.Red;
                }
                else
                {
                    Clear_PasswordBorder_1();
                    if (!number)
                    {
                        Password_1.ToolTip = "Добавьте минимум одну цифру";
                        PasswordBorder_1.BorderBrush = Brushes.Red;
                    }
                    else
                    {
                        Clear_PasswordBorder_1();
                        if (password_1 != password_2)
                        {
                            PasswordBorder_1.BorderBrush = Brushes.Red;
                            PasswordBorder_2.BorderBrush = Brushes.Red;
                            Password_1.ToolTip = "Пароли не совпадают";
                            Password_2.ToolTip = "Пароли не совпадают";
                        }
                        else
                        {
                            Clear_PasswordBorder_1();
                        }
                    }
                }
            }
            else
            {
                Password_1.ToolTip = "Пароль минимум 5 символов";
                Password_2.ToolTip = "Пароль минимум 5 символов";
                PasswordBorder_1.BorderBrush = Brushes.Red;
                PasswordBorder_2.BorderBrush = Brushes.Red;
            }

            if (name.Length >= 2)
            {
                bool ru = true;

                for (int i = 0; i < name.Length; i++)
                {
                    if (name[i] >= 'A' & name[i] <= 'Z') ru = false;
                }

                if (!ru)
                {
                    Name.ToolTip = "Доступна русская раскладка";
                    NameBorder.BorderBrush = Brushes.Red;
                }
                else
                {
                    Name.ToolTip = null;
                    NameBorder.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89000000"));
                    if (regex.IsMatch(Name.Text))
                    {
                        Name.ToolTip = null;
                        NameBorder.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89000000"));
                    }
                    else
                    {
                        Name.ToolTip = "Запрещен ввод цифр и символов";
                        NameBorder.BorderBrush = Brushes.Red;
                    }
                }
            }

            else
            {
                Name.ToolTip = "Некорректное имя";
                NameBorder.BorderBrush = Brushes.Red;
            }


            //MessageBox.Show("GOOD");
            //User user = new User(login, password, name, surname, company);
            //db.Users.Add(user);
            //db.SaveChanges();

            //else if (name.Length < 3)
            //{
            //    Name.ToolTip = "Это поле введено некорректно!";
            //    Name.BorderBrush = Brushes.Red;
            //}

            //else if (surname.Length < 4)
            //{
            //    Surname.ToolTip = "Это поле введено некорректно!";
            //    Surname.BorderBrush = Brushes.Red;
            //}

            // else if (company.Length < 5)
            // {
            //    Company.ToolTip = "Это поле введено некорректно!";
            //     Company.BorderBrush = Brushes.Red;
            // }

        }

        private void PackIcon_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
