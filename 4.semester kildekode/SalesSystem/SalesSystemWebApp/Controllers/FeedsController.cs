using BusinessLayer;
using DataTransferObjects.Models;
using SalesSystemWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
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


            return View("Index", viewModel);
        }


        public async Task<ActionResult> Delete(Guid id)
        {
            using(HttpClient client = new HttpClient())
            {
                await client.DeleteAsync($"https://localhost:44357/api/Feed/Delete/{id}");
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Create()
        {

            ViewBag.Heading = "Opret feed";
            ViewBag.ButtonTitle = "Opret";

			return View("Form", viewModel);
        }

        [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(FeedDetailDto feed, List<string> Attributes)
        {

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Update(Guid id)
        {
            viewModel.Feed = viewModel.feedController.GetFeedDetails(id);
			ViewBag.Heading = "Opdatere feed";
            ViewBag.ButtonTitle = "Opdatere";

			return View("Form", viewModel);
        }

        [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Update(Guid id, FeedDetailDto feed)
        {

            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult Details(Guid id)
        {
            viewModel.Feed = viewModel.feedController.GetFeedDetails(id);
            return View("Details", viewModel);
        }
    }
}