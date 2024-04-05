using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace TestikC
{
    /// <summary>
    /// Логика взаимодействия для ForUserPage.xaml
    /// </summary>
    public partial class ForUserPage : Page
    {
        ObservableCollection<TestClass> testClasses = new ObservableCollection<TestClass>();
        private int correctAnswersCount = 0;
        private int currentQuestionIndex = 0;

        public ForUserPage()
        {
            InitializeComponent();
            DataContext = this;
            LoadTests();
            ShowNextQuestion();
        }

        private void ShowNextQuestion()
        {
            if (testClasses != null)
            {
                if (currentQuestionIndex < testClasses.Count)
                {
                    var currentQuestion = testClasses[currentQuestionIndex];
                    QuestionTextBlock.Text = currentQuestion.Description;
                    DataContext = currentQuestion;
                }
                else
                {
                    ShowTestResults();
                }
            }
            
        }


        private void ShowTestResults()
        {
            MessageBox.Show($"Тест завершен. Правильных ответов: {correctAnswersCount} из {testClasses.Count}");
        }


        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window currentWindow = Window.GetWindow(this);
            currentWindow.Close();

        }

        private void CreateTest_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TestGo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TEST_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LoadTests()
        {
            testClasses = LoadFromJson("testClasses.json");
        }

        private void otvet1_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer(Answer.First);
        }

        private void otvet2_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer(Answer.Second);
        }

        private void otvet3_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer(Answer.Third);
        }

        private void CheckAnswer(Answer answer)
        {
            var currentQuestion = testClasses[currentQuestionIndex];
            if (answer == currentQuestion.CorrectAnswer)
            {
                correctAnswersCount++;
            }
            currentQuestionIndex++;
            ShowNextQuestion();
        }

        private ObservableCollection<TestClass> LoadFromJson(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<ObservableCollection<TestClass>>(json);
            }
            return new ObservableCollection<TestClass>();
        }
    }
}
