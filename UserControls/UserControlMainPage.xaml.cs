using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TestUsers
{
    /// <summary>
    /// Логика взаимодействия для UserControlMainPage.xaml
    /// </summary>
    public partial class UserControlMainPage : UserControl
    {
        public UserControlMainPage()
        {
            InitializeComponent();
        }

        // Метод перехода на страницу сайта.
        private void NavigateToUrl(string url)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        // Обработчик клика на "О МТУСИ".
        private void AboutUniversityBorderMouseLeftClick(object sender, RoutedEventArgs e)
        {
            NavigateToUrl("https://mtuci.ru/media-room/");
        }

        // Обработчик клика на "Обратная связь".
        private void YourFeedbackBorderMouseLeftClick(object sender, RoutedEventArgs e)
        {
            NavigateToUrl("http://www.kg.ru/contacts/");
        }

        // Обработчик клика на "О тестировании".
        private void AboutTestBorderMouseLeftClick(object sender, MouseButtonEventArgs e)
        {
            var manualControl = new UserControlManual();
            GridMain.Children.Clear(); // Очищаем, если нужно заменить содержимое.
            GridMain.Children.Add(manualControl);
        }
    }
}

