using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5._3
{
    internal class Person
    {

        public string Name { get; set; }
        public int Age { get; set; }

        public int Weight { get; set; }
        public int Score { get; set; }
        public bool Accepted { get; set; }


        public Person(string data)
        {
            var L = data.Split(';');

            this.Name = L[0];
            this.Age = int.Parse(L[1]);
            this.Weight = int.Parse(L[2]);
            this.Score = int.Parse(L[3]);
            this.Accepted = false;
        }


        public override string ToString()
        {
            return $"Person: Name:{this.Name}, Age: {this.Age}, Weight: {this.Weight}, Score: {this.Score}, Accepted: {this.Accepted}";
        }


         

        public static List<Person> ReadCSvFile(string fileName)
        {
            List<Person> list = new List<Person>();
            try
            {
                using (var file = new StreamReader(fileName))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        var p = new Person(line);
                        list.Add(p);
                    }
                }
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return list;
        }


    }
}
