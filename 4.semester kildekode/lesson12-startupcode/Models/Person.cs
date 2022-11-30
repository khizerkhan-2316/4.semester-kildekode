using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Lesson02_Startup.Models
{
    public class Person
    {


        public string FirstName;


        public string LastName;
     

        public string Address;
       

        public string Zip;

        public string City;

        public List<string> PhoneNumber;
        


        private DateTime birthday;

        public DateTime Birthday
        {
            set
            {
                if (DateTime.Now.Year - value.Year < 0 || DateTime.Now.Year - value.Year > 120)
                {
                    throw new Exception("Age not accepted");
                }
                else
                {
                    birthday = value;
                }
            }
            get { return birthday; }
        }

        public int Age
        {
            get
            {

                DateTime now = DateTime.Now;
                int age;
                age = now.Year - Birthday.Year;
                // calculate to see if the person hasn’t had birthday yet
                // subtract one year if that is not the case
                if (now.Month < Birthday.Month || (now.Month == Birthday.Month
                && now.Day < Birthday.Day))
                {
                    age--;
                }

                return age;
            }
        }

        public void AddPhone(string phone)
        {
            this.PhoneNumber.Add(phone);
        }



        public Person(string firstName, string lastName, string address, string zip, string city)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.Zip = zip;
            this.City = city;
            this.PhoneNumber = new List<string>();
        }
    }
}