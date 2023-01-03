using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Model
{
	public class Product
	{
		[Key]
		public Guid ProductId { get; set; }

		[Required(AllowEmptyStrings = false), MinLength(2), MaxLength(40)]
		public string Name { get; set; }

		[Required(AllowEmptyStrings = false), MinLength(10), MaxLength(1000)]
		public string Description { get; set; }

		[Required, Range(1, double.MaxValue)]
		public double Price { get; set; }

		[Range(1, double.MaxValue)]

		public double? SalePrice { get; set; }

		[Required]
		public virtual Category Category { get; set; }

		[Required]
		public virtual Picture Picture { get; set; }




		public Product()
		{
		}

		public Product(string name, string description, double price, double? salePrice)
		{
			ProductId = Guid.NewGuid();
			Name = name;
			Description = description;
			Price = price;
			SalePrice = salePrice;
		}


	}
}
