using DataAccessLayer.Context;
using DataAccessLayer.Mappers;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories.ProductRepository;
using DataTransferObjects.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class SaleRepository : IRepository<SaleDto, Sale>, IDisposable
    {
        private readonly SaleMapper _mapper;


        public SaleRepository()
        {
            _mapper = new SaleMapper();
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



				Save(context);
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

        public IEnumerable<SaleDto> GetEntities()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return _mapper.Map(context.Sales.OrderByDescending(s => s.SaleDate));
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

        public void InsertEntity(Sale entity)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                context.Sales.Add(entity);
                Save(context);
            }
        }

        public void InsertEntity(SaleDetailDto saleDetailDto)
        {
            Sale sale = new Sale
            {
                SaleId = saleDetailDto.SaleId,
                SaleDate = saleDetailDto.SaleDate,
                Discount = saleDetailDto.Discount
            };

            sale.createPayment(saleDetailDto.Payment.AmountPaid);



            using (DatabaseContext context = new DatabaseContext())
            {
                PaymentOption fromDB = context.PaymentOptions.Where(po => po.Name == saleDetailDto.PaymentOption.Name).First();
                sale.PaymentOption = fromDB;

                sale.SalesLines = saleDetailDto.SalesLines.ConvertAll<SalesLine>((SalesLineDto dto) =>
                {
                    Product product = new Product { ProductId = dto.Product.ProductId, Price = dto.Product.Price, SalePrice = dto.Product.SalePrice };
                    context.Products.Attach(product);


                    SalesLine salesLine = new SalesLine
                    {
                        SalesLineId = dto.SalesLineId,
                        Quantity = dto.Quantity,
                        Product = product
                    };

                   if(sale.Discount !=null || sale.Discount != 0)
                    {
						salesLine.CalculateAndSetTotalPrice(sale.Discount);
					}

                    return salesLine;

                });
                context.PaymentOptions.Attach(fromDB);

                sale.CalculateAndSetTotalPrice();
                sale.calculateAndSetAmountRetunred();
                context.Sales.Add(sale);
                context.SaveChanges();
            }
        }

        public void UpdateEntity(Sale entity)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                context.Sales.AddOrUpdate(entity);
                Save(context);
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
