using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4._3__4._4
{
    internal class Program

    {

        public static int Factorial(int n)
        {    
            if(n == 1)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }

        public static int Power(int n, int p)
        {
            return (int)Math.Pow(n, p);
        }
        
       static void Main(string[] args)
        {

            Console.WriteLine(4.Factorial());
            Console.WriteLine(2.Power(4));
            Console.ReadLine();
        }
    }
}
