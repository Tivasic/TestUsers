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

        private void BorderTestFirst_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UserControlTest usc = new UserControlTest
            {
                NameTest = "Тест №1"
            };
            GridMain.Children.Add(usc);
        }
        private void BorderTestSecond_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UserControlTest usc = new UserControlTest
            {
                NameTest = "Тест №2"
            };
            GridMain.Children.Add(usc); 
        }

        private void BorderTestThird_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Этот тест пока недоступен");
        }

        private void BorderTestFourth_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Этот тест пока недоступен");
        }

        private void BorderTestFifth_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Этот тест пока недоступен");
        }

        private void BorderTestSixth_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Этот тест пока недоступен");
        }
    }
}