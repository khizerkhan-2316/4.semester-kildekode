using DataAccessLayer.Context;
using DataAccessLayer.Mappers;
using DataAccessLayer.Model;
using DataTransferObjects;
using DataTransferObjects.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
	public class ProductRespository
	{

		private readonly ProductMapper _mapper;


		public ProductRespository()
		{
			_mapper = new ProductMapper();
		}


		public void InsertEntity(ProductDetailDto product)
		{
			using (DatabaseContext context = new DatabaseContext())
			{
				Product entity = _mapper.MapDtoDetailToEntity(product);

				context.Products.Add(entity);
				context.Categories.Attach(entity.Category);

				if (entity.Picture.Title == "Placeholder")
				{
					context.Pictures.Attach(entity.Picture);
				}

				context.SaveChanges();
			}

		}

		public ProductDto GetEntityById(Guid id)
		{
			using (DatabaseContext context = new DatabaseContext())
				return _mapper.MapEntityToDto(context.Products.Find(id));
		}

		public List<ProductDto> GetEntities()
		{
			using (DatabaseContext context = new DatabaseContext())
				return _mapper.MapEntitiesToDtos(context.Products.OrderBy(p => p.Name));
		}

		public ProductDetailDto GetEntityDetailsById(Guid id)
		{
			using (DatabaseContext context = new DatabaseContext())
				return _mapper.MapEntityToDtoDetail(context.Products.Find(id));
		}

		public List<ProductDetailDto> GetEntitiesDetails()
		{
			using (DatabaseContext context = new DatabaseContext())
				return _mapper.MapEntitesToDetailDtos(context.Products.OrderBy(p => p.Name).ToList());

		}


		public void UpdateEntity(ProductDetailDto product)
		{
			using (DatabaseContext context = new DatabaseContext())
			{

				Product entity = _mapper.MapDtoDetailToEntity(product);
				Product productFromDb = context.Products.Find(product.ProductId);

				productFromDb.Category = entity.Category;
				productFromDb.Picture = entity.Picture;

				context.Entry(productFromDb).CurrentValues.SetValues(entity);
				context.Categories.Attach(entity.Category);

				if (product.Picture.Title == "Placeholder")
				{
					context.Pictures.Attach(entity.Picture);
				}



				context.SaveChanges();

			}
		}

		public bool DeleteEntity(Guid id)
		{
			using (DatabaseContext context = new DatabaseContext())
			{
				Product product = context.Products.Where(p => p.ProductId == id).Include(p => p.Picture).First();

				if (product.Picture.Title != "Placeholder")
				{
					context.Pictures.Remove(product.Picture);
				}

				context.Products.Remove(product);
				context.SaveChanges();
				return true;
			}



		}


		public List<ProductDetailDto> GenericSearchMethod(Expression<Func<Product, bool>> predicate)
		{
			using (DatabaseContext context = new DatabaseContext())
			{
				return _mapper.MapEntitesToDetailDtos(context.Products.Where(predicate).ToList());

			}
		}

	}
}
