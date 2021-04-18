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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class UserControlMainPage: UserControl
    {
        private static UserControlMainPage _instance;
        public static UserControlMainPage Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControlMainPage();
                return _instance;
            }
        }
        public UserControlMainPage()
        {
            InitializeComponent();
        }
    }
}
