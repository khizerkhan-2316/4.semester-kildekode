using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_2___Language_constructions
{
    internal class Exercise5
    {
        static void Main(string[] args)
        {
            myNormalMethod();
            Console.ReadLine();
        }

        static private void MyMethodWithError(int num = 0)
        {
            throw new NotImplementedException();
        }

        static public void myNormalMethod(int num = 0)
        {
            try
            {
                MyMethodWithError();
            } catch(NotImplementedException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("Finally clause here!");
            }
        }
    }
}
