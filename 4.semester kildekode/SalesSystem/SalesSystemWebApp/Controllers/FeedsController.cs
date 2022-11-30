using BusinessLayer;
using SalesSystemWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace SalesSystemWebApp.Controllers
{
    public class FeedsController : Controller
    {
        private FeedsViewModel viewModel;


        public FeedsController()
        {
            viewModel = new FeedsViewModel();   
        }

        // GET: Feeds
        public ActionResult Index()
        {


            return View("Index");
        }


        [HttpGet]
        public ActionResult Create()
        {

            return View("Form", viewModel);
        }
    }
}