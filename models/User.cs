using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUsers
{
    class User
    {
        public int id { get; set; }
        private string login, password, name, surname, company;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        public User() { }

        public User(string login, string password, string name, string surname, string company)
        {
            this.login = login;
            this.password = password;
            this.name = name;
            this.surname = surname;
            this.company = company;
        }
    }
}
