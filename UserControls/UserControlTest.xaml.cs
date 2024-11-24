using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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
        public Users DataUser { get; set; }

        public UserControlTest()
        {
            InitializeComponent();
            StartTesting();
        }

        private DispatcherTimer Timer;
        private TimeSpan AllTime, CurrentTime;

        private List<Question> Questions;
        private List<Answer> Answers;

        private string Answer, CurrentAnswer;
        private int StepValueProgressBar = 0, Result = 0, currentQuestionIndex = 0;

        // Метод логики работы таймера.
        private void DispatcherTimer()
        {
            AllTime = CurrentTime = GetRequiredTime();
            Timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, (sender, e) =>
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
        private TimeSpan GetRequiredTime()
        {
            return TimeSpan.FromMinutes(2 * Questions.Count);
        }

        // Метод предупреждения перед началом теста.
        private void StartTesting()
        {
            TextResult.Text = "После нажатия кнопки начала теста запуcтится таймер. Удачи!";
            DialogResult.IsOpen = true;
        }

        // Метод отображения текущего вопроса и обновления прогресс-бара.
        private void ShowQuestion()
        {
            int totalQuestions = Questions.Count;
            StepValueProgressBar = 100 / totalQuestions;
            QuestionText.Text = Questions[currentQuestionIndex].QuestionText.Trim();
            ShowAnswers();
        }

        // Метод отображения вариантов ответа для текущего вопроса.
        private void ShowAnswers()
        {
            var currentAnswers = Answers.FindAll(a => a.QuestionId == Questions[currentQuestionIndex].Id);
            Answer_1.Content = currentAnswers[0].AnswerText.Trim();
            Answer_2.Content = currentAnswers[1].AnswerText.Trim();
            Answer_3.Content = currentAnswers[2].AnswerText.Trim();
            Answer_4.Content = currentAnswers[3].AnswerText.Trim();
        }

        // Обработчик кнопки для отображения следующего вопроса.
        private void NextQuestionButtonButton_Click(object sender, RoutedEventArgs e)
        {
            circularProgressBar.Value += StepValueProgressBar;

            var trueAnswer = DataWorker.GetTrueAnswer(Questions[currentQuestionIndex].Id);
            if (Answer == trueAnswer.Answer.AnswerText.Trim())
            {
                Result += StepValueProgressBar;
            }

            currentQuestionIndex++;

            if (currentQuestionIndex == Questions.Count)
            {
                Timer.Stop();
                var testDuration = AllTime - CurrentTime;
                DataWorker.RecordResult(DataUser.Id, NameTest, Result, testDuration);

                var resultControl = new UserControlResult
                {
                    TestResult = Result,
                    TimeResult = testDuration
                };
                resultControl.ShowResult();
                GridMain.Children.Add(resultControl);
            }
            else
            {
                ResetQuestionState();
                ShowQuestion();
            }
        }

        // Обработчик кнопки для запуска теста.
        public void StartTestingButton_Click(object sender, RoutedEventArgs e)
        {
            TestLabel.Content = NameTest;
            GridMain.Visibility = Visibility.Visible;
            Questions = DataWorker.GetAllQuestions(NameTest);
            Answers = DataWorker.GetAllAnswers(NameTest);
            DispatcherTimer();
            ShowQuestion();
        }

        // Метод для выбора ответа.
        private void CheckAnswers(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            NextQuestionButton.IsEnabled = radioButton.IsEnabled;
            CurrentAnswer = radioButton.Content.ToString();
            if (!string.IsNullOrEmpty(CurrentAnswer))
            {
                Answer = CurrentAnswer;
            }
        }
        // Метод сброса состояния выбора ответа.
        private void ResetQuestionState()
        {
            // Отключаем кнопку "Дальше"
            NextQuestionButton.IsEnabled = false;

            // Сбрасываем состояние радиокнопок
            foreach (var child in stackPanel.Children)
            {
                if (child is RadioButton radioButton)
                {
                    radioButton.IsChecked = false;
                }
            }

            // Сбрасываем текущий выбранный ответ
            CurrentAnswer = string.Empty;
            Answer = string.Empty;
        }
    }
}

