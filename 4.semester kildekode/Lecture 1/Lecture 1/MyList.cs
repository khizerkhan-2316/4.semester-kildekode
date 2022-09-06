using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_1
{
    public class MyList
    {
        private List<int> _Numbers;

        public MyList()
        {
            this._Numbers = new List<int>();
        }

        public List<int> Numbers {  
        
         get { return this._Numbers; }

            set { this._Numbers = value; }
        }

        public void Add(int number)
        {
            this._Numbers.Add(number);
        }

        public void PrintNumbers()
        {
            this._Numbers.ForEach((int number) => Console.WriteLine(number));
        }

    }
}
