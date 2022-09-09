using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5___LINQ
{
    internal class Program
    {

        static void printEvenNumbers(int i)
    {
        if(i % 2 == 0)
        {
            Console.WriteLine(i);
        }
    }
 
        static void Main(string[] args)
        {


            List<int> numbers = new List<int>();


            for(int i = 0; i < 100; i++)
            {
                numbers.Add(i);
            }
            /*
                    Action<int> writeEvenNumbers = printEvenNumbers;

                        numbers.ForEach(writeEvenNumbers);

                        numbers.FindAll((int i) => i % 2 == 0);

                        numbers.FindLast((int num) => num > 15);
                        numbers.FindLastIndex((int num) => num > 15); */


            //IEnumerable<int> result = numbers.Where((int i) => i % 2 == 0);
            IEnumerable<int> result = numbers.Where((int i) => i.ToString().Length == 2);


            foreach (int number in result)
            {
                Console.WriteLine(number);
            }

            Console.ReadLine();
        }
    }
}
