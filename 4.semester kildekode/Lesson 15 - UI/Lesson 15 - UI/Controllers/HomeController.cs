using Lesson_15___UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson_15___UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<Person> persons = new List<Person> 
        { 
            new Person("Anders", 20, "Lars larsensvej"), 
            new Person("Mikkel", 40, "Lars Sommervej"), 
            new Person("Jonas", 50, "Lars Aftenvej"), 
            new Person("Fiona", 20, "Lars Henafvej"), 
            new Person("Liona", 51, "Lars Testvej") 
        };


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ShowAll()
        {

            return View(persons);
        }

        public ActionResult ShowOne()
        {
            return View(persons.First());
        }

        [ChildActionOnly]
        public ActionResult ShowOnePerson(Person person)
        {
            return PartialView("ShowOnePerson", person);
        }

    }
}