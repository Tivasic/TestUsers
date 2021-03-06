using System.Windows;
using System.Windows.Controls;
using TestUsers.models;

namespace TestUsers
{
    /// <summary>
    /// Логика взаимодействия для UserControlPersonalAccount.xaml
    /// </summary>
    public partial class UserControlPersonalAccount : UserControl
    {
        public User DataUser { get; set; }
        public UserControlPersonalAccount()
        {
            InitializeComponent();
        }

        //Метод заполнения полей данными пользователя.
        public void FillingFields()
        {
            Name.Text = DataUser.Name.Trim();
            Surname.Text = DataUser.Surname.Trim();
            Company.Text = DataUser.Company.Trim();
        }

        //Метод отвечающий за кнопку смены данных.
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            string NewName = Name.Text.Trim();
            string NewSurname = Surname.Text.Trim();
            string NewCompany = Company.Text.Trim();
            bool check_name;
            bool check_surname;
            bool check_company;

            RegisterWindow registerWindow = new RegisterWindow();

            if (DataUser.Name != NewName)
            {
                check_name = registerWindow.CheckName(this.Name, this.NameBorder, NewName);
            }
            else
            {
                check_name = true;
            }

            if (DataUser.Surname != NewSurname)
            {
                check_surname = registerWindow.CheckSurname(this.Surname, this.SurnameBorder, NewSurname);
            }
            else
            {
                check_surname = true;
            }

            if (DataUser.Company != NewCompany)
            {
                check_company = registerWindow.CheckСompany(this.Company, this.CompanyBorder, NewCompany);
            }
            else
            {
                check_company = true;
            }

            if (check_name & check_surname & check_company)
            {
                DataUser = DataWorker.EditUser(DataUser, NewName, NewSurname, NewCompany);
                MainWindow mainWindow = new MainWindow
                {
                   DataUser = DataUser
                };
                TextResult.Text = "Вы успешно сменили личные данные";
            }
            else
            {
                TextResult.Text = "Повторите попытку";
            }
        }

        //Метод перехода на страницу смены пароля.
        private void Hyperlink_Change_Password(object sender, RoutedEventArgs e)
        {
            UserControlChangePassword usc = new UserControlChangePassword
            {
                DataUser = DataUser
            };
            GridMain.Children.Add(usc);
        }
    }
}
