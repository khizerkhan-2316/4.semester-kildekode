using DataAccessLayer.Context;
using DataAccessLayer.Mappers;
using DataAccessLayer.Model;
using DataTransferObjects.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DataAccessLayer.Repositories
{
	public class SaleRepository : IDisposable
	{
		private readonly SaleMapper _mapper;


		public SaleRepository()
		{
			_mapper = new SaleMapper();
		}


		public void InsertEntity(SaleDetailDto saleDetailDto)
		{
			Sale sale = _mapper.MapDtoToEntity(saleDetailDto);



			using (DatabaseContext context = new DatabaseContext())
			{
				PaymentOption fromDB = context.PaymentOptions.Where(po => po.Name == saleDetailDto.PaymentOption.Name).First();
				sale.PaymentOption = fromDB;

				sale.SalesLines.ForEach(sl => context.Products.Attach(sl.Product));

				context.PaymentOptions.Attach(fromDB);
				context.Sales.Add(sale);
				context.SaveChanges();
			}
		}

		public List<SaleDto> GetEntities()
		{
			using (DatabaseContext context = new DatabaseContext())
			{
				return _mapper.Map(context.Sales.OrderByDescending(s => s.SaleDate)).ToList();
			}
		}

		public SaleDetailDto GetEntityDetailsById(Guid id)
		{
			using (DatabaseContext context = new DatabaseContext())
				return _mapper.MapSaleDetails(context.Sales.Find(id));
		}

		public SaleDto GetEntityById(Guid id)
		{
			using (DatabaseContext context = new DatabaseContext())
			{
				return _mapper.Map(context.Sales.Find(id));
			}
		}



		public void UpdateEntity(SaleDetailDto sale)
		{
			using (DatabaseContext context = new DatabaseContext())
			{
				context.Sales.AddOrUpdate(_mapper.MapDtoToEntity(sale));
				context.SaveChanges();
			}
		}


		public bool DeleteEntity(Guid id)
		{
			using (DatabaseContext context = new DatabaseContext())
			{


				Sale sale = context.Sales.Where(s => s.SaleId == id).Include(s => s.SalesLines).FirstOrDefault();

				context.Payments.Remove(context.Payments.Find(sale.Payment.PaymentId));

				List<Guid> ids = sale.SalesLines.Select(sl => sl.SalesLineId).ToList();

				context.SalesLines.Where(sl => ids.Contains(sl.SalesLineId)).ToList().ForEach(line => context.SalesLines.Remove(line));


				context.Sales.Remove(sale);


				context.SaveChanges();

				return true;
			}

		}

		public PaymentOptionDto GetPaymentOptionByName(string name)
		{
			using (DatabaseContext context = new DatabaseContext())
			{
				PaymentOption paymentOption = context.PaymentOptions.Where(po => po.Name == name).Single();
				return _mapper.Map(paymentOption);

			}
		}


		public void Save(DatabaseContext context)
		{

			context.SaveChanges();

		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing, DatabaseContext context)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			using (DatabaseContext context = new DatabaseContext())
			{

				Dispose(true, context);
				GC.SuppressFinalize(this);
			}
		}

	}
}
