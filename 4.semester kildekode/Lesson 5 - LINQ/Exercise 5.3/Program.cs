using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5._3
{
    internal class Program
    {
        // change type to List<Person> for exercises before 5.7
        public static void PrintList(List<Person> persons)
        {
            Console.WriteLine(String.Join("\n", persons));
        }

        public static void PrintNumbersList(List<int> numbers)
        {
            Console.WriteLine(String.Join("\n", numbers));
        }

        public static void PrintIndex(int index)
        {
            Console.WriteLine($"Index: {index}");
        }
        static void Main(string[] args)
        {

           
              List<Person> persons =  Person.ReadCSvFile("C:\\Users\\khize\\Desktop\\Skole\\Datamatiker\\4.semester\\C# .NET\\4.semester kildekode\\Lesson 5 - LINQ\\Exercise 5.3\\data1.csv");
              List<Person> persons1 = Person.ReadCSvFile("C:\\Users\\khize\\Desktop\\Skole\\Datamatiker\\4.semester\\C# .NET\\4.semester kildekode\\Lesson 5 - LINQ\\Exercise 5.3\\data2.csv");
			//Exercise 5.3: 
			//1: Find all persons with score below 2: 

			//PrintList(persons.FindAll((Person person) => person.Score < 2));

			//2: Find all persons with even numbers as score: 

			// PrintList(persons.FindAll((Person person) => person.Score % 2 == 0));

			// 3: Find all persons with a even number ass score and weight > 60: 

			// PrintList(persons.FindAll((Person person) => person.Score % 2 == 0 && person.Weight > 60));

			// 4: Find all persons with a weight that can be divided by 3: 

			// PrintList(persons.FindAll((Person person) => person.Weight % 3 == 0));

			//Exercise 5.4:

			// 1: Use findIndex to find the index on the first person with the score of = 3
			//PrintIndex(persons.FindIndex((Person person) => person.Score == 3));

			//2: Use FindIndex to find the index on the first person below 10 years and a score = 3;

			//PrintIndex(persons.FindIndex((Person person) => person.Age < 10 && person.Score == 3));

			//3: How many persons is below 10 and have a score = 3?

			//  int numOfPersons = persons.FindAll((Person person) => person.Age < 10 && person.Score == 3).Count();

			//Console.WriteLine(numOfPersons);

			//4: Use FindIndex to find the index on the first person below 8 years with a score on 3:

			// persons.FindIndex((Person person) => person.Age < 8 && person.Score == 3);


			//exercise 5.6: Make a predicate and see if the each persons accepted = true if predicate = true;

			//  persons.SetAcceptedP((Person p) => p.Score >= 6 && p.Age <40);
			//PrintList(persons);

			// Exercise 5.7
			// 1. Order by age (Asending)
			// PrintList(persons.OrderBy((Person person) => person.Age));

			// 2. Order by weight (Asending)
			// PrintList(persons.OrderBy((Person person) => person.Weight));

			// Order by age (Desending)
			// PrintList(persons.OrderByDescending((Person person) => person.Age));

			// Order by weight (Desending)

			// PrintList(persons.OrderByDescending((Person person) => person.Weight));

			// Exercise 5.8
			//int[] numbers = { 34, 8, 56, 31, 79, 150, 88, 7, 200, 47, 88, 20 };

			// 5.8.1: Return all two digits integer sorted asceding order using LINQ method syntax


			//int[] sortedNumbers = numbers.Where((int number) => number.ToString().Length == 2).OrderBy((int number) => number).ToArray();

			// 5.8.2: Return all two digits integer sorted descending order using LINQ method syntax

			// int[] sortedNumbers = numbers.Where((int number) => number.ToString().Length == 2).OrderByDescending((int number) => number).ToArray();

			// 5.8.3: Like 5.8.1 but with strings instead (asending)

			// string[] sortedNumbersAsStrings = numbers.Where((int number) => number.ToString().Length == 2).OrderBy((int number) => number).Select((int number) => $"'{number.ToString()}'").ToArray();

			// 5.8.4: 
			/*string[] sortedNumbersAsStrings = numbers.Where((int number) => number.ToString().Length == 2).OrderBy((int number) => number).Select((int number) => number % 2 == 0? $"'{number.ToString()}' even" : $"'{number.ToString()}' odd").ToArray();


             foreach (string number in sortedNumbersAsStrings)
             {
                 Console.WriteLine(number);
             }
              */
			/* Exercise 5.9
            persons.Reset();
            Console.WriteLine("-----------------------RESET Accepted BELOW--------------------------");
            PrintList(persons);

            */

			/* List<int> numbers = new List<int>();
             Random random = new Random();
             for(int i = 1; i <= 100; i++)
             {

                 numbers.Add(random.Next());
             } */
			// find count of uneven numbers in numbers list: 
			// int countOfUnEven = numbers.Where((int number) => number % 2 != 0).Count();

			//find count of unique numbers in list: 

			//int uniqueNumbers = numbers.Distinct().Count();

			//find the first 3 uneven numbers:
			/*
            List<int> firstThreeUnEvenNumbers = numbers.Where((int number) => number % 2 != 0).Take(3).ToList();

            foreach (int number in firstThreeUnEvenNumbers)
            {
                Console.WriteLine(number);
            }  */

			// find all unique uneven numbers in list: 

			//PrintNumbersList(numbers.Where((int number) => number % 2 != 0).Distinct().ToList());


			// Exercise 5.11: Group persons by their first letter in their name.

			/* List<IGrouping<char, Person>> groupedPersons =  persons.GroupBy((Person person) => person.Name[0]).ToList();

             foreach(IGrouping<char, Person> grouping in groupedPersons)
             {
                 Console.WriteLine(grouping.Key);

                 foreach(Person person in grouping)
                 {
                     Console.WriteLine(person);
                 }  
             }



             */




			List<Person> personsWithSameNamev1 = persons.Join(persons1,
				person => person.Name,
				person1 => person1.Name,

				(p1, p2) => p1)
				.Select(p => new {Name = p.Name}).ToList();	




			// Exercise: 5.12 :Find persons with same name in persons and persons1 using LINQ query expression syntax (join).



			IEnumerable<Person> personsWithSameName = from person in persons 
                                               join person1 in persons1 on person.Name equals person1.Name select person;


            foreach(Person person in personsWithSameName)
            {
                Console.WriteLine(person);
            }

            Console.ReadLine();
        }
    }
}
