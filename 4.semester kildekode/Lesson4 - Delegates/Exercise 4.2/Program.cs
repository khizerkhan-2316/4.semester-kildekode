using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4._2
{
    internal class Program
    {

        public delegate void Warning();

        public static void warningToConsole()
        {
            Console.WriteLine("Warning: Heat is high");
        }

        static void Main(string[] args)
        {

            PowerPlant powerPlant = new PowerPlant();
            Console.WriteLine(new Warning(Program.warningToConsole).ToString());
            powerPlant.SetWarning(new Warning(Program.warningToConsole));

            powerPlant.HeatUp();

            Console.ReadLine();
        }
    }
}
