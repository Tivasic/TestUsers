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
        private const string ManualFilePath = "Manual.txt"; // Пусть к файлу инструкции.

        public UserControlManual()
        {
            InitializeComponent();
            ReadManual();
        }

        // Метод чтения инструкции из файла.
        private void ReadManual()
        {
            if (!File.Exists(ManualFilePath))
            {
                MessageBox.Show("Файл инструкции не найден.");
                return;
            }

            try
            {
                TextManual.Text = File.ReadAllText(ManualFilePath);
            }
            catch (IOException ioEx)
            {
                MessageBox.Show($"Ошибка чтения файла: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
