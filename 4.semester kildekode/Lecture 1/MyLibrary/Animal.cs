using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Animal : IAnimal
    {


        public string Name { get; set; }
        public int Age { get; set; }

        public String Specie { get; set; }

        public Animal(string name, int age, String specie)
        {
            this.Name = name;
            this.Age = age;
            this.Specie = specie;
        }

        public bool IsDog()
        {
            return this.Specie.ToLower().Equals("hund");
        }

     
    }
}
