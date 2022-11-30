using BusinessLayer;
using DataTransferObjects.Models;
using SalesSystemWebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace SalesSystemWebApp.ViewModels
{
    public class SalesViewModel
    {

        public CategoryController categoryController = CategoryController.GetController();
        public SaleController saleController = SaleController.GetController();
        public ProductController productController = ProductController.GetController();

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