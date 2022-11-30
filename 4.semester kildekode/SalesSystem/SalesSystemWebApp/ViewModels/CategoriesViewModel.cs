using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLayer;
using DataTransferObjects.Models;

namespace SalesSystemWebApp.ViewModels
{
    public class CategoriesViewModel
    {

        public readonly CategoryController categoryController = CategoryController.GetController();

        public List<CategoryDto> Categories { get; }

        public CategoryDto Category { get; set; }   

        public string ErrorMessage { get; set; }


        public CategoriesViewModel()
        {
            Categories = categoryController.GetCategories();    
            Category = new CategoryDto();
            ErrorMessage = "";
        }



    }
}