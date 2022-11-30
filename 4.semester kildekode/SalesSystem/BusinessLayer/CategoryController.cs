using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using DataTransferObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CategoryController
    {

        private static CategoryController instance;

        private readonly CategoryRepository repository;

        private CategoryController()
        {
            repository = new CategoryRepository();
        }

        public static CategoryController GetController()
        {
            if(instance == null)
            {
                instance = new CategoryController();
            }

            return instance;
        }

        public void CreateCategory(string name)
        {
            Category category = new Category(name);
            repository.InsertEntity(category);
        }

        public void UpdateCategory(Guid id, string name)
        {
            repository.UpdateEntity(new Category { CategoryId = id, Name = name });
        }

        public bool DeleteCategory(Guid id)
        {
           return repository.DeleteEntity(id);
        }

        public CategoryDto GetCategory(Guid id)
        {
            return repository.GetEntityById(id);
        }

        public CategoryDetailDto GetCategoryDetails(Guid id)
        {
            return repository.GetEntityDetailsById(id);
        }

        public List<CategoryDto> GetCategories()
        {
            return repository.GetEntities().ToList();
        }

    }
}
