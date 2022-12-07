using BusinessLayer;
using DataTransferObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SalesSystemWebApp.ViewModels
{
	public class FeedsViewModel
	{

		public readonly FeedBLL feedController = FeedBLL.GetController();
		public readonly CategoryBLL categoryController = CategoryBLL.GetController();


		public FeedDetailDto Feed { get; set; }

		public List<string> SelectedAttributes { get; set; }

		public List<Guid> SelectedCategories { get; set; }

		public List<FeedDto> Feeds { get; set; }

		public List<SelectListItem> Formats { get; set; }

		public ProductDetailDto Product { get; set; }

		public List<CategoryDto> Categories { get; set; }

		public List<SelectListItem> Attributes { get; set; }

		public List<SelectListItem> FeedCategories { get; set; }


		public int? Limit { get; set; }

		public string Title { get; set; }

		public string ActionName { get; set; }

		public string ButtonTitle { get; set; }

		public string ErrorMessage { get; set; }






		public FeedsViewModel()
		{
			Feed = new FeedDetailDto();
			SelectedAttributes = new List<string>();
			SelectedCategories = new List<Guid>();

			Feeds = feedController.GetFeeds();
			Formats = new List<SelectListItem>
			{
				new SelectListItem { Text = "xml", Value = "xml"},
				new SelectListItem { Text = "json", Value = "json"}

			};

			Attributes = new List<SelectListItem>();

			Product = new ProductDetailDto();
			Categories = categoryController.GetCategories();
			InitializeAttributes();
			initializeFeedCategories();
			ErrorMessage = "";
		}




		private void InitializeAttributes()
		{

			Product.GetType().GetProperties().ToList().ForEach(info => Attributes.Add(new SelectListItem { Text = info.Name, Value = info.Name }));
		}

		private void initializeFeedCategories()
		{
			FeedCategories = new List<SelectListItem>();
			Categories.ForEach(category => FeedCategories.Add(new SelectListItem { Text = category.Name, Value = category.CategoryId.ToString() }));
		}

		public void UpdateView(string title, string actionName, string buttonTitle)
		{
			Title = title;
			ActionName = actionName;
			ButtonTitle = buttonTitle;
		}


		public void InitializeSelectedItems()
		{
			Feed.Attributes.ForEach(attribute => SelectedAttributes.Add(attribute.Attribute));
			Feed.Categories.ForEach(category => SelectedCategories.Add(category.CategoryId));
		}


	}
}