using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4._6
{
    internal class ByWeightSorter : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return (int) (x.Weight - y.Weight);
        }
    }
}
