using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using DataTransferObjects;
using DataTransferObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ProductController
    {

        private static ProductController productController;
        private readonly ProductRespository repository;


        private ProductController()
        {
            repository = new ProductRespository();
        }

        public static ProductController GetController()
        {
            if(productController == null)
            {
                productController = new ProductController();
            }

            return productController;
        }

        public void CreateProduct(string name, string description, double price, double? salePrice, CategoryDto category)
        {
            Product product = new Product(name, description, price, salePrice)
            {
                Category = new Category { Name = category.Name, CategoryId = category.CategoryId }
            };
            repository.InsertEntity(product);
        }


		public void CreateProductWithPicture(string name, string description, double price, double? salePrice, CategoryDto category, PictureDto picture)
		{


			Product product = new Product(name, description, price, salePrice)
			{
				Category = new Category { Name = category.Name, CategoryId = category.CategoryId },
				Picture = new Picture { PictureId = picture.Title == "Placeholder"? picture.PictureId : Guid.NewGuid(), Title = picture.Title, ImageFile = picture.ImageFile, ImagePath = picture.ImagePath }

			};
			repository.InsertEntity(product);
		}
		public void UpdateProduct(Guid id, string name, string description, double price, double? salePrice, CategoryDto category)
        {
           Category updatedCategory = new Category { Name = category.Name, CategoryId = category.CategoryId };
            repository.UpdateEntity(new Product { ProductId = id, Name = name, Description = description, Price = price, SalePrice = salePrice, Category = updatedCategory });
        }

		public void UpdateProductWithPicture(Guid id, string name, string description, double price, double? salePrice, CategoryDto category, PictureDto picture)
		{
			Category updatedCategory = new Category { Name = category.Name, CategoryId = category.CategoryId };
			repository.UpdateEntity(new Product { ProductId = id, Name = name, Description = description, Price = price, SalePrice = salePrice, Category = updatedCategory,
			Picture = new Picture { PictureId = picture.Title == "Placeholder" ? picture.PictureId : Guid.NewGuid(), Title = picture.Title, ImageFile = picture.ImageFile, ImagePath = picture.ImagePath }
			});
		}

		public void DeleteProduct(Guid id)
        {
            repository.DeleteEntity(id);
        }

        public ProductDto GetProduct(Guid id)
        {

            return repository.GetEntityById(id);
        }

        public ProductDetailDto GetProductDetails(Guid id)
        {
            return repository.GetEntityDetailsById(id);
        }

        public List<ProductDetailDto> GetProductsDetailsFromCategoryId(Guid categoryId)
        {
            return repository.GetProductsDetailsByCategoryId(categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductsDetails()
        {
            return repository.GetEntitiesDetails();
        }

        public List<ProductDto> GetProducts()
        {
            return repository.GetEntities().ToList();
        }

        public List<ProductDetailDto> GetProductsBySearch(string query)
        {
            return repository.GetEntitiesBySearch(query);
        }

        public List<ProductDetailDto> GetProductsByCateogryId(Guid CategoryId)
        {
            return repository.GetEntitiesByCategory(CategoryId);
        }


        public List<ProductDetailDto> GetProductsBySort(string sortOption)
        {
            return repository.GetEntitiesBySort(sortOption);
        }


        public List<ProductDetailDto> GetProductsBySearchAndCategory(Guid CategoryId, string query)
        {
            return repository.GetEntitiesBySearchAndCategory(CategoryId, query);
        }

        public List<ProductDetailDto> GetProductsBySearchAndSort(string query, string sortOption)
        {
            return repository.GetEntitiesBySearchAndSort(query, sortOption);
        }

        public List<ProductDetailDto> GetProductsByCategoryAndSort(Guid categoryId, string sortOption)
        {
            return repository.GetEntitiesByCategoryAndSort((Guid)categoryId, sortOption);
        }




        public List<ProductDetailDto> GetProductsBySearchAndFilterAndSort(string query, Guid categoryId, string sortOption)
        {
            return repository.GetEntitiesBySearchFilterAndSort(query, categoryId, sortOption);
        }


    }
}
