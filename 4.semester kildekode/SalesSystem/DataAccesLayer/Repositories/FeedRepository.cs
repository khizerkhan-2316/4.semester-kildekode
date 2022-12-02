using DataAccessLayer.Context;
using DataAccessLayer.Mappers;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories.ProductRepository;
using DataTransferObjects.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
	public class FeedRepository : IRepository<FeedDto, Feed>
	{

		private FeedMapper _mapper;


		public FeedRepository()
		{
			_mapper = new FeedMapper();
		}
		public bool DeleteEntity(Guid id)
		{
			using (DatabaseContext context = new DatabaseContext())
			{
				Feed feed = context.Feeds.Where(f => f.FeedId == id).Include(p => p.Attributes).Include(p => p.Categories).First();

				feed.Attributes.ToList().ForEach(attribute => context.FeedAttributes.Remove(attribute));
				feed.Categories.ToList().ForEach(category => context.FeedCategories.Remove(category));
				context.Feeds.Remove(feed);
				context.SaveChanges();
			}

			return true;
		}

		public IEnumerable<FeedDto> GetEntities()
		{
			using (DatabaseContext context = new DatabaseContext())
			{
				return _mapper.MapFeeds(context.Feeds);
			}
		}

		public FeedDetailDto GetFeedDetailsById(Guid id)
		{
			using (DatabaseContext context = new DatabaseContext())
			{
				return _mapper.MapFeedDetails(context.Feeds.Find(id));	
			}
		}

		public FeedDto GetEntityById(Guid id)
		{
			throw new NotImplementedException();
		}

		public void InsertEntity(Feed entity)
		{
			using(DatabaseContext context = new DatabaseContext())
			{
				context.Feeds.Add(entity);

				context.SaveChanges();
			}
		}

		public void Save(DatabaseContext context)
		{
			throw new NotImplementedException();
		}

		public string GetFeedType(Guid id)
		{
			using (DatabaseContext context = new DatabaseContext())
			{
				return context.Feeds.Find(id).Format;
			}
		}

		public void UpdateEntity(Feed entity)
		{
			throw new NotImplementedException();
		}
	}
}
