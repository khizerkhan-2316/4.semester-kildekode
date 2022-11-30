using Lesson02_Startup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson02_Startup.Controllers
{
    public class PersonController : Controller
    {
        //
        // GET: /Person/

        public ActionResult Index()
        {
            Person person = new Person("Lars", "Mikkelsen", "Søren Frichs Vej 123", "8230", "Aarhus");
            Person person1 = new Person("Anders", "Mikkelsen", "Stavtrupvej 143a", "8260", "Aarhus");
            Person person2 = new Person("Fiona", "Larsen", "Kalmargade 23", "8240", "Aarhus N");

            person.AddPhone("23124232");
            person1.AddPhone("23421234");
            person2.AddPhone( "23124534");

            person.Birthday = new DateTime(1950, 5, 12);
            person1.Birthday = new DateTime(2000, 10, 20);
            person2.Birthday = new DateTime(2018, 2, 23);


            List<Person> persons = new List<Person>();
            persons.Add(person);
            persons.Add(person1);
            persons.Add(person2);

            ViewBag.Persons = persons;

            return View();
        }

    }
}
