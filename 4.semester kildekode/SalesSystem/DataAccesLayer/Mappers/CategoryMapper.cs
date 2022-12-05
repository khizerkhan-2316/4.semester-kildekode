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

		public Category MapDtoToEntity(CategoryDto category)
		{
			return new Category
			{
				CategoryId = category.CategoryId,
				Name = category.Name,
			};

		}


		public CategoryDto MapEntityToDto(Category category)
		{
			return new CategoryDto
			{
				CategoryId = category.CategoryId,
				Name = category.Name,
			};
		}

		public IEnumerable<CategoryDto> MapEntityListToDto(IEnumerable<Category> categories)
		{
			IEnumerable<CategoryDto> list = categories.ToList().ConvertAll<CategoryDto>((Category category) =>
			{
				return new CategoryDto
				{
					CategoryId = category.CategoryId,
					Name = category.Name
				};
			});

			return list;
		}

		public CategoryDetailDto MapEntityToDtoDetails(Category category)
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
