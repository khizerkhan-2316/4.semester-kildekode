using DataAccessLayer.Repositories;
using DataTransferObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
	public class CategoryBLL
	{

		private static CategoryBLL instance;

		private readonly CategoryRepository repository;

		private CategoryBLL()
		{
			repository = new CategoryRepository();
		}

		public static CategoryBLL GetController()
		{
			if (instance == null)
			{
				instance = new CategoryBLL();
			}

			return instance;
		}

		public void CreateCategory(CategoryDto category)
		{

			repository.InsertEntity(category);
		}

		public CategoryDto GetCategory(Guid id)
		{
			return repository.GetEntityById(id);
		}

		public List<CategoryDto> GetCategories()
		{
			return repository.GetEntities().ToList();
		}

		public CategoryDetailDto GetCategoryDetails(Guid id)
		{
			return repository.GetEntityDetailsById(id);
		}


		public void UpdateCategory(CategoryDto category)
		{
			repository.UpdateEntity(category);
		}

		public bool DeleteCategory(Guid id)
		{
			return repository.DeleteEntity(id);
		}



	}
}
