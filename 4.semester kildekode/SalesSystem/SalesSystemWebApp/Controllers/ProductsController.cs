using DataTransferObjects.Models;
using SalesSystemWebApp.ViewModels;
using System;
using System.Web.Mvc;

namespace SalesSystemWebApp.Controllers
{

	[HandleError]
	public class ProductsController : Controller
	{

		private readonly ProductsViewModel viewModel;

		public ProductsController()
		{
			viewModel = new ProductsViewModel();
		}

		// GET: Products
		public ActionResult Index()
		{

			return View(viewModel);
		}




		[HttpGet]
		public ActionResult Create()
		{
			viewModel.UpdateView("Opret Produkt", "Create", "Opret");

			return View("Form", viewModel);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(ProductDetailDto Product)
		{

			if (!ModelState.IsValid)
			{
				viewModel.UpdateView("Opret Produkt", "Create", "Opret");
				return View("Form", viewModel);
			}

			HandlePicture(Product);

			Product.ProductId = Guid.NewGuid();
			viewModel.productController.CreateProduct(Product);


			ModelState.Clear();
			return RedirectToAction("Index");
		}


		[HttpGet]
		public ActionResult Update(Guid id)
		{
			viewModel.Product = viewModel.productController.GetProductDetails(id);
			viewModel.UpdateView("Opdatere produkt", "Update", "Opdatere");

			return View("Form", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Update(Guid id, ProductDetailDto Product)
		{
			if (!ModelState.IsValid)
			{

				viewModel.UpdateView("Opdatere produkt", "Update", "Opdatere");

				return View("Form", viewModel);
			}


			HandlePicture(Product);
			Product.ProductId = id;

			viewModel.productController.UpdateProduct(Product);

			return RedirectToAction("Index");
		}

		public ActionResult Delete(Guid ProductId)
		{
			ProductDetailDto product = viewModel.productController.GetProductDetails(ProductId);

			if (product.Picture.Title != "Placeholder")
			{
				if (System.IO.File.Exists(Server.MapPath(product.Picture.ImagePath)))
				{
					System.IO.File.Delete(Server.MapPath(product.Picture.ImagePath));
				}
			}
			viewModel.productController.DeleteProduct(ProductId);
			return RedirectToAction("Index");
		}



		[HttpGet]
#nullable enable
		public ActionResult Search(string? Query, Guid? CategoryId, string? Sort)
		{


			if (!String.IsNullOrEmpty(Query))
			{

				if ((CategoryId != null && CategoryId != Guid.Empty) && !String.IsNullOrEmpty(Sort))
				{
					viewModel.Products = viewModel.productController.GetProductsBySearchAndFilterAndSort(Query, (Guid)CategoryId, Sort);
					return View("Index", viewModel);

				}

				if (CategoryId != null && !(CategoryId == Guid.Empty))
				{

					viewModel.Products = viewModel.productController.GetProductsBySearchAndCategory((Guid)CategoryId, Query);
					return View("Index", viewModel);

				}

				if (!string.IsNullOrEmpty(Sort))
				{
					viewModel.Products = viewModel.productController.GetProductsBySearchAndSort(Query, Sort);
					return View("Index", viewModel);
				}

				viewModel.Products = viewModel.productController.GetProductsBySearch(Query);

				return View("Index", viewModel);
			}


			if (CategoryId != null && !(CategoryId == Guid.Empty))
			{

				if (!String.IsNullOrEmpty(Sort))
				{
					viewModel.Products = viewModel.productController.GetProductsByCategoryAndSort((Guid)CategoryId, Sort);
					return View("Index", viewModel);
				}

				viewModel.Products = viewModel.productController.GetProductsDetailsFromCategoryId((Guid)CategoryId);
				return View("Index", viewModel);

			}


			if (!String.IsNullOrEmpty(Sort))
			{
				viewModel.Products = viewModel.productController.GetProductsBySort(Sort);
				return View("Index", viewModel);
			}

			return RedirectToAction("Index");
		}

#nullable disable


		private void HandlePicture(ProductDetailDto Product)
		{
			if (Product.Picture.ImageFile == null)
			{
				PictureDto defaultPicture = viewModel.pictureController.GetDefaultImage();
				Product.Picture = defaultPicture;
			}
			else
			{

				Product.Picture = viewModel.pictureController.ModifyPicture(Product.Picture);
				Product.Picture.ImageFile.SaveAs(Server.MapPath(Product.Picture.ImagePath));
			}
		}
	}
}