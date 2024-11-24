using System.Windows;
using System.Windows.Controls;
using TestUsers.models;
using System;

namespace TestUsers
{
    /// <summary>
    /// Логика взаимодействия для UserControlPersonalAccount.xaml
    /// </summary>
    public partial class UserControlPersonalAccount : UserControl
    {
        public Users DataUser { get; set; }

        public UserControlPersonalAccount()
        {
            InitializeComponent();
        }

        // Метод заполнения полей данными пользователя.
        public void FillingFields()
        {
            Name.Text = DataUser.Name.Trim();
            Surname.Text = DataUser.Surname.Trim();
            Group.Text = DataUser.GroupUser.Trim();
        }

        //Метод отвечающий за кнопку смены данных.
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            string NewName = Name.Text.Trim();
            string NewSurname = Surname.Text.Trim();
            string NewGroup = Group.Text.Trim();
            bool check_name;
            bool check_surname;
            bool check_group;

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

            if (DataUser.GroupUser != NewGroup)
            {
                check_group = registerWindow.CheckGroup(this.Group, this.GroupBorder, NewGroup);
            }
            else
            {
                check_group = true;
            }

            if (check_name & check_surname & check_group)
            {
                DataUser = DataWorker.EditUser(DataUser, NewName, NewSurname, NewGroup);
                MainWindow mainWindow = new MainWindow { DataUser = DataUser };

                mainWindow.ChangeUserName();
                Snackbar.MessageQueue.Enqueue("Вы успешно сменили личные данные");
            }
            else
            {
                Snackbar.MessageQueue.Enqueue("Проверьте корректность данных");
            }
        }

        // Метод перехода на страницу смены пароля.
        private void OpenMainWindowButtonClick(object sender, RoutedEventArgs e)
        {
            var changePasswordControl = new UserControlChangePassword
            {
                DataUser = DataUser
            };
            GridMain.Children.Clear(); 
            GridMain.Children.Add(changePasswordControl);
        }
    }
}
