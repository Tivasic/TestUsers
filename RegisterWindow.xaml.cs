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
            Password_1.ToolTip = null;
            PasswordBorder_1.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89000000"));
        }

        private void Clear_PasswordBorder_2()
        {
            Password_2.ToolTip = null;
            PasswordBorder_2.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89000000"));
        }

        private Boolean Check_Login(string login)
        {
            if (login.Length < 5)
            {
                Login.ToolTip = "Это поле введено некорректно!";
                LoginBorder.BorderBrush = Brushes.Red;
                return false;
            }
            User uniq_login = null;
            using (db context = new db())
            {
                uniq_login = db.Users.Where(b => b.Login == login).FirstOrDefault();

            }
            if (uniq_login != null)
            {
                Login.ToolTip = "Этот логин зарегистрирован";
                LoginBorder.BorderBrush = Brushes.Red;
                return false;
            }

            Login.ToolTip = null;
            LoginBorder.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89000000"));
            return true;

        }

        private Boolean Check_Password(string password_1, string password_2)
        {
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
                    Password_1.ToolTip = "Доступна только английская раскладка";
                    PasswordBorder_1.BorderBrush = Brushes.Red;
                    return false;
                }
                Clear_PasswordBorder_1();
                if (!number)
                {
                    Password_1.ToolTip = "Добавьте минимум одну цифру";
                    PasswordBorder_1.BorderBrush = Brushes.Red;
                    return false;
                }
                Clear_PasswordBorder_1();
                if (password_1 != password_2)
                {
                    PasswordBorder_1.BorderBrush = Brushes.Red;
                    PasswordBorder_2.BorderBrush = Brushes.Red;
                    Password_1.ToolTip = "Пароли не совпадают";
                    Password_2.ToolTip = "Пароли не совпадают";
                    return false;
                }
                Clear_PasswordBorder_1();
                Clear_PasswordBorder_2();
                return true;
            }
            Password_1.ToolTip = "Пароль минимум 5 символов";
            Password_2.ToolTip = "Пароль минимум 5 символов";
            PasswordBorder_1.BorderBrush = Brushes.Red;
            PasswordBorder_2.BorderBrush = Brushes.Red;
            return false;
        }

        private Boolean Check_Name(string name)
        {
            //Модифицировать проверку на специальные символы. Добавить проверка пробела.

            System.Text.RegularExpressions.Regex regex = null;
            regex = new System.Text.RegularExpressions.Regex("^([а-яА-ЯёЁ])*$");
            if (name.Length >= 2)
            {
                bool ru = true;

                for (int i = 0; i < name.Length; i++)
                {
                    if (name[i] >= 'A' & name[i] <= 'Z') ru = false;
                    
                }

                if (!ru)
                {
                    Name.ToolTip = "Доступна только русская раскладка";
                    NameBorder.BorderBrush = Brushes.Red;
                    return false;
                }
                Name.ToolTip = null;
                NameBorder.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89000000"));
                if (regex.IsMatch(Name.Text))
                {
                    Name.ToolTip = null;
                    NameBorder.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89000000"));
                    return true;
                }
                Name.ToolTip = "Запрещен ввод цифр и символов";
                NameBorder.BorderBrush = Brushes.Red;
                return false;
            }
            Name.ToolTip = "Некорректное имя";
            NameBorder.BorderBrush = Brushes.Red;
            return false;
        }

        private Boolean Check_Surname(string surname)
        {
            //Модифицировать проверку на специальные символы. Добавить проверка пробела.

            System.Text.RegularExpressions.Regex regex = null;
            regex = new System.Text.RegularExpressions.Regex("^([а-яА-ЯёЁ])*$");
            if (surname.Length >= 2)
            {
                bool ru = true;

                for (int i = 0; i < surname.Length; i++)
                {
                    if (surname[i] >= 'A' & surname[i] <= 'Z') ru = false;

                }

                if (!ru)
                {
                    Surname.ToolTip = "Доступна русская раскладка";
                    SurnameBorder.BorderBrush = Brushes.Red;
                    return false;
                }
                Surname.ToolTip = null;
                SurnameBorder.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89000000"));
                if (regex.IsMatch(Name.Text))
                {
                    Name.ToolTip = null;
                    NameBorder.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89000000"));
                    return true;
                }
                Surname.ToolTip = "Запрещен ввод цифр и символов";
                SurnameBorder.BorderBrush = Brushes.Red;
                return false;
            }
            Surname.ToolTip = "Некорректное имя";
            SurnameBorder.BorderBrush = Brushes.Red;
            return false;
        }

        private Boolean Check_Сompany(string company)
        {
            if (company.Length < 5)
            {
                Company.ToolTip = "Это поле введено некорректно!";
                CompanyBorder.BorderBrush = Brushes.Red;
                return false;
            }

            Company.ToolTip = null;
            CompanyBorder.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89000000"));
            return true;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text.Trim();
            string password_1 = Password_1.Password.Trim();
            string password_2 = Password_2.Password.Trim();
            string name = Name.Text.Trim();
            string surname = Surname.Text.Trim();
            string company = Company.Text.Trim();

            bool check_login = Check_Login(login);
            bool check_password = Check_Password(password_1, password_2);
            bool check_name = Check_Name(name);
            bool check_surname = Check_Surname(surname);
            bool check_company = Check_Сompany(company);

            if (check_login & check_password & check_name & check_surname & check_company)
            {
                User user = new User(login, password_1, name, surname, company);
                db.Users.Add(user);
                db.SaveChanges();
                
                TextResult.Text = "Вы успешно зарегистрировались";
            }
            else
            {
                TextResult.Text = "Повторите попытку регистрации";
            }
        }

        private void MouseClick(object sender, MouseButtonEventArgs e)
        {
            AuthWindow authwindow = new AuthWindow();
            authwindow.Show();
            Close();
        }

        private void Dialog_Button(object sender, RoutedEventArgs e)
        {
            if (TextResult.Text == "Вы успешно зарегистрировались")
            {
                AuthWindow authwindow = new AuthWindow();
                authwindow.Show();
                Close();
            }
        }
    }
}
