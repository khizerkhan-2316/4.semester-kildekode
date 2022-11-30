using Lektion14___URL_routing_og_model_binding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lektion14___URL_routing_og_model_binding.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index(string studentId)
        {
            ViewBag.StudentId = studentId;  
            return View();
        }

        public ActionResult Find(string firstName, string lastName)
        {
            ViewBag.FirstName = firstName;  
            ViewBag.LastName = lastName;
            return View();
        }

        [HttpPost]
        public ActionResult Create()
        {   
            return View("Create");
        }

        public ActionResult PersonCreatedCollection(FormCollection formCollection)
        {
            return View(new Person {FirstName = formCollection["FirstName"], LastName = formCollection["LastName"], Age = int.Parse(formCollection["Age"]) });
        }
    }
}