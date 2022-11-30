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

namespace DataAccessLayer.Repositories
{
    public class ProductRespository : IRepository<ProductDto, Product>, IDisposable
    {

        private readonly ProductMapper _mapper;


        public ProductRespository()
        {
            _mapper = new ProductMapper();
        }

        public ProductDto GetEntityById(Guid id)
        {
            using (DatabaseContext context = new DatabaseContext())
                return _mapper.Map(context.Products.Find(id));
        }

        public ProductDetailDto GetEntityDetailsById(Guid id)
        {
            using (DatabaseContext context = new DatabaseContext())
                return _mapper.MapProductDetails(context.Products.Find(id));
        }

        
        public List<ProductDetailDto> GetEntitiesDetails()
        {
            using (DatabaseContext context = new DatabaseContext())
                return context.Products.OrderBy(p => p.Name).ToList().ConvertAll<ProductDetailDto>((Product product) =>
                {
                    return _mapper.MapProductDetails(product);
                });
        }

        public IEnumerable<ProductDto> GetEntities()
        {
            using (DatabaseContext context = new DatabaseContext())
                return _mapper.Map(context.Products.OrderBy(p => p.Name));
        }

       public IEnumerable<ProductDetailDto> GetProductsDetailsByCategoryId(Guid categoryId)
        {
            using (DatabaseContext context = new DatabaseContext())
                return context.Products.Where(p => p.Category.CategoryId == categoryId).ToList().ConvertAll<ProductDetailDto>((Product product) =>
                {
                    return _mapper.MapProductDetails(product);
                });
        }

        public void InsertEntity(Product product)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                
               context.Products.Add(product);
               context.Categories.Attach(product.Category);

                if(product.Picture.Title == "Placeholder")
                {
                    context.Pictures.Attach(product.Picture);
                }

               context.SaveChanges();
            }
                
        }

        public bool DeleteEntity(Guid id)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                Product product = context.Products.Where(p => p.ProductId == id).Include(p => p.Picture).First();   

                if(product.Picture.Title != "Placeholder")
                {
                    context.Pictures.Remove(product.Picture);
                }

                context.Products.Remove(product);
                Save(context);
                return true;
            }



        }

        public void UpdateEntity(Product product)
        {
            using (DatabaseContext context = new DatabaseContext())
            {

                Product productFromDb = context.Products.Find(product.ProductId);
				productFromDb.Category = product.Category;
                productFromDb.Picture = product.Picture;


				context.Entry(productFromDb).CurrentValues.SetValues(product);
				context.Categories.Attach(product.Category);

				if (product.Picture.Title == "Placeholder")
				{
					context.Pictures.Attach(product.Picture);
				}



				context.SaveChanges();
                
            }
        }

        public List<ProductDetailDto> GetEntitiesBySearch(string query)
        {
            using (DatabaseContext context = new DatabaseContext())
              return context.Products.Where((Product product) => product.Name.ToLower().Contains(query.ToLower())).ToList().ConvertAll<ProductDetailDto>((Product product) =>
                {
                    return _mapper.MapProductDetails(product);
                });
        }

        public List<ProductDetailDto> GetEntitiesBySearchAndCategory(Guid CategoryId, string query)
        {
            using (DatabaseContext context = new DatabaseContext())
                return context.Products.Where((Product product) => product.Name.ToLower().Contains(query.ToLower()) && product.Category.CategoryId == CategoryId).ToList().ConvertAll<ProductDetailDto>((Product product) =>
                {
                    return _mapper.MapProductDetails(product);
                });
        }

        public List<ProductDetailDto> GetEntitiesByCategoryAndSort(Guid categoryId, string sortOption)
        {
            using (DatabaseContext context = new DatabaseContext())
                return GetSortedProducts(context.Products.Where(p => p.Category.CategoryId == categoryId).ToList(), sortOption).ConvertAll<ProductDetailDto>((Product product) =>
                {
                    return _mapper.MapProductDetails(product);
                });
        }


        public List<ProductDetailDto> GetEntitiesBySearchAndSort(string query, string sortOption)
        {
            using (DatabaseContext context = new DatabaseContext())
                return GetSortedProducts(context.Products.Where((Product product) => product.Name.ToLower().Contains(query.ToLower())).ToList(), sortOption).ConvertAll<ProductDetailDto>((Product product) =>
                {
                    return _mapper.MapProductDetails(product);
                });



        }


        public List<ProductDetailDto> GetEntitiesByCategory(Guid id)
        {
            using (DatabaseContext context = new DatabaseContext())
                return context.Products.Where((Product product) => product.Category.CategoryId == id).ToList().ConvertAll<ProductDetailDto>((Product product) =>
                {
                    return _mapper.MapProductDetails(product);
                });
        }

        public List<ProductDetailDto> GetEntitiesBySearchFilterAndSort(string query, Guid categoryId, string sortOption)
        {
            using (DatabaseContext context = new DatabaseContext())
                return GetSortedProducts(context.Products.Where((Product product) => product.Name.ToLower().Contains(query.ToLower()) && product.Category.CategoryId == categoryId).ToList(), sortOption).ConvertAll<ProductDetailDto>((Product product) =>
                {
                    return _mapper.MapProductDetails(product);
                });
        }

        public List<ProductDetailDto> GetEntitiesBySort(string sortOption)
        {
            using (DatabaseContext context = new DatabaseContext())
                return GetSortedProducts(context.Products.ToList(), sortOption).ConvertAll<ProductDetailDto>((Product product) =>
                {
                    return _mapper.MapProductDetails(product);
                });
        }

        private List<Product> GetSortedProducts(List<Product> products, string sortOption)
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
            using (DatabaseContext context = new DatabaseContext()) {

                Dispose(true, context);
                GC.SuppressFinalize(this);
            }
        }

    }
}
