using SalesSystemWebApp.ViewModels;
using System;
using System.Web.Mvc;

namespace SalesSystemWebApp.Controllers
{
	public class SalesController : Controller
	{
		private readonly SalesViewModel salesViewModel;

		public SalesController()
		{
			salesViewModel = new SalesViewModel();
		}

		// GET: Sales
		public ActionResult Index()

		{

			return View("Index", salesViewModel);

		}

		[HttpGet]
		public ActionResult Overview()
		{
			return View("Overview", salesViewModel);
		}


		[HttpGet]
		public ActionResult Details(Guid id)
		{
			salesViewModel.SaleDetails = salesViewModel.saleController.GetSaleDetails(id);
			return View("Details", salesViewModel);
		}

		public ActionResult Delete(Guid id)
		{
			salesViewModel.saleController.DeleteSale(id);
			salesViewModel.Sales = salesViewModel.saleController.GetSales();
			return RedirectToAction("Overview");

		}



	}
}