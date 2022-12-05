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
		private readonly CategoriesViewModel _viewModel;

		public CategoriesController()
		{
			_viewModel = new CategoriesViewModel();
		}


		// GET: Categories
		public ActionResult Index()
		{
			return View("Index", _viewModel);
		}


		[HttpGet]

		public ActionResult Create()
		{

			_viewModel.UpdateView("Opret Kategori", "Create", "Opret");
			return View("Form", _viewModel);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(CategoryDto Category)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("Create", _viewModel);
			}

			Category.CategoryId = Guid.NewGuid();
			_viewModel.categoryController.CreateCategory(Category);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Update(Guid id)
		{
			_viewModel.Category = _viewModel.categoryController.GetCategory(id);
			_viewModel.UpdateView("Opdatere Kategori", "Update", "Opdatere");

			return View("Form", _viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Update(Guid id, CategoryDto category)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("Update");
			}

			category.CategoryId = id;
			_viewModel.categoryController.UpdateCategory(category);

			return RedirectToAction("Index");
		}


		public ActionResult Delete(Guid id)
		{
			bool deleted = _viewModel.categoryController.DeleteCategory(id);

			if (!deleted)
			{
				_viewModel.ErrorMessage = "Du skal slette produkterne i den valgte kategori før du kan slette kategorien";
				return View("Index", _viewModel);
			}
			return RedirectToAction("Index");
		}


	}
}