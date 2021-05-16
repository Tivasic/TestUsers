
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
        public string Name_Test { get; set; }
        public UserControlTest()
        {
            InitializeComponent();
            StartTesting();
        }
        DispatcherTimer Timer;
        TimeSpan CurrentTime;

        List<SmartTruck_Questions> Questions;
        List<SmartTruck_Answers> Answers;

        string CurrentAnswer;
        string Answer;
        int StepValueProgressBar = 0;
        int result;
        int i = 0;

        // EventWaitHandle wh = new EventWaitHandle(true, EventResetMode.AutoReset);
        // private void UserControl_Loaded(object sender, RoutedEventArgs e)
        // {
        //     TimeSpan CurrentTime;
        //     StartTesting();
        //     wh.WaitOne();
        //     CurrentTime = GetRequiredTime(out CurrentTime);
        //     Dispatcher_Timer(CurrentTime);
        // }

        //Метод запуска таймера
        private void Dispatcher_Timer()
        {
            CurrentTime = GetRequiredTime();
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
            CurrentTime = TimeSpan.FromMinutes(2 * Questions.Count);
            return CurrentTime;
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

            if (Answer == Questions[i].True_answer)
            {
                result += 1;
            }
            i++;
            if(i == Questions.Count)
            {
                Timer.Stop();
                UserControl usc;
                usc = new UserControlResult();
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
            GridMain.Visibility = Visibility.Visible;
            if(Name_Test == "SmartTruck")
            {
                 Questions = DataWorker.GetAllQuestions();
                 Answers = DataWorker.GetAllAnswers();
            }
            // wh.Set();
            Dispatcher_Timer();
            ShowQuestion();
        }

        //Метод отображения результатов теста
        private void ShowResults()
        {
            string text = string.Format("Правильных ответов: {0} из {1} вопросов", result, Questions.Count);
            MessageBox.Show(text);
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
