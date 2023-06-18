﻿using System;
using System.Collections.Generic;
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
using library;
using ThemeLib;

namespace liibWPF
{
    public partial class MainWindow : Window
    {
        public string CurrentTheme;
        public MainWindow()
        {
            InitializeComponent();
            CurrentTheme = "Pink";
        }
        public static string solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public static string filePath = System.IO.Path.Combine(solutionDirectory, "person.json");

        public List<Person> fileData = new List<Person>();
        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text != null && age.Text != null)
            {
                Person person = new Person { name = name.Text, age = Convert.ToInt32(age.Text)};
                fileData.Add(person);
                Serialize_Deserialize.Serialize(fileData, filePath);//
            }
        }

        private void unload_Click(object sender, RoutedEventArgs e)
        {
            persons.Items.Clear();
            if (File.Exists(filePath))
            {
                fileData = Serialize_Deserialize.Deserialize<List<Person>>(filePath);
            }
            foreach (Person person in fileData)
            {
                persons.Items.Add($"Name: {person.name}, Age: {person.age}");
            }
        }

        private void changeTheme_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTheme == "Pink")
            {
                ResourceDictionary newTheme = new ResourceDictionary();
                newTheme.Source = new Uri("/ThemeLib;component/Themes/DarkTheme.xaml", UriKind.RelativeOrAbsolute);
                Application.Current.Resources.MergedDictionaries[0] = newTheme;
                CurrentTheme = "Dark";
                return;
            }
            else
            {
                ResourceDictionary newTheme = new ResourceDictionary();
                newTheme.Source = new Uri("/ThemeLib;component/Themes/LightTheme.xaml", UriKind.RelativeOrAbsolute);
                Application.Current.Resources.MergedDictionaries[0] = newTheme;
                CurrentTheme = "Pink";
                return;
            }
        }
    }

    public class Person {
        public string name;
        public int age;
    }

}