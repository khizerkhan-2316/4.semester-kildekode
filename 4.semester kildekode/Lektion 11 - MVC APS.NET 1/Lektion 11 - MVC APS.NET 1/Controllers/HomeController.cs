using Lektion_11___MVC_APS.NET_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lektion_11___MVC_APS.NET_1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
       /* public String Index()
        {
            return "A simple string";
        }
        */

        public ActionResult Index()
        {
            string name = "boundry";
            int age = 20;
            DateTime birthday = new DateTime(2022, 10, 01);
           
            ViewBag.name = name;
            ViewBag.age = age;
            ViewBag.birthday = birthday.ToString("D", new System.Globalization.CultureInfo("dk-DK"));  

            return View(new PersonModel("boundry", 20, new DateTime(2022, 10, 01)));
        } 
    }
}