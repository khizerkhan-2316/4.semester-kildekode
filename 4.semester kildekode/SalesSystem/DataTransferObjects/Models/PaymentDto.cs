using System;
using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects.Models
{
	public class PaymentDto
	{
		[Key]
		public Guid PaymentId { get; set; }

		[Display(Name = "Beløb betalt")]
		[Required(ErrorMessage = "betaling skal foregå"), Range(0, double.MaxValue, ErrorMessage = "Beløb betalt skal være et positiv tal op")]

		public double AmountPaid { get; set; }

		[Display(Name = "Betalingsdato")]
		[DataType(DataType.DateTime), Required(ErrorMessage = "Der skal være en dato")]

		public DateTime PaymentDate { get; set; }
	}
}
