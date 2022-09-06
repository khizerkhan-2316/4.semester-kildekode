using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3._2
{
    internal class Mechanic : Employee
    {

        public int YearOfApperanciateTest { get; set; }
        public double HourlyWage { get; set; }  

        public Mechanic(CPrNumber CprNumber, int yearOfApperanciateTest, double hourlyWage, string name, Address address, int age, string phonenumber ): base(CprNumber,name, address, age, phonenumber)
        
        {
            this.YearOfApperanciateTest = yearOfApperanciateTest;
            this.HourlyWage = hourlyWage;

        }


        public override double calculateWeeklySalary()
        {
            return this.HourlyWage * base.HoursPerWeek;
        }


        public override string ToString()
        {
            return $"Mechanic extends {base.ToString()}";
        }





    }
}
