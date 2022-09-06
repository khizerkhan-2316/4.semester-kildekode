using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3._2
{
    internal class Surveyor : Mechanic
    {

        public int NumbersOfChecksPerWeek { get; set; }
        private int _pricePerCheck = 290;

        public Surveyor(CPrNumber CPrNumber,int yearOfApperanciateTest, double hourlyWage, string name, Address address, int age, string phonenumber) : base(CPrNumber, yearOfApperanciateTest, hourlyWage, name, address, age, phonenumber)
        {

        }

        public int PricePerCheck{ get { return this._pricePerCheck; } set { this._pricePerCheck = value; } }


        public override double calculateWeeklySalary()
        {
            return this.NumbersOfChecksPerWeek * this.PricePerCheck;
        }
        public override string ToString()
        {
            return $"Surveyor extends: {base.ToString()}";
        }

    }
}
