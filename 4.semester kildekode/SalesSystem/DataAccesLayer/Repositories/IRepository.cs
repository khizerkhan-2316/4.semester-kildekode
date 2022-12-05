using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Model;

namespace DataAccessLayer.Repositories.ProductRepository
{
	internal interface IRepository<DTO, Entity>
	{
		IEnumerable<DTO> GetEntities();
		DTO GetEntityById(Guid id);

		void InsertEntity(Entity entity);
		bool DeleteEntity(Guid id);
		void UpdateEntity(Entity entity);
		void Save(DatabaseContext context);
	}

}
