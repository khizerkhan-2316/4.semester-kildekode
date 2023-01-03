using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//generic stack that has the same functionallity but works for all types, both built-in and custom made. 
			MyStack<int> numbers = new MyStack<int>(10);


			for(int i = 1; i <=10; i++)
			{
				numbers.push(i);
			}


			Console.WriteLine(numbers.ToString());


			MyStack<string> strings = new MyStack<string>(10);

			for (int i = 1; i <= 10; i++)
			{
				strings.push(Guid.NewGuid().ToString("N").Substring(0, 12));
			}

			Console.WriteLine(strings.ToString());


			Console.ReadLine();

		}
	}
}
