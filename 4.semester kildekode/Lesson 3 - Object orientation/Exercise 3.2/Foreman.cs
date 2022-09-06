using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3._2
{
    internal class Foreman : Mechanic
    {

        public int YearOfForeman { get; set; }

        public double BonusPerWeek { get; set; }

        public Foreman(CPrNumber CPrNumber,int yearOfForeman, double bonusPerWeek, int yearOfApperanciateTest, double hourlyWage, string name, Address address, int age, string phonenumber) : base(CPrNumber, yearOfApperanciateTest, hourlyWage, name, address, age, phonenumber)
        {
            this.YearOfForeman = yearOfForeman;
            this.BonusPerWeek = bonusPerWeek;
        }


        public override double calculateWeeklySalary()
        {
            return (base.HourlyWage * base.HoursPerWeek) + this.BonusPerWeek;
        }


        public override string ToString()
        {
            return $"Foreman extends: {base.ToString()} ";
        }


    }
}
