using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Xml;

namespace TestikC
{
    /// <summary>
    /// Логика взаимодействия для CreatorPage.xaml
    /// </summary>
    public partial class CreatorPage : Page, INotifyPropertyChanged
    {
        private ObservableCollection<TestClass> testClasses = new ObservableCollection<TestClass>();



        public CreatorPage()
        {
            InitializeComponent();
            CorrectAnswerBox.ItemsSource = Enum.GetValues(typeof(Answer));
            ObservableCollection<TestClass> loadedTestClasses = LoadFromJson("testClasses.json");
            if (loadedTestClasses != null)
            {
                TestClasses = loadedTestClasses;
            }
            else
            {
                TestClasses = new ObservableCollection<TestClass>();
            }
        }

        public ObservableCollection<TestClass> TestClasses
        {
            get { return testClasses; }
            set
            {
                testClasses = value;
                OnPropertyChanged();
            }
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
            TestWindow testWindow = new TestWindow();
            ForUserPage page = new ForUserPage();
            testWindow.Content = page;
            testWindow.Show();

            
            Window currentWindow = Window.GetWindow(this);
            currentWindow.Close();
        }

        private void TEST_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTest.Text;
            string description = DescriprionTest.Text;
            string firstAnswer = FirstAnswerTest.Text;
            string secondAnswer = SecondAnswerTest.Text;
            string thirdAnswer = ThirdAnswerTest.Text;

            Answer correctAnswer = (Answer)CorrectAnswerBox.SelectedIndex;

            TestClass newTest = new TestClass(name, description, firstAnswer, secondAnswer, thirdAnswer, correctAnswer);

            TestClasses.Add(newTest);
            SaveToJson(TestClasses, "testClasses.json");
        }

        private void SaveToJson(ObservableCollection<TestClass> testClasses, string filePath)
        {
            string json = JsonConvert.SerializeObject(testClasses, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
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
