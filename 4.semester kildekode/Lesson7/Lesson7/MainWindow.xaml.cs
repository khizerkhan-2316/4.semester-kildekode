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

namespace Lesson7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Person person;
        
        public MainWindow()
        {
            person = new Person("Anders Larsen", 50, 20);
            person.Score = 50;

            InitializeComponent();
            MainGrid.DataContext = person;


        }

        private void ChangePersonButton_Click(object sender, RoutedEventArgs e)
        {
            this.person.Accepted = true;
            this.person.Name = "Changed";
            this.person.Age = 40;
            this.person.Weight = 20;
            this.person.Score = 100;


        }

        private void PrintPersonButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Changed name: " + person.Name);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
