using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World");

            Person person = new Person("Zakaria Boundryyyyyyy", 24);
            Console.WriteLine(person);
            person.Name = "Seyed";
            Console.WriteLine(person);

            Animal fido = new Animal("Baloo", 24, "hund");

            Console.WriteLine($"Fido er en hund? {fido.IsDog()}");

            MyList numbers = new MyList();

            //opgave 6
            /*numbers.Add(20);
            numbers.Add(50);
            numbers.Add(60);
            numbers.Add(12);
            numbers.Add(423);

            numbers.PrintNumbers(); */

            //opg 7

            for(int i = 1; i <= 10; i++)
            {
                numbers.Add(new Random().Next(1, 100));
            }

            numbers.PrintNumbers();
        }
    }
}
