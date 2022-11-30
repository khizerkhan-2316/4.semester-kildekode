using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lektion_11___MVC_APS.NET_1.Controllers
{
    public class RockbandsController : Controller
    {
        // GET: Rockbands
        public ActionResult Index()

        {
            string[] rockBands = { "Led Zeppelin", "The beatles", "Pink Floyd", "The Jimi Hendrix Experince", "Van Halen", "Queen", "The eagles", "Metalica", "U2", "Bob Marley" };
            ViewBag.rockBands = rockBands;
            return View();
        }
    }
}