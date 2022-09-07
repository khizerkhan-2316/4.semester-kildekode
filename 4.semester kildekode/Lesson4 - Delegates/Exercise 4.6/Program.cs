using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4._6
{
    internal class Program
    {

       
        static void Main(string[] args)
        {

            List<Person> persons = new List<Person>();
            Person person = new Person("Anders Larsen", 42, 100);  //4
            Person person1 = new Person("Tommy Hansen", 24, 45);  //1
            Person person2 = new Person("Mikkel Jensen", 36, 55);   //2
            Person person3 = new Person("Anna Stensen", 100, 60);  //5
            Person person4 = new Person("Fiona Michelsen", 40, 82);  //3

            persons.Add(person);
            persons.Add(person1);
            persons.Add(person2);
            persons.Add(person3);
            persons.Add(person4);

            
            Console.WriteLine(String.Join(",", persons));
            // Implementing interfaces : 
            // persons.Sort(new ByAgeSorter());
            // persons.Sort(new ByWeightSorter());
            // persons.Sort(new ByNameSorter());

            // Lambda: 

            // persons.Sort((Person x, Person y) => x.Age - y.Age);
            // persons.Sort((Person x, Person y) => (int) (x.Weight - y.Weight)) ;
            //persons.Sort((Person x, Person y) => x.Name.CompareTo(y.Name));

            Console.WriteLine(String.Join(",", persons));


            Console.ReadLine();

        }
    }
}
