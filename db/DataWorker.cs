using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace TestUsers.models
{
    public static class DataWorker
    {
        // Метод создания нового пользователя в БД.
        public static void CreateUser(string login, string password, string name, string surname, string group)
        {
            using (var db = new ApplicationContext())
            {
                var newUser = new Users
                {
                    Login = login,
                    Password = password,
                    Name = name,
                    Surname = surname,
                    GroupUser = group
                };
                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }

        // Метод проверки уникальности логина.
        public static bool CheckUniqueLogin(string login)
        {
            using (var db = new ApplicationContext())
            {
                return db.Users.Any(user => user.Login == login);
            }
        }

        // Метод авторизации пользователя через БД.
        public static Users AuthUser(string login, string password)
        {
            using (var db = new ApplicationContext())
            {
                return db.Users.FirstOrDefault(user => user.Login == login && user.Password == password);
            }
        }

        // Метод редактирования личных данных пользователя в БД.
        public static Users EditUser(Users user, string newName, string newSurname, string newGroup)
        {
            using (var db = new ApplicationContext())
            {
                var existingUser = db.Users.Find(user.Id);
                if (existingUser != null)
                {
                    existingUser.Name = newName;
                    existingUser.Surname = newSurname;
                    existingUser.GroupUser = newGroup;
                    db.SaveChanges();
                }
                return existingUser;
            }
        }

        // Метод смены пароля пользователя в БД.
        public static Users ChangePassword(Users user, string newPassword)
        {
            using (var db = new ApplicationContext())
            {
                var existingUser = db.Users.Find(user.Id);
                if (existingUser != null)
                {
                    existingUser.Password = newPassword;
                    db.SaveChanges();
                }
                return existingUser;
            }
        }

        // Метод получения всех вопросов из БД в зависимости от выбранного теста.
        public static List<Question> GetAllQuestions(string testName)
        {
            using (var db = new ApplicationContext())
            {
                var test = db.Tests
                    .Include(t => t.Questions)
                    .ThenInclude(q => q.Answers)
                    .Include(t => t.Questions)
                    .ThenInclude(q => q.TrueAnswer)
                    .FirstOrDefault(t => t.TestName == testName);
                return test?.Questions.ToList();
            }
        }

        // Метод получения всех ответов из БД в зависимости от выбранного теста.
        public static List<Answer> GetAllAnswers(string testName)
        {
            using (var db = new ApplicationContext())
            {
                var test = db.Tests
                    .Include(t => t.Questions)
                    .ThenInclude(q => q.Answers)
                    .FirstOrDefault(t => t.TestName == testName);
                return test?.Questions.SelectMany(q => q.Answers).ToList();
            }
        }

        // Метод получения правильного ответа для вопроса.
        public static TrueAnswer GetTrueAnswer(int questionId)
        {
            using (var db = new ApplicationContext())
            {
                return db.TrueAnswers
                    .Include(ta => ta.Answer)
                    .FirstOrDefault(ta => ta.QuestionId == questionId);
            }
        }
        // Метод записи результатов теста в БД.
        public static void RecordResult(int userId, string testName, int percentageCorrectAnswers, TimeSpan testDuration)
        {
            using (var db = new ApplicationContext())
            {
                var testResult = new TestResult
                {
                    User = db.Users.FirstOrDefault(u => u.Id == userId),
                    Test = db.Tests.FirstOrDefault(t => t.TestName == testName),
                    PercentageCorrectAnswers = percentageCorrectAnswers,
                    TestDate = DateTime.Now,
                    TestDuration = testDuration
                };
                db.TestResults.Add(testResult);
                db.SaveChanges();
            }
        }

        // Метод загрузки результатов теста из БД.
        public static List<TestResult> LoadResults()
        {
            using (var db = new ApplicationContext())
            {
                return db.TestResults
                    .Include(tr => tr.Test)
                    .Include(tr => tr.User)
                    .ToList();
            }
        }
    }
}

