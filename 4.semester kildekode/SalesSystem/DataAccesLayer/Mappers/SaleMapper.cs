using DataAccessLayer.Model;
using DataTransferObjects.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Mappers
{
	public class SaleMapper
	{

		public SaleDto Map(Sale sale)
		{
			return new SaleDto
			{
				SaleId = sale.SaleId,
				TotalPrice = sale.TotalPrice
			};
		}

		public PaymentOptionDto Map(PaymentOption paymentOption)
		{
			return new PaymentOptionDto { PaymentOptionId = paymentOption.PaymentOptionId, Name = paymentOption.Name };
		}

		public IEnumerable<SaleDto> Map(IEnumerable<Sale> sales)
		{
			IEnumerable<SaleDto> list = sales.ToList().ConvertAll<SaleDto>((Sale sale) =>
			{
				return new SaleDto { SaleId = sale.SaleId, TotalPrice = sale.TotalPrice };
			});

			return list;
		}

		public Sale MapDtoToEntity(SaleDetailDto saleDetailDto)
		{
			Sale sale = new Sale
			{
				SaleId = saleDetailDto.SaleId,
				SaleDate = saleDetailDto.SaleDate,
				Discount = saleDetailDto.Discount
			};

			sale.createPayment(saleDetailDto.Payment.AmountPaid);




			sale.SalesLines = saleDetailDto.SalesLines.ConvertAll<SalesLine>((SalesLineDto dto) =>
			{
				Product product = new Product { ProductId = dto.Product.ProductId, Price = dto.Product.Price, SalePrice = dto.Product.SalePrice };


				SalesLine salesLine = new SalesLine
				{
					SalesLineId = dto.SalesLineId,
					Quantity = dto.Quantity,
					Product = product
				};

				if (sale.Discount != null || sale.Discount != 0)
				{
					salesLine.CalculateAndSetTotalPrice(sale.Discount);
				}

				return salesLine;

			});


			sale.CalculateAndSetTotalPrice();
			sale.calculateAndSetAmountRetunred();

			return sale;
		}

		public SaleDetailDto MapSaleDetails(Sale sale)
		{
			return new SaleDetailDto
			{
				SaleId = sale.SaleId,
				TotalPrice = sale.TotalPrice,
				AmountReturned = sale.AmountReturned,
				Discount = sale.Discount,
				SaleDate = sale.SaleDate,
				SalesLines = sale.SalesLines.ConvertAll<SalesLineDto>((SalesLine salesLine) =>
				{
					return new SalesLineDto
					{
						SalesLineId = salesLine.SalesLineId,
						Quantity = salesLine.Quantity,
						TotalPrice = salesLine.TotalPrice,
						Product = new ProductDetailDto
						{
							ProductId = salesLine.Product.ProductId,
							Name = salesLine.Product.Name,
							Price = salesLine.Product.Price,
							SalePrice = salesLine.Product.SalePrice,
							Description = salesLine.Product.Description,
							Category = new CategoryDto { CategoryId = salesLine.Product.Category.CategoryId, Name = salesLine.Product.Category.Name }
						}
					};
				}),

				Payment = new PaymentDto { AmountPaid = sale.Payment.AmountPaid, PaymentDate = sale.Payment.PaymentDate, PaymentId = sale.Payment.PaymentId },
				PaymentOption = new PaymentOptionDto { PaymentOptionId = sale.PaymentOption.PaymentOptionId, Name = sale.PaymentOption.Name }

			};
		}
	}
}
