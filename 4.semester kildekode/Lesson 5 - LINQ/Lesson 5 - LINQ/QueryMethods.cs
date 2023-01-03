using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5___LINQ
{
	public class QueryMethods
	{
		static void Main(string[] args)
		{
			List<int> numbers = new List<int>() { 20, 15, 0, 23, 423, 234, 34, 532, 3044, 34, 234};

			int min = numbers.Min();
			int max = numbers.Max();
			int sum = numbers.Sum();
			double avg = numbers.Average();
			int count = numbers.Count();
			List<int> disticnt = numbers.Distinct().ToList();


			Console.WriteLine($"MIN: {min}");
			Console.WriteLine($"MAX: {max}");
			Console.WriteLine($"SUM: {sum}");
			Console.WriteLine($"AVG: {avg}");




			Console.ReadLine();	
		}

	}
}
