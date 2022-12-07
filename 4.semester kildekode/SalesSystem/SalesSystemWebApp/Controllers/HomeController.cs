using System.Web.Mvc;

namespace SalesSystemWebApp.Controllers
{

	[HandleError]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

	}
}