using BusinessLayer;
using DataTransferObjects.Models;
using System.Collections.Generic;

namespace SalesSystemWebApp.ViewModels
{
	public class CategoriesViewModel
	{

		public readonly CategoryBLL categoryController = CategoryBLL.GetController();


		public CategoryDto Category { get; set; }

		public List<CategoryDto> Categories { get; }

		public string Title { get; set; }

		public string ActionMethod { get; set; }

		public string ButtonTitle { get; set; }
		public string ErrorMessage { get; set; }


		public CategoriesViewModel()
		{
			Categories = categoryController.GetCategories();
			Category = new CategoryDto();
			ErrorMessage = "";
		}

		public void UpdateView(string title, string actionMethod, string buttonTitle)
		{
			Title = title;
			ActionMethod = actionMethod;
			ButtonTitle = buttonTitle;
		}

	}
}

