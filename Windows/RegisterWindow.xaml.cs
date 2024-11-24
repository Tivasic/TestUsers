using System;
using System.Threading;
using System.Threading.Tasks;
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

        // Метод очистки поля с первым паролем.
        private void ClearPasswordBorder(PasswordBox passwordBox, Border border)
        {
            passwordBox.ToolTip = null;
            border.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89000000"));
        }

        // Метод проверки вводимого логина.
        private bool CheckLogin(TextBox loginTextBox, Border loginBorder, string login)
        {
            if (login.Length < 5)
            {
                loginTextBox.ToolTip = "Это поле введено некорректно!";
                loginBorder.BorderBrush = Brushes.Red;
                return false;
            }

            bool uniqueLogin = DataWorker.CheckUniqueLogin(login);
            if (uniqueLogin)
            {
                loginTextBox.ToolTip = "Этот логин зарегистрирован";
                loginBorder.BorderBrush = Brushes.Red;
                return false;
            }

            loginTextBox.ToolTip = null;
            loginBorder.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89000000"));
            return true;
        }

        // Метод проверки вводимых паролей.
        public bool CheckPassword(PasswordBox password1Box, PasswordBox password2Box, Border password1Border, Border password2Border, string password1, string password2)
        {
            if (password1.Length < 5)
            {
                ShowPasswordError(password1Box, password2Box, password1Border, password2Border, "Пароль минимум 5 символов");
                return false;
            }

            bool hasEnglishLetters = true;
            bool hasNumber = false;

            foreach (char c in password1)
            {
                if (c >= 'А' && c <= 'Я') hasEnglishLetters = false;
                if (char.IsDigit(c)) hasNumber = true;
            }

            if (!hasEnglishLetters)
            {
                ShowPasswordError(password1Box, password2Box, password1Border, password2Border, "Доступна только английская раскладка");
                return false;
            }

            if (!hasNumber)
            {
                ShowPasswordError(password1Box, password2Box, password1Border, password2Border, "Добавьте минимум одну цифру");
                return false;
            }

            if (password1 != password2)
            {
                ShowPasswordError(password1Box, password2Box, password1Border, password2Border, "Пароли не совпадают");
                return false;
            }

            ClearPasswordBorder(password1Box, password1Border);
            ClearPasswordBorder(password2Box, password2Border);
            return true;
        }

        private void ShowPasswordError(PasswordBox password1Box, PasswordBox password2Box, Border password1Border, Border password2Border, string errorMessage)
        {
            password1Box.ToolTip = errorMessage;
            password2Box.ToolTip = errorMessage;
            password1Border.BorderBrush = Brushes.Red;
            password2Border.BorderBrush = Brushes.Red;
        }

        // Метод проверки вводимого имени.
        public bool CheckName(TextBox nameTextBox, Border nameBorder, string name)
        {
            var regex = new System.Text.RegularExpressions.Regex("^([а-яА-ЯёЁ])*$");

            if (string.IsNullOrWhiteSpace(name))
            {
                nameTextBox.ToolTip = "Введите имя";
                nameBorder.BorderBrush = Brushes.Red;
                return false;
            }

            if (name.Length > 10)
            {
                nameTextBox.ToolTip = "Сократите ваше имя!";
                nameBorder.BorderBrush = Brushes.Red;
                return false;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(name, "[A-Z]"))
            {
                nameTextBox.ToolTip = "Доступна только русская раскладка";
                nameBorder.BorderBrush = Brushes.Red;
                return false;
            }

            if (!regex.IsMatch(name))
            {
                nameTextBox.ToolTip = "Запрещен ввод цифр и символов";
                nameBorder.BorderBrush = Brushes.Red;
                return false;
            }

            nameTextBox.ToolTip = null;
            nameBorder.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89000000"));
            return true;
        }

        // Метод проверки вводимой фамилии.
        public bool CheckSurname(TextBox surnameTextBox, Border surnameBorder, string surname)
        {
            var regex = new System.Text.RegularExpressions.Regex("^([а-яА-ЯёЁ])*$");

            if (string.IsNullOrWhiteSpace(surname))
            {
                surnameTextBox.ToolTip = "Введите фамилию";
                surnameBorder.BorderBrush = Brushes.Red;
                return false;
            }

            if (surname.Length > 10)
            {
                surnameTextBox.ToolTip = "Сократите вашу фамилию!";
                surnameBorder.BorderBrush = Brushes.Red;
                return false;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(surname, "[A-Z]"))
            {
                surnameTextBox.ToolTip = "Доступна только русская раскладка";
                surnameBorder.BorderBrush = Brushes.Red;
                return false;
            }

            if (!regex.IsMatch(surname))
            {
                surnameTextBox.ToolTip = "Запрещен ввод цифр и символов";
                surnameBorder.BorderBrush = Brushes.Red;
                return false;
            }

            surnameTextBox.ToolTip = null;
            surnameBorder.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89000000"));
            return true;
        }

        // Метод проверки вводимой компании.
        public bool CheckGroup(TextBox groupTextBox, Border groupBorder, string group)
        {
            if (group.Length < 5)
            {
                groupTextBox.ToolTip = "Это поле введено некорректно!";
                groupBorder.BorderBrush = Brushes.Red;
                return false;
            }

            groupTextBox.ToolTip = null;
            groupBorder.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89000000"));
            return true;
        }

        // Метод регистрации пользователя.
        private void RegisterButtonClick(object sender, RoutedEventArgs e)
        {
            string login = Login.Text.Trim();
            string password1 = Password_1.Password.Trim();
            string password2 = Password_2.Password.Trim();
            string name = Name.Text.Trim();
            string surname = Surname.Text.Trim();
            string group = Group.Text.Trim();

            bool isLoginValid = CheckLogin(Login, LoginBorder, login);
            bool isPasswordValid = CheckPassword(Password_1, Password_2, PasswordBorder_1, PasswordBorder_2, password1, password2);
            bool isNameValid = CheckName(Name, NameBorder, name);
            bool isSurnameValid = CheckSurname(Surname, SurnameBorder, surname);
            bool isCompanyValid = CheckGroup(Group, GroupBorder, group);

            if (isLoginValid && isPasswordValid && isNameValid && isSurnameValid && isCompanyValid)
            {
                DataWorker.CreateUser(login, password1, name, surname, group);
                Snackbar.MessageQueue.Enqueue("Вы успешно зарегистрировались");
                OpenAuthWindow();
            }
            else
            {
                Snackbar.MessageQueue.Enqueue("Повторите попытку регистрации");
            }
        }

        // Метод закрытия текущего окна и переход на окно авторизации.
        private void MouseClick(object sender, MouseButtonEventArgs e)
        {
            OpenAuthWindow();
        }


        private void OpenAuthWindow()
        {
            var authWindow = new AuthWindow();
            authWindow.Show();
            Close();
        }

        // Метод отвечающий за отклик клавиши 'Enter'.
        private void TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RegisterButtonClick(sender, e);
            }
        }

        // Метод отвечающий за отклик клавиши 'Esc'.
        private void CloseKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                OpenAuthWindow();
            }
        }
    }
}

