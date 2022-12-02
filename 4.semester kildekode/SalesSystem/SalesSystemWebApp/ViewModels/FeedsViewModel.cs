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

		public List<FeedDto> Feeds { get; set; }

		public List<SelectListItem> Formats { get; set; }

		public ProductDetailDto Product { get; set; }

		public List<CategoryDto> Categories { get; set; }

		public int? Limit { get; set; }






		public FeedsViewModel()
		{
			Feed = new FeedDetailDto();
			Feeds = feedController.GetFeeds();
			Formats = new List<SelectListItem>
			{
				new SelectListItem { Text = "xml", Value = "xml"},
				new SelectListItem { Text = "json", Value = "json"}

			};

			Product = new ProductDetailDto();
			Categories = categoryController.GetCategories();
			InitializeFeedAttributes();
			InitializeFeedCategories();
		}



		private void InitializeFeedAttributes()
		{
			List<FeedAttributeDto> attributes = new List<FeedAttributeDto>();

			Product.GetType().GetProperties().ToList().ForEach(info => attributes.Add(new FeedAttributeDto {FeedAttributeId = Guid.NewGuid(), Attribute = info.Name }));

			Feed.Attributes= attributes;
		}

		private void InitializeFeedCategories()
		{
			List<FeedCategoryDto> categories = new List<FeedCategoryDto>();

			Categories.ForEach(category => categories.Add(new FeedCategoryDto { FeedCategoryId = Guid.NewGuid(), FeedCategoryName = category.Name, CategoryId = category.CategoryId }));

			Feed.Categories = categories;

		}


	}
}