using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestUsers.models;

namespace TestUsers.models
{
    public static class DataWorker
    {
        //Метод создания нового пользователя в БД.
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

        //Метод проверки уникальности логина.
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

        //Метод авторизации пользователя через БД.
        public static User AuthUser(string login, string password)
        {
            User DataUser = null;
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем сущесвует ли позиция
                DataUser = db.Users.Where(b => b.Login == login && b.Password == password).FirstOrDefault();
                return DataUser;
            }
        }

        //Метод редактирования личный данных пользователя в БД.
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

        //Метод смены пароля пользователя в БД.
        public static User ChangePassword(User DataUser, string newPassword)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Attach(DataUser);
                DataUser.Password = newPassword;
                db.SaveChanges();
            }
            return DataUser;
        }

        //Метод получения всех вопросов из БД в зависимости от выбранного теста.
        public static List<BaseModelQuestions> GetAllQuestions(string NameTest)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (NameTest == "Тест №1")
                {
                    var all_questions = db.FirstTest_Questions.ToList();
                    var result = all_questions.Cast<BaseModelQuestions>().ToList();
                    return result;
                }
                else
                {
                    var all_questions = db.SecondTest_Questions.ToList();
                    var result = all_questions.Cast<BaseModelQuestions>().ToList();
                    return result;
                }
            }
        }

        //Метод получения всех ответов из БД в зависимости от выбранного теста.
        public static List<BaseModelAnswers> GetAllAnswers(string NameTest)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (NameTest == "Тест №1")
                {
                    var all_answers = db.FirstTest_Answers.ToList();
                    var result = all_answers.Cast<BaseModelAnswers>().ToList();
                    return result;
                }
                else
                {
                    var all_answers = db.SecondTest_Answers.ToList();
                    var result = all_answers.Cast<BaseModelAnswers>().ToList();
                    return result;
                }
            }
        }
    }
}
