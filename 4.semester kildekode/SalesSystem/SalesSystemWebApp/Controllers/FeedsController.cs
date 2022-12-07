using DataTransferObjects.Models;
using SalesSystemWebApp.ViewModels;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Mvc;

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


		[HttpGet]
		public ActionResult Create()
		{

			viewModel.UpdateView("Opret feed", "Create", "Opret");

			return View("Form", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(FeedDetailDto feed)
		{

			var attributes = Request.Form.GetValues("Attributes");
			var feedCategories = Request.Form.GetValues("FeedCategories");

			if (feed == null || attributes == null || feedCategories == null || viewModel.Categories == null || attributes.ToList().Count == 0 || feedCategories.ToList().Count == 0 || viewModel.Categories.Count == 0)
			{

				viewModel.UpdateView("Opret feed", "Create", "Opret");
				viewModel.ErrorMessage = "Der skal vælges mindst en attribut og en kategori";
				return View("Form", viewModel);
			}



			viewModel.feedController.ModifyFeed(feed, attributes.ToList(), feedCategories.ToList(), viewModel.Categories);


			using (HttpClient client = new HttpClient())
			{
				var response = await client.PostAsync("https://localhost:44357/api/Feed/", feed, new JsonMediaTypeFormatter());
			}

			return RedirectToAction("Index");
		}


		[HttpGet]
		public ActionResult Update(Guid id)
		{
			viewModel.Feed = viewModel.feedController.GetFeedDetails(id);
			viewModel.InitializeSelectedItems();

			viewModel.UpdateView("Opdatere feed", "Update", "Opdatere");

			return View("Form", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Update(Guid id, FeedDetailDto feed)
		{

			var attributes = Request.Form.GetValues("Attributes");
			var feedCategories = Request.Form.GetValues("FeedCategories");

			if (feed == null || attributes == null || feedCategories == null || viewModel.Categories == null || attributes.ToList().Count == 0 || feedCategories.ToList().Count == 0 || viewModel.Categories.Count == 0)
			{

				viewModel.UpdateView("Opdatere feed", "Update", "Opdatere");
				viewModel.ErrorMessage = "Der skal vælges mindst en attribut og en kategori";
				return View("Form", viewModel);
			}


			feed.FeedId = id;
			viewModel.feedController.ModifyFeed(feed, attributes.ToList(), feedCategories.ToList(), viewModel.Categories);

			using (HttpClient client = new HttpClient())
			{
				var response = await client.PutAsync($"https://localhost:44357/api/Feed/{id}", feed, new JsonMediaTypeFormatter());
			}

			return RedirectToAction("Index");
		}


		public async Task<ActionResult> Delete(Guid id)
		{
			using (HttpClient client = new HttpClient())
			{
				await client.DeleteAsync($"https://localhost:44357/api/Feed/Delete/{id}");
			}

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