using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ__Examples
{
	internal class Program
	{
		static void Main(string[] args)
		{

		

			//Query Method syntax:

			int[] scores = { 97, 92, 81, 60 };   // Data source

			IEnumerable<int> scoreQuery = scores.Where((int score) => score > 80); // query

			List<int> filteredScores = scoreQuery.ToList(); // eksekvering af query
			List<int> filteredScoresV2 = scores.Where((int score) => score > 80).ToList(); 





			//Query expression syntax:

			int[] numbers = { 97, 92, 81, 60 };  //Data source

			IEnumerable<int> numbersQuery = (IEnumerable<int>)(from number in numbers
											where number > 80
											select number);



			
			// Select Clause and anonomyous objects and where and orderBy: 


			// Data souurce:
			List<Person> people = new List<Person>()
			{ 
				new Person("Anders Larsen", 20, "Lars larsens vej"),
				new Person("Line Søndergaard Petersen", 25, "Harald jensens plads 10"),
				new Person("Oliver Tree", 17, "Mikkel andersens vej 20j"),
				new Person("Robin Andersen", 16, "Søndergade 11"),

			};



			// with method syntax and deffered execution execution:

			var adults = people.Where(p => p.Age >= 18).OrderByDescending(p => p.Age).Select(p => new { Address = p.Address });




			// with query expression:


			var adultsOverEighteen = from person in people
									 where person.Age > 18
									 orderby person.Age descending
									 select new { Address = person.Address };



			Console.WriteLine(string.Join(",", adults));
			Console.WriteLine(string.Join(",", adultsOverEighteen));


			Console.ReadLine();


			


		}
	}
}
