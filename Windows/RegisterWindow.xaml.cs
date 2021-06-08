using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TestUsers.models;

namespace TestUsers
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        //Метод очистки поля с первым паролем.
        public void ClearPasswordBorder1()
        {
            Password_1.ToolTip = null;
            PasswordBorder_1.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89000000"));
        }

        //Метод очистки поля со вторым паролем.
        public void ClearPasswordBorder2()
        {
            Password_2.ToolTip = null;
            PasswordBorder_2.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89000000"));
        }

        //Метод проверка вводимого логина.
        public Boolean CheckLogin(TextBox Login, Border LoginBorder, string login)
        { 
            if (login.Length < 5)
            {
                Login.ToolTip = "Это поле введено некорректно!";
                LoginBorder.BorderBrush = Brushes.Red;
                return false;
            }
            bool UniqueLogin = DataWorker.CheckUniqueLogin(login);
            if (UniqueLogin)
            {
                Login.ToolTip = "Этот логин зарегистрирован";
                LoginBorder.BorderBrush = Brushes.Red;
                return false;
            }
            Login.ToolTip = null;
            LoginBorder.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89000000"));
            return true;
        }

        //Метод проверки вводимых паролей.
        public Boolean CheckPassword(PasswordBox Password_1, PasswordBox Password_2, Border PasswordBorder_1, Border PasswordBorder_2, string password_1, string password_2)
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
                ClearPasswordBorder1();
                if (!number)
                {
                    Password_1.ToolTip = "Добавьте минимум одну цифру";
                    PasswordBorder_1.BorderBrush = Brushes.Red;
                    return false;
                }
                ClearPasswordBorder1();
                if (password_1 != password_2)
                {
                    PasswordBorder_1.BorderBrush = Brushes.Red;
                    PasswordBorder_2.BorderBrush = Brushes.Red;
                    Password_1.ToolTip = "Пароли не совпадают";
                    Password_2.ToolTip = "Пароли не совпадают";
                    return false;
                }
                ClearPasswordBorder1();
                ClearPasswordBorder2();
                return true;
            }
            Password_1.ToolTip = "Пароль минимум 5 символов";
            Password_2.ToolTip = "Пароль минимум 5 символов";
            PasswordBorder_1.BorderBrush = Brushes.Red;
            PasswordBorder_2.BorderBrush = Brushes.Red;
            return false;
        }

        //Метод проверки вводимого имени.
        public Boolean CheckName(TextBox Name, Border NameBorder, string name)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^([а-яА-ЯёЁ])*$");
            if (name.Length == 0)
            {
                Name.ToolTip = "Введите имя";
                NameBorder.BorderBrush = Brushes.Red;
                return false;
            }
            if (name.Length <= 10)
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
            Name.ToolTip = "Сократите ваше имя!";
            NameBorder.BorderBrush = Brushes.Red;
            return false;
            
        }

        //Метод проверки вводимой фамилии.
        public Boolean CheckSurname(TextBox Surname, Border SurnameBorder, string surname)
        {
            System.Text.RegularExpressions.Regex regex;
            regex = new System.Text.RegularExpressions.Regex("^([а-яА-ЯёЁ])*$");
            if (surname.Length == 0)
            {
                Surname.ToolTip = "Введите фамилию";
                SurnameBorder.BorderBrush = Brushes.Red;
                return false;
            }
            if (surname.Length <= 10)
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
            Surname.ToolTip = "Сократите вашу фамилию!";
            SurnameBorder.BorderBrush = Brushes.Red;
            return false;
        }

        //Метод проверки вводимой компании.
        public Boolean CheckСompany(TextBox Company, Border CompanyBorder, string company)
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

        //Метод регистрации пользователя.
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text.Trim();
            string password_1 = Password_1.Password.Trim();
            string password_2 = Password_2.Password.Trim();
            string name = Name.Text.Trim();
            string surname = Surname.Text.Trim();
            string company = Company.Text.Trim();

            bool check_login = CheckLogin(this.Login, this.LoginBorder, login);
            bool check_password = CheckPassword(this.Password_1, this.Password_2, this.PasswordBorder_1, this.PasswordBorder_2, password_1, password_2);
            bool check_name = CheckName(this.Name, this.NameBorder, name);
            bool check_surname = CheckSurname(this.Surname, this.SurnameBorder, surname);
            bool check_company = CheckСompany(this.Company, this.CompanyBorder, company);
            if (check_login & check_password & check_name & check_surname & check_company)
            {
                DataWorker.CreatePosition(login, password_1, name, surname, company);

                this.TextResult.Text = "Вы успешно зарегистрировались";
            }
            else
            {
                this.TextResult.Text = "Повторите попытку регистрации";
            }
        }

        //Метод закрытия текущего окна и переход на окно авторизации.
        private void Mouse_Click(object sender, MouseButtonEventArgs e)
        {
            AuthWindow authwindow = new AuthWindow();
            authwindow.Show();
            this.Close();
        }

        //Метод нажатия кнопки на диалоговом окне.
        private void Dialog_Button(object sender, RoutedEventArgs e)
        {
            if (TextResult.Text == "Вы успешно зарегистрировались")
            {
                AuthWindow authwindow = new AuthWindow();
                authwindow.Show();
                this.Close();
            }
        }

        //Метод отвечающий за отклик клавиши 'Enter'.
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RegisterButton_Click(sender, e);
                DialogResult.IsOpen = true;
            }
        }

        //Метод отвечающий за отклик клавиши 'Esc'.
        private void Close_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                AuthWindow authwindow = new AuthWindow();
                authwindow.Show();
                this.Close();
            }
        }
    }
}
