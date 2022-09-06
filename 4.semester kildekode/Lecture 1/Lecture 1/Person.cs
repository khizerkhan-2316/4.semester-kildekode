using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_1
{
    internal class Person
    {

        private String _Name;
        private int Age { get; set; }

        public Person(String name, int age)
        {
            this._Name = name;
            this.Age = age;
        }


        public override String ToString()
        {
            return $"Name:, {this._Name}, Age: {this.Age}";
        }

        public String Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
            }
             }

        


    }
}
