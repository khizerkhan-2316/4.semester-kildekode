using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3._2
{
    internal abstract class Employee : IHasAddress
    {
        private Guid _id = Guid.NewGuid();

        public CPrNumber CPrNumber { get; set; }

        private const int _hoursPerWeek = 37;

        public string Id
        {
            get{ return this._id.ToString(); }
        }


        public string Name { get; set; }

        public Address Address { get; set; }

        public int Age { get; set; }

        public string PhoneNumber { get; set; }

        public int HoursPerWeek { get { return Employee._hoursPerWeek; } }


        public abstract double calculateWeeklySalary();
        public Employee(CPrNumber CprNumber, string name, Address address, int age, string phoneNumber)
        {
            this.Name = name;
            this.Address = address;
            this.Age = age;
            this.PhoneNumber = phoneNumber;
            this.CPrNumber = CprNumber;
        }

        public override string ToString()
        {
            return $"Employee: Id: {Id}, CPR: {CPrNumber}, Name: {Name}, Age: {Age},{Address}, Phonenumber: {PhoneNumber}";
        }
       


    }
}
