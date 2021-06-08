using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TestUsers
{
    /// <summary>
    /// Логика взаимодействия для UserControlTestSelection.xaml
    /// </summary>
    public partial class UserControlTestSelection : UserControl
    {
        public UserControlTestSelection()
        {
            InitializeComponent();
        }

        //Метод перехода в первый тест.
        private void BorderTestFirst_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UserControlTest usc = new UserControlTest
            {
                NameTest = "Тест №1"
            };
            GridMain.Children.Add(usc);
        }

        //Метод перехода во второй тест.
        private void BorderTestSecond_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UserControlTest usc = new UserControlTest
            {
                NameTest = "Тест №2"
            };
            GridMain.Children.Add(usc); 
        }

        //Метод перехода в третий тест.
        private void BorderTestThird_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Этот тест пока недоступен");
        }

        //Метод перехода в четвертый тест.
        private void BorderTestFourth_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Этот тест пока недоступен");
        }

        //Метод перехода в пятый тест.
        private void BorderTestFifth_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Этот тест пока недоступен");
        }

        //Метод перехода в шестой тест.
        private void BorderTestSixth_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Этот тест пока недоступен");
        }
    }
}