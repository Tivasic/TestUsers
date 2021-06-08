using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для UserControlManual.xaml
    /// </summary>
    public partial class UserControlManual : UserControl
    {
        public UserControlManual()
        {
            InitializeComponent();
            ReadManual();
        }

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
                Console.WriteLine(e.Message);
            }
        }

    }
}
