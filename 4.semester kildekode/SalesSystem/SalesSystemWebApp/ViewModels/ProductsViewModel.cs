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
        public readonly ProductController productController = ProductController.GetController();
        public readonly CategoryController categoryController = CategoryController.GetController();
        public readonly PictureController pictureController = PictureController.GetController();

        public List<ProductDetailDto> Products { get; set; }

        public List<CategoryDto> Categories { get; set; }

        //dette er en ProductDetailDto med propeties:

        public ProductDetailDto Product { get; set; }

        public CategoryDto Category { get; set; }


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

       





      



    }
}