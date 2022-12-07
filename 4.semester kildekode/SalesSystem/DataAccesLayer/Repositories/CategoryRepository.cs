using DataAccessLayer.Context;
using DataAccessLayer.Mappers;
using DataAccessLayer.Model;
using DataTransferObjects.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DataAccessLayer.Repositories
{
	public class CategoryRepository
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


	}
}
