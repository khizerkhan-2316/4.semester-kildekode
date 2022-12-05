using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using DataAccessLayer.Repositories.ProductRepository;
using System.Runtime.Remoting.Contexts;
using DataTransferObjects;
using DataAccessLayer.Mappers;
using DataTransferObjects.Models;
using System.Data.Entity.Infrastructure;
using System.Collections;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
	public class ProductRespository : IDisposable
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
				Save(context);
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


		public void Save(DatabaseContext context)
		{

			context.SaveChanges();

		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing, DatabaseContext context)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			using (DatabaseContext context = new DatabaseContext())
			{

				Dispose(true, context);
				GC.SuppressFinalize(this);
			}
		}

	}
}
