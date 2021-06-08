
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TestUsers.models;

namespace TestUsers
{
    /// <summary>
    /// Логика взаимодействия для UserControlTest.xaml
    /// </summary>
    public partial class UserControlTest : UserControl
    { 
        public string NameTest { get; set; }
        public UserControlTest()
        {
            InitializeComponent();
            StartTesting();
        }
        DispatcherTimer Timer;
        TimeSpan AllTime, CurrentTime;

        List<BaseModelQuestions> Questions;
        List<BaseModelAnswers> Answers;

        string CurrentAnswer;
        string Answer;
        int StepValueProgressBar = 0;
        int Result;
        int i = 0;

        //Метод запуска таймера
        private void Dispatcher_Timer()
        {
            AllTime = CurrentTime = GetRequiredTime();
            Timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                TimeLabel.Content = CurrentTime.ToString("mm\\:ss");

                if (CurrentTime == TimeSpan.Zero)
                {
                    Timer.Stop();
                }
                CurrentTime = CurrentTime.Add(TimeSpan.FromSeconds(-1));
            }, 
            Application.Current.Dispatcher);
            Timer.Start();
        }

        // Метод получения необходимого времени для прохождения теста.
        // На один вопрос выделяется по 2 минуты.
        private TimeSpan GetRequiredTime()
        {
            AllTime = TimeSpan.FromMinutes(2 * Questions.Count);
            return AllTime;
        }

        // Метод после которого форма станет доступа
        private void StartTesting()
        {
            this.TextResult.Text = "После нажатия кнопки начала теста запуcтится таймер. Удачи!";
            this.DialogResult.IsOpen = true;
        }

        //Метод отображения вопроса
        private void ShowQuestion()
        {
            int count = Questions.Count;
            StepValueProgressBar = 100 / count;
            QuestionText.Text = Questions[i].Question.Trim();
            ShowAnswers();
        }

        // Метод отображения ответов 
        private void ShowAnswers()
        {
            this.Answer_1.Content = Answers[i].Answer_1.Trim();
            this.Answer_2.Content = Answers[i].Answer_2.Trim();
            this.Answer_3.Content = Answers[i].Answer_3.Trim();
            this.Answer_4.Content = Answers[i].Answer_4.Trim();
        }

        //Кнопка отображения следующего вопроса
        private void NextQuestionButtonButton_Click(object sender, RoutedEventArgs e)
        {
            circularProgressBar.Value += StepValueProgressBar;

            if (Answer == Questions[i].True_answer.Trim())
            {
                Result += StepValueProgressBar;
            }
            i++;
            if(i == Questions.Count)
            {
                Timer.Stop();
                UserControlResult usc = new UserControlResult
                {
                    TestResult = Result,
                    TimeResult = AllTime - CurrentTime
                };
                usc.RecordResult();
                GridMain.Children.Add(usc);
            }
            else
            {
                ShowQuestion();
            }
        }

        // Кнопка для запуска теста
        public void StartTestingButton_Click(object sender, RoutedEventArgs e)
        {
            TestLabel.Content = NameTest;
            GridMain.Visibility = Visibility.Visible;
            Questions = DataWorker.GetAllQuestions(NameTest);
            Answers = DataWorker.GetAllAnswers(NameTest);
            Dispatcher_Timer();
            ShowQuestion();
        }

        // Метод выбора одного из вариантов ответа
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
