using DataAccessLayer.Model;
using DataTransferObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappers
{
	public class FeedMapper
	{
		public FeedDto MapFeed(Feed feed)
		{
			return new FeedDto
			{
				FeedId = feed.FeedId,
				Title = feed.Title,
				Description = feed.Description,
				Format = feed.Format,
				Limit = feed.Limit,
				Link = feed.Link
			};
		}

		public Feed MapDtoDetailToEntity(FeedDetailDto feed)
		{
			Feed newFeed = new Feed();
			newFeed.Title = feed.Title;
			newFeed.Description = feed.Description;
			newFeed.Format = feed.Format;
			newFeed.Limit = feed.Limit;
			newFeed.Link = $"{feed.Link}api/Feed/Details/{newFeed.FeedId}";
			newFeed.Attributes = feed.Attributes.ConvertAll<FeedAttribute>((FeedAttributeDto attribute) =>
			{
				return new FeedAttribute
				{
					FeedAttributeId = Guid.NewGuid(),
					Attribute = attribute.Attribute,
				};
			});

			newFeed.Categories = feed.Categories.ConvertAll<FeedCategory>((FeedCategoryDto category) =>
			{

				return new FeedCategory
				{
					FeedCategoryId = Guid.NewGuid(),
					FeedCategoryName = category.FeedCategoryName,
					CategoryId = category.CategoryId,
				};
			});

			return newFeed;
		}

		public FeedDetailDto MapFeedDetails(Feed feed)
		{
			return new FeedDetailDto
			{
				FeedId = feed.FeedId,
				Title = feed.Title,
				Description = feed.Description,
				Format = feed.Format,
				Limit = feed.Limit,
				Link = feed.Link,
				Attributes = feed.Attributes.ToList().ConvertAll<FeedAttributeDto>((FeedAttribute attribute) =>
				{
					return new FeedAttributeDto
					{
						FeedAttributeId = attribute.FeedAttributeId,
						Attribute = attribute.Attribute,
					};
				}),
				Categories = feed.Categories.ConvertAll<FeedCategoryDto>((FeedCategory category) =>
				{
					return new FeedCategoryDto
					{
						FeedCategoryId = category.FeedCategoryId,
						CategoryId = category.CategoryId,
						FeedCategoryName = category.FeedCategoryName
					};
				}),
				BuildDateTime= feed.BuildDateTime,
			};
		}

		public List<FeedDto> MapFeeds(IEnumerable<Feed> feeds)
		{
			return feeds.ToList().ConvertAll<FeedDto>((Feed feed) =>
			{
				return MapFeed(feed);
			});
		}
	}
}
