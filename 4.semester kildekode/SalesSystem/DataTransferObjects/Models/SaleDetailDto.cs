using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DataTransferObjects.Models
{
	public class SaleDetailDto
	{
		[Key]
		public Guid SaleId { get; set; }

		[Display(Name = "Total pris")]
		[Required(ErrorMessage = "Total pris skal angives"), Range(0, double.MaxValue, ErrorMessage = "Prisen skal være et positivt tal")]
		public double TotalPrice { get; set; }

		[Display(Name = "Antal retuneret")]
		public double? AmountReturned { get; set; }

		[Range(1, 100, ErrorMessage = "Discount skal være mellem 1 - 100")]
		public double? Discount { get; set; }

		[Display(Name = "Salgsdato")]
		[DataType(DataType.DateTime), Required(ErrorMessage = "Der skal angives en salgsdato")]
		public DateTime SaleDate { get; set; }

		[Display(Name = "Salgslinjer")]
		[Required(ErrorMessage = "Salget skal have mindst 1 salgslinje")]
		public virtual List<SalesLineDto> SalesLines { get; set; }

		[Display(Name = "Betalingsmulighed")]
		[Required(ErrorMessage = "Der skal vælges en betalingsmulighed")]
		public virtual PaymentOptionDto PaymentOption { get; set; }

		[Display(Name = "Betaling")]
		[Required(ErrorMessage = "Betaling skal foregå")]
		public virtual PaymentDto Payment { get; set; }


		public SaleDetailDto()
		{
			SaleId = Guid.NewGuid();
			TotalPrice = 0;
			SaleDate = DateTime.Now;
		}
	}
}
