using DataAccessLayer.Context;
using DataAccessLayer.Mappers;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories.ProductRepository;
using DataTransferObjects.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CategoryRepository : IRepository<CategoryDto, Category>, IDisposable
    {
        private readonly CategoryMapper _mapper;

        public CategoryRepository()
        {
            _mapper = new CategoryMapper(); 
        }

        public CategoryDto GetEntityById(Guid id)
        {
            using (DatabaseContext context = new DatabaseContext())
                return _mapper.Map(context.Categories.Find(id));
        }

        public CategoryDetailDto GetEntityDetailsById(Guid id)
        {
            using (DatabaseContext context = new DatabaseContext())
                return _mapper.MapCategoryDetails(context.Categories.Find(id));
        }

        public IEnumerable<CategoryDto> GetEntities()
        {
            using (DatabaseContext context = new DatabaseContext())
                return _mapper.Map(context.Categories.OrderBy(c => c.Name));
        }

        public void InsertEntity(Category category)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }

        }

        public bool DeleteEntity(Guid id)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                List<Product> products = context.Products.Where((Product product) => product.Category.CategoryId == id).ToList();

                if(products.Count > 0)
                {
                    return false;
                }

                products.ForEach((Product product) => product.Category = null);
                Category category = context.Categories.Find(id);
                context.Categories.Remove(category);
                Save(context);

                return true;
            }



        }

        public void UpdateEntity(Category category)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                context.Categories.AddOrUpdate(category);
                context.SaveChanges();

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
