
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestUsers.models;

namespace TestUsers
{
    /// <summary>
    /// Логика взаимодействия для UserControlTest.xaml
    /// </summary>
    public partial class UserControlTest : UserControl
    { 
        public string Name_Test { get; set; }
        public UserControlTest()
        {
            InitializeComponent();
        }
        List<SmartTruck_Questions> Questions;
        List<SmartTruck_Answers> Answers;
        string CurrentAnswer;
        string Answer;
        int result;
        int i = 0;

        private void ShowQuestion()
        {
            ShowAnswers();
            Question.Content = Questions[i].Question;
        }

        private void ShowAnswers()
        {
            this.Answer_1.Content = Answers[i].Answer_1.Trim();
            this.Answer_2.Content = Answers[i].Answer_2.Trim();
            this.Answer_3.Content = Answers[i].Answer_3.Trim();
            this.Answer_4.Content = Answers[i].Answer_4.Trim();
        }

        private void NextQuestionButtonButton_Click(object sender, RoutedEventArgs e)
        {
            if (Answer == Questions[i].True_answer)
            {
                result += 1;
            }
            i++;
            if(i == Questions.Count)
            {
                ShowResults();
            }
            else
            {
                ShowQuestion();
            }
        }
        private void NextQuestionButtonButton_Click2(object sender, RoutedEventArgs e)
        {
            if(Name_Test == "SmartTruck")
            {
                 Questions = DataWorker.GetAllQuestions();
                 Answers = DataWorker.GetAllAnswers();
            }
            ShowQuestion();
        }


        private void ShowResults()
        {
            string text = string.Format("Правильных ответов: {0} из {1} вопросов", result, Questions.Count);
            MessageBox.Show(text);
        }

        private void Check_Answers(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            NextQuestionButton.IsEnabled = radioButton.IsEnabled;
            CurrentAnswer = radioButton.Content.ToString();
            if (CurrentAnswer != null)
            {
                Answer = CurrentAnswer;
            }
        }
    }
}
