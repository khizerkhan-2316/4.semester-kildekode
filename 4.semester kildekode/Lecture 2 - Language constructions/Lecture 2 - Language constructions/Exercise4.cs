using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_2___Language_constructions
{
    internal class Exercise4
    {

        static void Main(string[] args)
        {
            CalculateAge(new DateTime(1982, 8, 1), out int age);
            Console.WriteLine(age);
            Console.ReadLine();            
        }

        static void CalculateAge(DateTime birthday, out int age)
        {
            age = (int)((DateTime.Now - birthday).TotalDays / 365.242199);

          
        }

    }
}
