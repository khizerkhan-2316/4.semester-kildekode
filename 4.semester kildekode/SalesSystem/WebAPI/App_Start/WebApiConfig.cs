using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAPI.Filters;

namespace WebAPI
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services
			config.EnableCors();
			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Filters.Add(new ValidateModelAttribute());

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);


			config.Routes.MapHttpRoute(
		name: "FeedApi",
		routeTemplate: "api/{controller}/{action}/{id}",
		defaults: new { id = RouteParameter.Optional }

		);
		}
	}
}
