﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ForUserPage()
        {
            InitializeComponent();
            DataContext = this;
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
    }
}
