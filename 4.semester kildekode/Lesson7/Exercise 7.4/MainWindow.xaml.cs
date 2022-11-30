using System;
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

namespace Exercise_7._4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            ObservableCollection<Person> persons = new ObservableCollection<Person>();

            persons.Add(new Person("Anders Mikkelsen", 54.5, 20));
            persons.Add(new Person("Anders Mikkelsen", 54.5, 20));
            persons.Add(new Person("Anders Mikkelsen", 54.5, 20));
            persons.Add(new Person("Anders Mikkelsen", 54.5, 20));
            persons.Add(new Person("Anders Mikkelsen", 54.5, 20));
            persons.Add(new Person("Anders Mikkelsen", 54.5, 20));
            persons.Add(new Person("Anders Mikkelsen", 54.5, 20));
            persons.Add(new Person("Anders Mikkelsen", 54.5, 20));
            persons.Add(new Person("Anders Mikkelsen", 54.5, 20));
            persons.Add(new Person("Anders Mikkelsen", 54.5, 20));
            persons.Add(new Person("Anders Mikkelsen", 54.5, 20));
            persons.Add(new Person("Anders Mikkelsen", 54.5, 20));
            persons.Add(new Person("Anders Mikkelsen", 54.5, 20));
            persons.Add(new Person("Anders Mikkelsen", 54.5, 20));


            InitializeComponent();
            ListBoxPersons.ItemsSource = persons;
            
        }

        private void ListBoxPersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Person person = (Person) this.ListBoxPersons.SelectedItem;
        }
    }
}
