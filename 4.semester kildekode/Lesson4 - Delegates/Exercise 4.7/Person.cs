using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExercises {

    public delegate string FormatPersonName(string firstName, string lastName);


    public class Person {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void PrintFullNameLastNameFirst() {
            Console.WriteLine($"{LastName}, {FirstName}");
        }

        public void PrintFullNameAllCaps() {
            Console.WriteLine($"{LastName.ToUpper()}, {FirstName.ToUpper()}");
        }


        public void PrintPersonName(FormatPersonName formatter)
        {
            Console.WriteLine(formatter.Invoke(this.FirstName, this.LastName));
        }

        public void PrintFullNameLowerCase() {
            Console.WriteLine($"{LastName.ToLower()}, {FirstName.ToLower()}");
        }

        public void PrintShortName() {
            Console.WriteLine($"{FirstName.Substring(0, 1)}. {LastName}");
        }

        public static List<Person> CreateListOfPeople() {
            return new List<Person>()
            {
                new Person() { FirstName = "Stephen", LastName = "King" },
                new Person() { FirstName = "George", LastName = "Martin" },
                new Person() { FirstName = "Ernest", LastName = "Hemingway" },
                new Person() { FirstName = "William", LastName = "Shakespeare" }
            };
        }
    }

    public class PersonUserClass {

        public static string NameByLowerCase(string firstName, string lastName)
        {
            return $"{firstName.ToLower()} {lastName.ToLower()}";
        }

        public static string PrintFullNameLastNameFirst(string firstName, string lastName)
        {
            return $"{lastName} {firstName}";
        }

        public static string GetShortName(string firstName, string lastName)
        {
            return $"{firstName.Substring(0, 1)} {lastName}";
        }

        public static string GetUpperCaseName(string firstName, string lastName)
        {
            return $"{firstName.ToUpper()} {lastName.ToUpper()}";
        }
        public static void Main(string[] args) {
            var people = Person.CreateListOfPeople();


            ////////////////////////////////
            // Start here            
            ////////////////////////////////
            // Hint:
            // This piece of code
            foreach (var p in people)
            {
				p.PrintPersonName(PrintFullNameLastNameFirst);
                p.PrintPersonName((s1, s2) => $"{s2} {s1}");
                p.PrintPersonName((s1, s2) =>
                {
                    return $"{s2} {s1}";

				});

			}


             p

			// can be translated to
			people.ForEach(p => p.PrintFullNameLastNameFirst());
            // using the ForEach method on List<>. ForEach takes a Lambda as input

            //
            // Problem 1
            // Use this to simplify the foreach statements in the while loop below
            // so they take up only one line each, instead of two
            //
            // Problem 2 (Answer in less than 30 seconds)
            // Did Problem 1 simplify or just make your code harder to read?
            //
            // Problem 3 (May be a hard problem)
            // Give the PersonUserClass class a method PrintFullNameLastNameFirst (copy from Person class)
            // And add a delegate called Formatter to your Person class
            // and a method that takes a this type of delegate as input
            // so this call becomes possible on a person:
            //
            // p.CallDelegate((F, L) => PrintFullNameLastNameFirst(F, L))
            // Use this to translate all your ForEach lines in the while loop to something like
            // people.ForEach(p => p.CallDelegate((F, L) => PrintFullNameLastNameFirst(F, L)));
            //            



                        /* ------------------------------------------------------eksempel på at tilføje flere metoder til en delegate. ---------------------------------------------------------

            FormatPersonName format = PrintFullNameLastNameFirst;

            format += GetUpperCaseName;
            format+= GetShortName;

            format.Invoke("Lars", "Larsen");

            //NB for at se nogeti konsollen så skal metoderne jo printe noget til konsollen for at man kan se output

             */

            
			while (true) {
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("Hvordan vil du have udskrevet navnene?");
                Console.WriteLine("1: Efternavn efterfulgt af fornavn");
                Console.WriteLine("2: Efternavn efterfulgt af fornavn, store bogstaver");
                Console.WriteLine("3: Efternavn efterfulgt af fornavn, små bogstaver");
                Console.WriteLine("4: Kun forbogstav af fornavn efterfulgt af efternavn");
                Console.WriteLine();
                Console.WriteLine("q: For at afslutte!");
                Console.Write("> ");
                var input = Console.ReadLine();
                switch (input.ToUpper()) {
                    case "1":
                        foreach (var p in people)
                            p.PrintPersonName(PrintFullNameLastNameFirst);
                        break;
                    case "2":
                        foreach (var p in people)
                            p.PrintPersonName(GetUpperCaseName);
                        break;
                    case "3":
                        foreach (var p in people)
                            p.PrintPersonName(NameByLowerCase);
                        break;
                    case "4":
                        foreach (var p in people)
                            p.PrintPersonName(GetShortName);
                        break;
                    case "Q": return;
                    default:
                        Console.WriteLine("Ukendt valg, prøv igen");
                        break;
                }

            
            }
        }

        
    }
}
