using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestUsers
{
    public class User: INotifyPropertyChanged
    {
        public int id { get; set; }
        private string login, password, name, surname, company;

        public string Login
        {
            get { return login; }
			set
            {
                if (value == login) return;
                login = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (value == password) return;
                password = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value == name) return;
                name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                if (value == surname) return;
                surname = value;
                OnPropertyChanged();
            }
        }

        public string Company
        {
            get { return company; }
            set
            {
                if (value == company) return;
                company = value;
                OnPropertyChanged();
            }
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
		
		#region InotifyPropertyChange

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
