using DataAccessLayer.Context;
using DataAccessLayer.Mappers;
using DataAccessLayer.Model;
using DataTransferObjects.Models;
using System;
using System.Linq;

namespace DataAccessLayer.Repositories
{
	public class PictureRepository
	{
		private readonly PictureMapper _mapper;


		public PictureRepository()
		{
			_mapper = new PictureMapper();
		}

		public void InsertEntity(Picture entity)
		{
			using (DatabaseContext context = new DatabaseContext())
			{

				context.Pictures.Add(entity);
				context.SaveChanges();
			}
		}

		public PictureDto GetEntityById(Guid id)
		{
			using (DatabaseContext context = new DatabaseContext())
			{
				return _mapper.Map(context.Pictures.Find(id));

			}
		}

		public PictureDto GetDefaultImage()
		{
			using (DatabaseContext context = new DatabaseContext())
			{
				return _mapper.Map(context.Pictures.Where(p => p.Title == "Placeholder").Single());
			}
		}


		public void UpdateEntity(Picture entity)
		{
			throw new NotImplementedException();
		}


		public bool DeleteEntity(Guid id)
		{
			throw new NotImplementedException();
		}



	}
}
