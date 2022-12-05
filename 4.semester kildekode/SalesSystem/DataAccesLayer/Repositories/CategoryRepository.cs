using DataAccessLayer.Context;
using DataAccessLayer.Mappers;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories.ProductRepository;
using DataTransferObjects.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
	public class CategoryRepository : IDisposable
	{
		private readonly CategoryMapper _mapper;

		public CategoryRepository()
		{
			_mapper = new CategoryMapper();
		}

		public void InsertEntity(CategoryDto category)
		{
			using (DatabaseContext context = new DatabaseContext())
			{
				context.Categories.Add(_mapper.MapDtoToEntity(category));
				context.SaveChanges();
			}
		}

		public CategoryDto GetEntityById(Guid id)
		{
			using (DatabaseContext context = new DatabaseContext())
				return _mapper.MapEntityToDto(context.Categories.Find(id));
		}

		public IEnumerable<CategoryDto> GetEntities()
		{
			using (DatabaseContext context = new DatabaseContext())
				return _mapper.MapEntityListToDto(context.Categories.OrderBy(c => c.Name));
		}


		public CategoryDetailDto GetEntityDetailsById(Guid id)
		{
			using (DatabaseContext context = new DatabaseContext())
				return _mapper.MapEntityToDtoDetails(context.Categories.Find(id));
		}

		public void UpdateEntity(CategoryDto category)
		{
			using (DatabaseContext context = new DatabaseContext())
			{

				context.Categories.AddOrUpdate(_mapper.MapDtoToEntity(category));
				context.SaveChanges();

			}
		}

		public bool DeleteEntity(Guid id)
		{
			using (DatabaseContext context = new DatabaseContext())
			{
				Category category = context.Categories.Where(c => c.CategoryId == id).Include(c => c.Products).First();

				if (category.Products.Count > 0)
				{
					return false;
				}

				category.Products.ForEach((Product product) => product.Category = null);
				context.Categories.Remove(category);
				context.SaveChanges();

				return true;
			}



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
