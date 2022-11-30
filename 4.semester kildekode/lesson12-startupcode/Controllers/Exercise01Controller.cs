using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Lesson02_Startup.Controllers
{
    public class Exercise01Controller : Controller
    {
        

        public ActionResult Index()
        {
            // create a new product object with instance name glass
            Product glass = new Product("Wine glass", 160.50, "grandcru.jpg", "Greendozer");
            Product bin = new Product("Bin", 200, "bin_35l.jpg", "Genrbugte varer ApS");
            Product knife = new Product("Knife", 300, "st_knife.jpg", "Knivproduktion");

            ViewBag.Glass = glass;
            ViewBag.Bin = bin;
            ViewBag.Knife = knife;
            return View();
        }

    }
}
