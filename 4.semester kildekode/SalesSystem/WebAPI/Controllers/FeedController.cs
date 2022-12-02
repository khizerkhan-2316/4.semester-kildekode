using BusinessLayer;
using DataAccessLayer.Model;
using DataTransferObjects.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Runtime.Serialization;
using System.ServiceModel.Syndication;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using System.Web.UI.WebControls;
using System.Xml;
using WebAPI.Filters;

namespace WebAPI.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class FeedController : ApiController
	{

		private BusinessLayer.FeedController controller = BusinessLayer.FeedController.GetController();

		[HttpPost]
		[ValidateModel]
		public HttpResponseMessage Post([FromBody] FeedDetailDto feed)
		{
			string baseUri = new Uri(Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.PathAndQuery, String.Empty)).ToString();
			Console.WriteLine(baseUri);


			if (!ModelState.IsValid)
			{
				return new HttpResponseMessage(HttpStatusCode.BadRequest);
			}

			feed.Link = baseUri;
			controller.CreateFeed(feed);

			return new HttpResponseMessage(HttpStatusCode.OK);
		}


		public HttpResponseMessage Delete(Guid id)
		{
			controller.DeleteFeed(id);
			return new HttpResponseMessage(HttpStatusCode.OK);
		}


		[HttpGet]
		public HttpResponseMessage Details(Guid id)
		{
			string feedType = controller.GetFeedType(id);
			ProductDetailDto product = new ProductDetailDto();

			string best = product.GetType().GetProperty("ProductId").GetValue(product, null).ToString();
			Console.WriteLine(best);

			if (feedType == "xml")
			{
				string feedContent = controller.GenerateXmlFeed(id);

				return new HttpResponseMessage()
				{
					Content = new StringContent(feedContent, Encoding.UTF8, "application/xml")
				};

			} else if(feedType == "json")
			{
				return new HttpResponseMessage()
				{
					Content = new ObjectContent(typeof(List<Dictionary<string, object>>), controller.GenerateJsonFeed(id), new JsonMediaTypeFormatter(), (string)null)
				};

			}


			return new HttpResponseMessage(HttpStatusCode.BadRequest);
		}

	}
}
