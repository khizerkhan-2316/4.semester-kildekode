using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_2___Language_constructions
{
    internal class Exercise3
    {
        static void Main(string[] args)
        {

            Boolean isFinished = false;

            while (!isFinished)
            {
                
                Console.WriteLine("Enter a number\n");
                int inputNumber = int.Parse(Console.ReadLine());

                if(inputNumber != 0)
                {
                    PrintFibonacciNumbers(inputNumber);

                }
                else
                {
                    isFinished = true;
                }

            }

        }


        private static void PrintFibonacciNumbers(int number)
        {
            int val1 = 0, val2 = 1, val3, i, n;
            n = number;

            Console.WriteLine("Fibonacci series:");
            Console.Write(val1 + " " + val2 + " ");
            for (i = 2; i < n; ++i)
            {
                val3 = val1 + val2;
                Console.Write(val3 + " ");
                val1 = val2;
                val2 = val3;

            }
        }

        private static int[] GetFibonacciNumbers(int number)
        {
            int val1 = 0, val2 = 1, val3, i, n;
            n = number;

            int[] fiboNumbers = new int[number];

            Console.WriteLine("Fibonacci series:");
            Console.Write(val1 + " " + val2 + " ");
            for (i = 2; i < n; ++i)
            {
                val3 = val1 + val2;
                fiboNumbers.Prepend(val3);
                val1 = val2;
                val2 = val3;

            }

            return fiboNumbers;
        }
    }

}
