using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DataAccessLayer.Model
{
	public class Sale
	{

		[Key]
		public Guid SaleId { get; set; }

		[Required, Range(0, double.MaxValue)]
		public double TotalPrice { get; set; }

		public double? AmountReturned { get; set; }

		[Range(1, 100)]
		public double? Discount { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime SaleDate { get; set; }

		[Required]
		public virtual List<SalesLine> SalesLines { get; set; }

		[Required]
		public virtual PaymentOption PaymentOption { get; set; }

		[Required]
		public virtual Payment Payment { get; set; }



		public Sale()
		{
			SaleId = Guid.NewGuid();
			SaleDate = DateTime.Now;
			SalesLines = new List<SalesLine>();

		}


		public void CalculateAndSetTotalPrice()
		{
			TotalPrice = SalesLines.Aggregate(0, (double acc, SalesLine s) => acc + s.TotalPrice);


		}



		public void createPayment(double amount)
		{
			Payment payment = new Payment(amount);
			Payment = payment;
		}

		public void createSalesLine(int quantity, Product product)
		{
			SalesLine salesLine = new SalesLine(quantity, product);
			salesLine.CalculateAndSetTotalPrice(Discount);
			SalesLines.Add(salesLine);
		}

		public void calculateAndSetAmountRetunred()
		{


			if (Payment.AmountPaid > TotalPrice)
			{
				this.AmountReturned = Payment.AmountPaid - TotalPrice;
			}
		}


		public bool IsPaymentDone()
		{
			return Payment.AmountPaid >= TotalPrice;
		}







	}
}
