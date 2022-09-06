using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    internal interface IAnimal
    {
         String Name { get; set; }

         String Specie { get; set; }
         int Age { get; set; }

        bool IsDog();
    }
}
