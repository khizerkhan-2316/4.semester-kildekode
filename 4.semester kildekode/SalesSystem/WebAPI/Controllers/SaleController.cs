using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DataTransferObjects.Models;
using WebAPI.Filters;



namespace WebAPI.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class SaleController : ApiController

    {
        private readonly BusinessLayer.SaleBLL controller = BusinessLayer.SaleBLL.GetController();


		[HttpPost]
		[ValidateModel]
        
        public HttpResponseMessage Post([FromBody] SaleDetailDto sale)
        {
            if (!ModelState.IsValid || sale == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            controller.CreateSale(sale);

            return new HttpResponseMessage(HttpStatusCode.OK);

        }

    }
}
