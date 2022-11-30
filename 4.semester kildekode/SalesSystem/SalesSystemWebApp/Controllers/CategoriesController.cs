using DataTransferObjects.Models;
using SalesSystemWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesSystemWebApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoriesViewModel viewModel;

        public CategoriesController()
        {
            viewModel = new CategoriesViewModel();
        }


        // GET: Categories
        public ActionResult Index()
        {
        

            return View("Index", viewModel);
        }


        [HttpGet]

        public ActionResult Create()
        {
            ViewBag.Title = "Opret Kategori";
            ViewBag.ACTIONMETHOD = "Create";
            ViewBag.ButtonTitle = "Opret";
            return View("Form", viewModel);
        }


        [HttpPost]
        public ActionResult Create(CategoryDto Category)
        {
            if (!ModelState.IsValid)
            {
             return  RedirectToAction("Create", viewModel);
            }


            viewModel.categoryController.CreateCategory(Category.Name);

            return RedirectToAction("Index");   
        }

        [HttpGet]
        public ActionResult Update(Guid id)
        {
            viewModel.Category = viewModel.categoryController.GetCategory(id);

            ViewBag.Title = $"Opdatere Kategori";
            ViewBag.ACTIONMETHOD = "UPDATE";
            ViewBag.ButtonTitle = "Opdatere";

            return View("Form",viewModel);
        }

        [HttpPost]
        public ActionResult Update(Guid id, CategoryDto category)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Update");
            }

            viewModel.categoryController.UpdateCategory(id, category.Name);

            return RedirectToAction("Index");
        }


        public ActionResult Delete(Guid id)
        {
           bool deleted =  viewModel.categoryController.DeleteCategory(id);

            if (!deleted)
            {
                viewModel.ErrorMessage = "Du skal slette produkterne i den valgte kategori før du kan slette kategorien";
                return View("Index", viewModel);
            }
            return RedirectToAction("Index");
        }

       
    }
}