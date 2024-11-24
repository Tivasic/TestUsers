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
        public Users DataUser { get; set; }
        public UserControlTestSelection()
        {
            InitializeComponent();
        }

        // Метод перехода к тесту по номеру.
        private void NavigateToTest(string testName)
        {
            var testControl = new UserControlTest
            {
                NameTest = testName,
                DataUser = DataUser
            };
            GridMain.Children.Clear(); // Очистка содержимого перед добавлением нового контрола.
            GridMain.Children.Add(testControl);
        }

        // Метод перехода к тесту.
        private void BorderTestMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var border = sender as Border;
            if (border != null)
            {
                var testName = border.Tag as string;
                if (!string.IsNullOrEmpty(testName))
                {
                    NavigateToTest(testName);
                }
                else
                {
                    ShowTestNotAvailableMessage();
                }
            }
        }
        // Метод отображения сообщения о недоступности теста.
        private void ShowTestNotAvailableMessage()
        {
            MessageBox.Show("Этот тест пока недоступен");
        }
    }
}
