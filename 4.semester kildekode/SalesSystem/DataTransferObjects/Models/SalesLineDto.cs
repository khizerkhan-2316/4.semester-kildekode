using System;
using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects.Models
{
	public class SalesLineDto
	{
		[Key]
		public Guid SalesLineId { get; set; }

		[Display(Name = "Antal")]
		[Required(ErrorMessage = "Der skal angives antal"), Range(1, int.MaxValue, ErrorMessage = "Antallet skal være et positvt tal")]
		public int Quantity { get; set; }

		[Display(Name = "Produkt")]
		[Required(ErrorMessage = "Der skal angives et produkt til salgslinjen")]
		public ProductDetailDto Product { get; set; }

		[Display(Name = "Total pris")]
		[Required(ErrorMessage = "Der skal angives en total pris"), Range(0, double.MaxValue, ErrorMessage = "Den totale pris skal være et positiv tal")]

		public double TotalPrice { get; set; }


		public SalesLineDto()
		{
			SalesLineId = Guid.NewGuid();
		}

		public override string ToString()
		{
			return $"ID: {SalesLineId}, antal {Quantity}";
		}



		public void CalculateAndSetTotalPrice()
		{
			if (Product.SalePrice != null)
			{
				TotalPrice = (double)Product.SalePrice * Quantity;
				return;
			}

			TotalPrice = Product.Price * Quantity;
		}

	}


}
