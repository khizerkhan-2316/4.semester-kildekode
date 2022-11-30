using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Model;
using DataTransferObjects;
using DataTransferObjects.Models;

namespace DataAccessLayer.Mappers
{
    public class CategoryMapper
    {

        public CategoryDto Map(Category category)
        {
            return new CategoryDto
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
            };
        }

        public IEnumerable<CategoryDto> Map(IEnumerable<Category> categories)
        {
            IEnumerable<CategoryDto> list = categories.ToList().ConvertAll<CategoryDto>((Category category) =>
            {
                return new CategoryDto { CategoryId = category.CategoryId, Name = category.Name};
            });

            return list;
        }

        public CategoryDetailDto MapCategoryDetails(Category category)
        {
            return new CategoryDetailDto
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Products = category.Products.ConvertAll<ProductDto>((Product product) =>
                {
                    return new ProductDto { ProductId = product.ProductId, Name = product.Name };
                })
            };
        }

    }
}
