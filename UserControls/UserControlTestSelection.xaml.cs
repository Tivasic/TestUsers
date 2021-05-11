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
using System.Windows.Shapes;

namespace TestUsers
{
    /// <summary>
    /// Логика взаимодействия для UserControlHome.xaml
    /// </summary>
    public partial class UserControlTestSelection : UserControl
    {
        public UserControlTestSelection()
        {
            InitializeComponent();
        }

        private void Border_SmartTruck_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UserControlTest usc = new UserControlTest
            {
                Name_Test = "SmartTruck"
            };
            GridMain.Children.Add(usc);
        }
        private void Border_SmartTruck_plus_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("OKEEEEEEY");
        }

        private void Border_Textile_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("OKEEEEEEY");
        }

        private void Border_C_plus_plus_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("OKEEEEEEY");
        }

        private void Border_LGIP_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("OKEEEEEEY");
        }

        private void Border_C_grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("OKEEEEEEY");
        }
    }
}