using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Model;
using DataTransferObjects.Models;

namespace DataAccessLayer.Mappers
{
    public class ProductMapper
    {

        public ProductDto Map(Product product)
        {
            return new ProductDto
            {
                ProductId = product.ProductId,
                Name = product.Name
        };
        }

        public IEnumerable<ProductDto> Map(IEnumerable<Product> products)
        {
            IEnumerable<ProductDto> list = products.ToList().ConvertAll<ProductDto>((Product product) =>
            {
                return new ProductDto { ProductId = product.ProductId, Name = product.Name };
            });

            return list;
        }

        public ProductDetailDto MapProductDetails(Product product)
        {
            return new ProductDetailDto
            {
                ProductId = product.ProductId,
                Name = product.Name,   
                Description = product.Description,
                Price = product.Price,
                SalePrice = product.SalePrice,
                Category = new CategoryDto { CategoryId = product.Category.CategoryId, Name = product.Category.Name },
                Picture = new PictureDto { PictureId = product.Picture.PictureId, Title = product.Picture.Title, ImagePath = product.Picture.ImagePath, ImageFile = product.Picture.ImageFile}

            };
        }
    }



 
}






