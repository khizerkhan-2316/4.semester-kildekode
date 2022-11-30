using BusinessLayer;
using DataTransferObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesSystemWebApp.ViewModels
{
	public class FeedsViewModel
	{

		public readonly FeedController feedController = FeedController.GetController();
		public readonly CategoryController categoryController = CategoryController.GetController();


		public FeedDetailDto Feed {get; set;}

		public List<SelectListItem> Formats { get; set; }

		public ProductDetailDto Product { get; set; }

		public List<CategoryDto> Categories { get; set; }

		public int? Limit { get; set; }





		public FeedsViewModel()
		{
			Feed = new FeedDetailDto();
			Formats = new List<SelectListItem>
			{
				new SelectListItem { Text = "xml", Value = "xml"},
				new SelectListItem { Text = "json", Value = "json"}

			};

			Product = new ProductDetailDto();
			Categories = categoryController.GetCategories();

		}

	
	}
}