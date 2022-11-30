using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Model;
using SalesSystemWebApp.ViewModels;
using DataTransferObjects.Models;
using System.Net.NetworkInformation;
using System.IO;

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
        #nullable enable
        public ActionResult Search(string? Query, Guid? CategoryId, string? Sort)
        {


            if(!String.IsNullOrEmpty(Query))
            {
               
                if((CategoryId != null && CategoryId != Guid.Empty) && !String.IsNullOrEmpty(Sort))
                {
                    viewModel.Products =  viewModel.productController.GetProductsBySearchAndFilterAndSort(Query, (Guid)CategoryId, Sort);
                    return View("Index", viewModel);

                }

                if (CategoryId != null && !(CategoryId == Guid.Empty))
                {

                    viewModel.Products = viewModel.productController.GetProductsBySearchAndCategory((Guid) CategoryId, Query);
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

                viewModel.Products = viewModel.productController.GetProductsByCateogryId((Guid)CategoryId);
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

 

        [HttpGet]
        public ActionResult Update(Guid id)
        {
            viewModel.Product = viewModel.productController.GetProductDetails(id);
            ViewBag.Title = $"Opdatere produkt: {viewModel.Product.Name}";
            ViewBag.ButtonTitle = "Opdatere";
            ViewBag.ACTIONMETHOD = "Update";


            return View("Form", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Guid id, ProductDetailDto Product)
        {
            if (!ModelState.IsValid)
            {

                ViewBag.Title = $"Opdatere produkt: {viewModel.Product.Name}";
                ViewBag.ButtonTitle = "Opdatere";
                ViewBag.ACTIONMETHOD = "Update";
                return View("Form", viewModel);
            }


			if (Product.Picture.ImageFile == null)
			{
				PictureDto defaultPicture = viewModel.pictureController.GetDefaultImage();
				Product.Picture = defaultPicture;
			}
			else
			{

				string path = viewModel.pictureController.GetImagePath(Product.Picture);
				Product.Picture.ImagePath = $"~/Images/{path}";
				Product.Picture.Title = viewModel.pictureController.GetImageTitle(Product.Picture);
				path = Path.Combine(Server.MapPath("~/Images/"), path);
				Product.Picture.ImageFile.SaveAs(path);
			}


			viewModel.productController.UpdateProductWithPicture(id, Product.Name, Product.Description, Product.Price, Product.SalePrice, new CategoryDto { CategoryId = Product.Category.CategoryId }, Product.Picture);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Title = "Opret produkt";
            ViewBag.ButtonTitle = "Opret";
            ViewBag.ACTIONMETHOD = "Create";

            return View("Form",viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductDetailDto Product)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Title = "Opret produkt";
                ViewBag.ButtonTitle = "Opret";
                ViewBag.ACTIONMETHOD = "Create";
                return View("Form", viewModel);
            }

            if(Product.Picture.ImageFile == null)
            {
                PictureDto defaultPicture = viewModel.pictureController.GetDefaultImage();
                Product.Picture = defaultPicture;
            }
            else
            {

				string path = viewModel.pictureController.GetImagePath(Product.Picture);
				Product.Picture.ImagePath = $"~/Images/{path}";
                Product.Picture.Title = viewModel.pictureController.GetImageTitle(Product.Picture);
				path = Path.Combine(Server.MapPath("~/Images/"), path);
				Product.Picture.ImageFile.SaveAs(path);
            	}

           


            CategoryDto category = viewModel.categoryController.GetCategory(Product.Category.CategoryId);
            viewModel.productController.CreateProductWithPicture(Product.Name, Product.Description, Product.Price, Product.SalePrice, category, Product.Picture);

            ModelState.Clear();
            return RedirectToAction("Index");
        }

   

        public ActionResult Delete(Guid ProductId)
        {
            ProductDetailDto product = viewModel.productController.GetProductDetails(ProductId);

            if(product.Picture.Title != "Placeholder")
            {
                if (System.IO.File.Exists(Server.MapPath(product.Picture.ImagePath)))
                {
                    System.IO.File.Delete(Server.MapPath(product.Picture.ImagePath));
                }
			}
			viewModel.productController.DeleteProduct(ProductId);
            return RedirectToAction("Index");
        }
    }
}