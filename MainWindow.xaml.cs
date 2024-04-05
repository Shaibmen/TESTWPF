using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PageFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void CreateTest_Click(object sender, RoutedEventArgs e)
        {
            if (TextTextCreate.Text == "jopa")
            {
                TestWindow testWindow = new TestWindow();
                CreatorPage page = new CreatorPage();
                testWindow.Content = page;
                testWindow.Show();
                this.Close();
            }

        }

        private void TestGo_Click(object sender, RoutedEventArgs e)
        {
            CreatorPage creatorPage = new CreatorPage();
            if (creatorPage.TEST.Items.Count == 0)
            {
                TestWindow testWindow = new TestWindow();
                NULLPage nullPage = new NULLPage();
                testWindow.Content = nullPage;
                testWindow.Show();
                this.Close();
            }
            else
            {
                TestWindow testWindow = new TestWindow();
                ForUserPage page = new ForUserPage();
                testWindow.Content = page;
                testWindow.Show();
                this.Close();
            }
            
        }
    }
}
