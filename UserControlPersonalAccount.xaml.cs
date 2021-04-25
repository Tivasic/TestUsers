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
        public User DataUser { get; set; }
        public UserControlPersonalAccount()
        {
            InitializeComponent();

        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
