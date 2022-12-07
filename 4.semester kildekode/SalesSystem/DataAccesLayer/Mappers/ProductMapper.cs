using DataAccessLayer.Model;
using DataTransferObjects;
using DataTransferObjects.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Mappers
{
	public class ProductMapper
	{



		public ProductDto MapEntityToDto(Product product)
		{
			return new ProductDto
			{
				ProductId = product.ProductId,
				Name = product.Name
			};
		}

		public Product MapDtoDetailToEntity(ProductDetailDto product)
		{
			return new Product
			{
				ProductId = product.ProductId,
				Name = product.Name,
				Description = product.Description,
				Price = product.Price,
				SalePrice = product.SalePrice,
				Category = new Category { CategoryId = product.Category.CategoryId, Name = product.Category.Name },
				Picture = new Picture { PictureId = product.Picture.PictureId, Title = product.Picture.Title, ImagePath = product.Picture.ImagePath, ImageFile = product.Picture.ImageFile },

			};
		}



		public List<ProductDto> MapEntitiesToDtos(IEnumerable<Product> products)
		{
			return products.ToList().ConvertAll<ProductDto>((Product product) =>
			{
				return new ProductDto { ProductId = product.ProductId, Name = product.Name };
			});

		}

		public ProductDetailDto MapEntityToDtoDetail(Product product)
		{
			return new ProductDetailDto
			{
				ProductId = product.ProductId,
				Name = product.Name,
				Description = product.Description,
				Price = product.Price,
				SalePrice = product.SalePrice,
				Category = new CategoryDto { CategoryId = product.Category.CategoryId, Name = product.Category.Name },
				Picture = new PictureDto { PictureId = product.Picture.PictureId, Title = product.Picture.Title, ImagePath = product.Picture.ImagePath, ImageFile = product.Picture.ImageFile }

			};
		}

		public List<ProductDetailDto> MapEntitesToDetailDtos(List<Product> products)
		{
			return products.ConvertAll<ProductDetailDto>((Product product) =>
			{
				return MapEntityToDtoDetail(product);
			});
		}
	}




}






