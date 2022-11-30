using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using DataTransferObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class SaleController
    {

        private static SaleController instance;
        private readonly SaleRepository repository;


        private SaleController()
        {
            repository = new SaleRepository();
        }

        public static SaleController GetController()
        {
            if(instance == null)
            {
                instance = new SaleController();
            }

            return instance;
        }

        public List<SaleDto> GetSales()
        {
            return repository.GetEntities().ToList();
        }

        public SaleDetailDto GetSaleDetails(Guid id)
        {
            return repository.GetEntityDetailsById(id);
        }

        public void CreateSale(SaleDetailDto dto)
        {
           repository.InsertEntity(dto);
        }

        public void DeleteSale(Guid id)
        {
            repository.DeleteEntity(id);
        }
    }
}
