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

        public void FillingFields()
        {
            Name.Text = DataUser.Name.Trim();
            Surname.Text = DataUser.Surname.Trim();
            Company.Text = DataUser.Company.Trim();
        }

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
                check_name = registerWindow.Check_Name(this.Name, this.NameBorder, NewName);
            }
            else
            {
                check_name = true;
            }

            if (DataUser.Surname != NewSurname)
            {
                check_surname = registerWindow.Check_Surname(this.Surname, this.SurnameBorder, NewSurname);
            }
            else
            {
                check_surname = true;
            }

            if (DataUser.Company != NewCompany)
            {
                check_company = registerWindow.Check_Сompany(this.Company, this.CompanyBorder, NewCompany);
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
