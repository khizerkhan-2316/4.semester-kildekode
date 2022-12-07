using DataAccessLayer.Repositories;
using DataTransferObjects.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
	public class SaleBLL
	{

		private static SaleBLL instance;
		private readonly SaleRepository repository;


		private SaleBLL()
		{
			repository = new SaleRepository();
		}

		public static SaleBLL GetController()
		{
			if (instance == null)
			{
				instance = new SaleBLL();
			}

			return instance;
		}

		public List<SaleDto> GetSales()
		{
			return repository.GetEntities();
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
