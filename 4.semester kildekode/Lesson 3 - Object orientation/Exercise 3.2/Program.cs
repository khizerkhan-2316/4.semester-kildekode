using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
           // List<Employee> employees = new List<Employee>();

            EmployeeList<Address> collection = new EmployeeList<Address>();

            Address address1 = new Address("Kjærgårdparken 10", "3821", "Næstved");
            Address address2 = new Address("Lars Larsens vej 23", "4100", "Vejle");
            Address address3 = new Address("Anne Annesens vej 14", "8000", "Aarhus C");
            Address address4 = new Address("Basen 23", "1241", "Vibe");
            Address address5 = new Address("Havneplads 2", "4212", "Vejle");


            IHasAddress employee1 = new Mechanic(new CPrNumber("290599", "3254"),1982, 500, "Zakaria Banouri", address1, 20, "23852314");
            IHasAddress employee2 = new Foreman(new CPrNumber("240659", "9423"), 1985, 3000, 1982, 600, "Lars Larsen", address2, 69, "88888888");
            IHasAddress employee3 = new Surveyor(new CPrNumber("120542", "3245"), 1990, 700, "Anne Michelsen", address3, 40, "31203423");

            IHasAddress company1 = new Company("Jysk", address4);
            IHasAddress company2 = new Company("Mærsk", address5);




            collection.AddElement(employee1.Address, employee1);
            collection.AddElement(employee2.Address, employee2);
            collection.AddElement(employee3.Address, employee3);
            collection.AddElement(company1.Address, company1);
            collection.AddElement(company2.Address, company2);


            //            Console.WriteLine($"size in collection: {collection.Size()}");





            /* Opgave inden 3.5
            employees.Add(employee1);
            employees.Add(employee2);
            employees.Add(employee3);


            employees.ForEach((Employee employee) => Console.WriteLine(employee)); */

            Time t1, t2;
            t1 = new Time("08:30:00");
            t2 = t1;
            t2.Hours = t2.Hours + 2;

            Console.WriteLine(t2.Hours + 2);
            Console.WriteLine(t1.ToString());
            Console.WriteLine(t2.ToString());


            Console.ReadLine(); 
        }
    }


    struct Time
    {
        private int _secondsSinceMidnight;
        private readonly int _maxSeconds;
        private int _hours;
        private int _minutes;
        private int _seconds;



       public Time(string time)
        {
            _hours = int.Parse(time.Substring(0, 2));
            _minutes = int.Parse(time.Substring(3, 2));
            _seconds = int.Parse(time.Substring(6, 2));
            _maxSeconds = 86400;
            _secondsSinceMidnight = (_hours * 3600) + (_minutes / 60) + _seconds;
        }

        public Time(int hours, int minutes, int seconds)
        {
            _hours = hours;
            _minutes = minutes;
            _seconds = seconds;
            _maxSeconds = 86400;
            _secondsSinceMidnight = (hours / 3600) + (minutes / 60) + seconds;
        }
       


        public int Hours 
        
        {
            set 
            {
                int hour = value;
                int temp = _secondsSinceMidnight % 3600;
                _secondsSinceMidnight = (temp + hour * 3600) % _maxSeconds;
                
            } 


            get

            {
                return _secondsSinceMidnight / 3600;
            }
        
        }

       

    

        public int Minutes 
        { 
          set

            {
                int minute = value;

                int temp = _secondsSinceMidnight % 60;
                _secondsSinceMidnight = (temp + minute * 60) % _maxSeconds;


            }


            get { return _secondsSinceMidnight / 60; }
        }

        public int Seconds
        {
            set
            {
                _secondsSinceMidnight += value;
            }

            get
            {
                return _secondsSinceMidnight;
            }
        }

        public override string ToString()
        {
            return $"{_hours}:{_seconds}:{_minutes}";
        }
    }
}
