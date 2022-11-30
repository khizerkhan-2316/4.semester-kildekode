using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson_15___UI.Models
{
    public class Person
    {

        public string Name { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }


        public Person(string name, int age, string address)
        {
            Name = name;
            Age = age;
            Address = address;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}