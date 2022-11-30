using Lektion_13___MVC.Infrastructure;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lektion_13___MVC.Controllers
{
    public class Exercise1Controller : Controller
    {

        private List<SelectListItem> countryList = new List<SelectListItem>();
        // GET: Exercise1

        [HttpGet]
        public ActionResult Index(string Countries)
        {

            initializeSession();
            ViewBag.CountryCode = Countries;
            ViewBag.countries = countryList;

            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection formData)


        {

            initializeSession();
            ViewBag.countries = countryList;
            countryList = (List<SelectListItem>)Session["countryList"];

            var selectedItem = new SelectListItem { Text = formData["Country"], Value = formData["Code"] };

            countryList.Add(selectedItem);

            Utilities.SortSelectList(countryList, selectedItem);

       

            return View();
        }


        private void initializeSession()
        {
            if (Session["countryList"] == null)
            {
                countryList.Add(new SelectListItem { Text = "China", Value = "CN" });
                countryList.Add(new SelectListItem { Text = "Denmark", Value = "DK" });
                countryList.Add(new SelectListItem { Text = "France", Value = "FR" });
                countryList.Add(new SelectListItem { Text = "USA", Value = "US" });
                Session["countryList"] = countryList;

            }
            else
            {
                countryList = (List<SelectListItem>)Session["countryList"];
            }
        }
    }
}