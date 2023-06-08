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

namespace liibWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
    }

    public class Person {
        public string name;
        public int age;
    }

}