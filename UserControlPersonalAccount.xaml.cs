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
    /// Логика взаимодействия для UserControlPersonalAccount.xaml
    /// </summary>
    public partial class UserControlPersonalAccount : UserControl
    {
        db db;
        public User DataUser { get; set; }
        public UserControlPersonalAccount()
        {
            InitializeComponent();
            db = new db();
        }

        public void FillingFields()
        {
            Name.Text = DataUser.Name;
            Surname.Text = DataUser.Surname;
            Company.Text = DataUser.Company;
        }


        public void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = Name.Text.Trim();
            string surname = Surname.Text.Trim();
            string company = Company.Text.Trim();
            bool check_name;
            bool check_surname;
            bool check_company;

            RegisterWindow registerWindow = new RegisterWindow();

            if (DataUser.Name != name)
            {
                check_name = registerWindow.Check_Name(this.Name, this.NameBorder, name);
            }
            else
            {
                check_name = true;
            }

            if (DataUser.Surname != surname)
            {
                check_surname = registerWindow.Check_Surname(this.Surname, this.SurnameBorder, surname);
            }
            else
            {
                check_surname = true;
            }

            if (DataUser.Company != company)
            {
                check_company = registerWindow.Check_Сompany(this.Company, this.CompanyBorder, company);
            }
            else
            {
                check_company = true;
            }


            if (check_name & check_surname & check_company)
            {

                db.Users.Attach(DataUser);
                DataUser.Name = name;
                DataUser.Surname = surname;
                DataUser.Company = company;
                db.SaveChanges();
                MainWindow mainWindow = new MainWindow
                {
                    DataUser = DataUser
                };
                //mainWindow.UserName.Text = name + " " + surname;
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
