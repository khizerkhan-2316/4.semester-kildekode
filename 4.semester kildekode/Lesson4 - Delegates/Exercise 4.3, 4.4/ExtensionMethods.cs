using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4._3__4._4
{
    public static class ExtensionMethods
    {

        public static int Factorial (this int n){
            return Program.Factorial(n);
        }

        public static int Power(this int n, int p)
        {
            return Program.Power(n, p);
        }

        }
}
