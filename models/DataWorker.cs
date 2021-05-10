using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestUsers.models;

namespace TestUsers.models
{
    public static class DataWorker
    {

        public static void CreatePosition(string login, string password, string name, string surname, string company)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User newPosition = new User
                {
                    Login = login,
                    Password = password,
                    Name = name,
                    Surname = surname,
                    Company = company
                };
                db.Users.Add(newPosition);
                db.SaveChanges();
                return;
            }
        }
        public static Boolean CheckUniqueLogin(string login)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Users.Any(el => el.Login == login);
                if (checkIsExist)
                {
                    return true;
                }
                return false;
            }
        }

        public static User Auth_User(string login, string password)
        {
            User DataUser = null;
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем сущесвует ли позиция
                DataUser = db.Users.Where(b => b.Login == login && b.Password == password).FirstOrDefault();
                return DataUser;
            }
        }
        public static User EditUser(User DataUser, string NewName, string NewSurname, string NewCompany)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Attach(DataUser);
                DataUser.Name = NewName;
                DataUser.Surname = NewSurname;
                DataUser.Company = NewCompany;
                db.SaveChanges();
            }
            return DataUser;
        }
        public static User Change_Password(User DataUser, string newPassword)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Attach(DataUser);
                DataUser.Password = newPassword;
                db.SaveChanges();
            }
            return DataUser;
        }

    }
}
