using DataAccessLayer.Context;
using DataAccessLayer.Mappers;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories.ProductRepository;
using DataTransferObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
	public class PictureRepository : IRepository<PictureDto, Picture>, IDisposable
	{
		private readonly PictureMapper _mapper;


		public PictureRepository()
		{
			_mapper = new PictureMapper();
		}

		public bool DeleteEntity(Guid id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<PictureDto> GetEntities()
		{
			throw new NotImplementedException();
		}

		public PictureDto GetEntityById(Guid id)
		{
			using (DatabaseContext context = new DatabaseContext())
			{
				return _mapper.Map(context.Pictures.Find(id));

			}
		}

		public void InsertEntity(Picture entity)
		{
			using (DatabaseContext context = new DatabaseContext())
			{

				context.Pictures.Add(entity);
				context.SaveChanges();
			}
		}

		public void UpdateEntity(Picture entity)
		{
			throw new NotImplementedException();
		}

		public PictureDto GetDefaultImage()
		{
			using (DatabaseContext context = new DatabaseContext())
			{
				return _mapper.Map(context.Pictures.Where(p => p.Title == "Placeholder").Single());
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
