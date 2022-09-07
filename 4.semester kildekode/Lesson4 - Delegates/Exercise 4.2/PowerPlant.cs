using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exercise_4._2.Program;

namespace Exercise_4._2
{
    internal class PowerPlant
    {
        Warning warning;


        public void SetWarning (Warning warning)
        {
            this.warning = warning;
        }

        public void HeatUp() 
        {
            int random = new Random().Next(0, 100); 
            Console.WriteLine("Random number: " + random);
            
            if(random > 50)
            {
                this.warning.Invoke();
            }
        }

    }
}
