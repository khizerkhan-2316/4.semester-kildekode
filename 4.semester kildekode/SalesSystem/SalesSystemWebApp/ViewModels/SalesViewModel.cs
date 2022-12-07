using BusinessLayer;
using DataTransferObjects.Models;
using System;
using System.Collections.Generic;

namespace SalesSystemWebApp.ViewModels
{
	public class SalesViewModel
	{

		public CategoryBLL categoryController = CategoryBLL.GetController();
		public SaleBLL saleController = SaleBLL.GetController();
		public ProductBLL productController = ProductBLL.GetController();

		public SaleDetailDto Sale { get; set; }

		public SaleDetailDto SaleDetails { get; set; }

		public List<SaleDto> Sales { get; set; }

		public List<CategoryDto> Categories { get; set; }

		public CategoryDto Category { get; set; }

		public Guid CategoryId { get; set; }

		public List<ProductDetailDto> Products { get; set; }

		public SalesViewModel()
		{
			Sale = new SaleDetailDto();
			Sales = saleController.GetSales();
			SaleDetails = new SaleDetailDto();
			Categories = categoryController.GetCategories();
			Category = new CategoryDto();
			Products = productController.GetProductsDetails();

		}
	}
}