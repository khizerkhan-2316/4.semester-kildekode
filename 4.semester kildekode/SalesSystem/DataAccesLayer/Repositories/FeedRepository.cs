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
	public class FeedRepository
	{

		private FeedMapper _mapper;


		public FeedRepository()
		{
			_mapper = new FeedMapper();
		}


		public void InsertEntity(FeedDetailDto feed)
		{
			using (DatabaseContext context = new DatabaseContext())
			{
				context.Feeds.Add(_mapper.MapDtoDetailToEntity(feed));

				context.SaveChanges();
			}
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



		public void UpdateEntity(FeedDetailDto feed)
		{
			using (DatabaseContext context = new DatabaseContext())
			{
				Feed feedFromDb = context.Feeds.Where(f => f.FeedId == feed.FeedId).Include(f => f.Attributes).Include(f => f.Categories).First();

				Feed entity = _mapper.MapDtoDetailToEntity(feed);

				entity.FeedId = feed.FeedId;
				entity.Link = $"{feed.Link}api/Feed/Details/{feed.FeedId}";

				List<Guid> attributesIds = feedFromDb.Attributes.Select(a => a.FeedAttributeId).ToList();
				List<Guid> categoriesIds = feedFromDb.Categories.Select(c => c.FeedCategoryId).ToList();	

				feedFromDb.Attributes = entity.Attributes;
				feedFromDb.Categories = entity.Categories;

				context.Entry(feedFromDb).CurrentValues.SetValues(entity);

				context.Feeds.AddOrUpdate(feedFromDb);

				attributesIds.ForEach(id => context.FeedAttributes.Remove(context.FeedAttributes.Find(id)));
				categoriesIds.ForEach(id => context.FeedCategories.Remove(context.FeedCategories.Find(id)));	

				context.SaveChanges();
			}
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



	}
}
