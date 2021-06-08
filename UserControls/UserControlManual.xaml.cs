using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace TestUsers
{
    /// <summary>
    /// Логика взаимодействия для UserControlManual.xaml
    /// </summary>
    public partial class UserControlManual : UserControl
    {
        public UserControlManual()
        {
            InitializeComponent();
            ReadManual();
        }

        //Метод чтения инструкции из файла.
        private void ReadManual()
        {
            try
            {
                using (StreamReader sr = new StreamReader("Manual.txt"))
                {
                    TextManual.Text = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
