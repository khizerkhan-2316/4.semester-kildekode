using BusinessLayer;
using DataTransferObjects.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Filters;

namespace WebAPI.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class FeedController : ApiController
	{

		private FeedBLL feedBll = FeedBLL.GetController();

		[HttpPost]
		[ValidateModel]
		public HttpResponseMessage Post([FromBody] FeedDetailDto feed)
		{
			string baseUri = new Uri(Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.PathAndQuery, String.Empty)).ToString();

			if (!ModelState.IsValid)
			{
				return new HttpResponseMessage(HttpStatusCode.BadRequest);
			}

			feed.Link = baseUri;
			feedBll.CreateFeed(feed);

			return new HttpResponseMessage(HttpStatusCode.OK);
		}


		[HttpPut]
		[ValidateModel]
		public HttpResponseMessage Update(Guid id, [FromBody] FeedDetailDto feed)
		{

			if (!ModelState.IsValid)
			{
				return new HttpResponseMessage(HttpStatusCode.BadRequest);
			}


			string baseUri = new Uri(Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.PathAndQuery, String.Empty)).ToString();

			feed.Link = baseUri;
			feedBll.UpdateFeed(feed);

			return new HttpResponseMessage(HttpStatusCode.OK);
		}


		[HttpDelete]
		public HttpResponseMessage Delete(Guid id)
		{
			feedBll.DeleteFeed(id);
			return new HttpResponseMessage(HttpStatusCode.OK);
		}


		[HttpGet]
		public HttpResponseMessage Details(Guid id)
		{
			string feedType = feedBll.GetFeedType(id);

			if (feedType == "xml")
			{
				string feedContent = feedBll.GenerateXmlFeed(id);

				return new HttpResponseMessage()
				{
					Content = new StringContent(feedContent, Encoding.UTF8, "application/xml")
				};

			}
			else if (feedType == "json")
			{
				return new HttpResponseMessage()
				{
					Content = new ObjectContent(typeof(List<Dictionary<string, object>>), feedBll.GenerateJsonFeed(id), new JsonMediaTypeFormatter(), (string)null)
				};

			}


			return new HttpResponseMessage(HttpStatusCode.BadRequest);
		}

	}
}
