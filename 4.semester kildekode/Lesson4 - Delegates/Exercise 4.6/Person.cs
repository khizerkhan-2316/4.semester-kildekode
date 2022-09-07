using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4._6
{
    internal class Person

    {



        public string Name { get; set; }

        public int Age { get; set; }
        public double Weight { get; set; }


        public Person(string name, int age, double weight)
        {
                this.Name = name;
                this.Age = age;
                this.Weight = weight;
        }


            public override string ToString()
        {
            return $"Person: {this.Name}, {this.Age}, {this.Weight}";
        }



    }
}
