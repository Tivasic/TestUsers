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
    /// Логика взаимодействия для UserControlTest.xaml
    /// </summary>
    public partial class UserControlTest : UserControl
    {
        db db;
        public UserControlTest()
        {
            InitializeComponent();
            db = new db();
            Question();
        }

        public void Question()
        {
            List<User> users = db.Users.ToList();

            Label1.Content = users[0];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
