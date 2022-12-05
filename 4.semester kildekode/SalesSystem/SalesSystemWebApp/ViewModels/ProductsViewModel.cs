using BusinessLayer;
using DataTransferObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesSystemWebApp.ViewModels
{
	public class ProductsViewModel
	{
		public readonly ProductBLL productController = ProductBLL.GetController();
		public readonly CategoryBLL categoryController = CategoryBLL.GetController();
		public readonly PictureBLL pictureController = PictureBLL.GetController();



		public ProductDetailDto Product { get; set; }

		public List<ProductDetailDto> Products { get; set; }

		public CategoryDto Category { get; set; }

		public List<CategoryDto> Categories { get; set; }

		public string Title { get; set; }

		public string ActionMethod { get; set; }

		public string ButtonTitle { get; set; }

		public string Query { get; set; }

		public Guid? CategoryId { get; set; }

		public string Sort { get; set; }

		public List<SelectListItem> SortOptions { get; set; }



		public ProductsViewModel()
		{
			Products = productController.GetProductsDetails();
			Categories = categoryController.GetCategories();
			Product = new ProductDetailDto();
			Category = new CategoryDto();
			CategoryId = Guid.NewGuid();
			Query = "";
			SortOptions = new List<SelectListItem>
			{
				new SelectListItem { Text = "Billigeste", Value = "price"},
				new SelectListItem {Text = "Dyreste", Value = "price-desc" },
				new SelectListItem {Text = "Navn (A-Å)", Value = "name"},
				new SelectListItem {Text = "Navn (Å - A)", Value = "name-desc"},
				new SelectListItem {Text = "Kategori (grupperet)", Value = "category"}
			};
		}


		public void UpdateView(string title, string actionMethod, string buttonTitle)
		{
			Title = title;
			ActionMethod = actionMethod;
			ButtonTitle = buttonTitle;
		}

	}
}