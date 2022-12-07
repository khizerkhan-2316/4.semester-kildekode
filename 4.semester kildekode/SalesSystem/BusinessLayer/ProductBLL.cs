using DataAccessLayer.Repositories;
using DataTransferObjects;
using DataTransferObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
	public class ProductBLL
	{

		private static ProductBLL productController;
		private readonly ProductRespository repository;


		private ProductBLL()
		{
			repository = new ProductRespository();
		}

		public static ProductBLL GetController()
		{
			if (productController == null)
			{
				productController = new ProductBLL();
			}

			return productController;
		}

		public void CreateProduct(ProductDetailDto product)
		{
			repository.InsertEntity(product);
		}

		public ProductDto GetProduct(Guid id)
		{

			return repository.GetEntityById(id);
		}

		public List<ProductDto> GetProducts()
		{
			return repository.GetEntities().ToList();
		}

		public ProductDetailDto GetProductDetails(Guid id)
		{
			return repository.GetEntityDetailsById(id);
		}

		public List<ProductDetailDto> GetProductsDetails()
		{
			return repository.GetEntitiesDetails();
		}


		public void UpdateProduct(ProductDetailDto product)
		{
			repository.UpdateEntity(product);
		}


		public void DeleteProduct(Guid id)
		{
			repository.DeleteEntity(id);
		}

		public List<ProductDetailDto> GetProductsBySearch(string query)
		{
			return repository.GenericSearchMethod(p => p.Name.Contains(query));
		}

		public List<ProductDetailDto> GetProductsBySearchAndCategory(Guid CategoryId, string query)
		{
			return repository.GenericSearchMethod(p => p.Name.Contains(query) && p.Category.CategoryId == CategoryId);
		}


		public List<ProductDetailDto> GetProductsBySearchAndSort(string query, string sortOption)
		{
			return GetSortedProducts(repository.GenericSearchMethod(p => p.Name.Contains(query)), sortOption);
		}

		public List<ProductDetailDto> GetProductsBySearchAndFilterAndSort(string query, Guid categoryId, string sortOption)
		{
			return GetSortedProducts(GetProductsBySearchAndCategory(categoryId, query), sortOption);
		}


		public List<ProductDetailDto> GetProductsDetailsFromCategoryId(Guid categoryId)
		{
			return repository.GenericSearchMethod(p => p.Category.CategoryId == categoryId);
		}


		public List<ProductDetailDto> GetProductsByCategoryAndSort(Guid categoryId, string sortOption)
		{
			return GetSortedProducts(GetProductsDetailsFromCategoryId(categoryId), sortOption);
		}


		public List<ProductDetailDto> GetProductsBySort(string sortOption)
		{
			return GetSortedProducts(repository.GetEntitiesDetails(), sortOption);
		}


		private List<ProductDetailDto> GetSortedProducts(List<ProductDetailDto> products, string sortOption)
		{

			switch (sortOption)
			{
				case "price":
					return products.OrderBy(p => p.Price).ToList();

				case "price-desc":
					return products.OrderByDescending(p => p.Price).ToList();
				case "name":
					return products.OrderBy(p => p.Name).ToList();
				case "name-desc":
					return products.OrderByDescending(p => p.Name).ToList();
				case "category":
					return products.OrderBy(p => p.Category.Name).ToList();

				default:
					return products;
			}
		}





	}
}
