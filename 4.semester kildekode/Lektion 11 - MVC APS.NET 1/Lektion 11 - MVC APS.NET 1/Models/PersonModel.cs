using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lektion_11___MVC_APS.NET_1.Models
{
    public class PersonModel
    {

        public string Name { get; set; }    
        public int Age { get; set; }

        private DateTime _birthday;
        public String BirthDay
        {
            get { return _birthday.ToString("D", new System.Globalization.CultureInfo("dk-DK")); }

            set { _birthday = new DateTime(long.Parse(value)); }
        }


        public PersonModel(string name, int age, DateTime birthDay)
        {
            Name = name;
            Age = age;
            _birthday = birthDay;
        }   
    }
}