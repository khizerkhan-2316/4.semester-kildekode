using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using DataTransferObjects.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;



namespace BusinessLayer
{
	public class FeedBLL
	{

		private static FeedBLL instance;
		private readonly ProductBLL controller = ProductBLL.GetController();
		private readonly FeedRepository feedRepository;
		private FeedBLL()
		{
			feedRepository = new FeedRepository();
		}


		public static FeedBLL GetController()
		{
			if (instance == null)
			{
				instance = new FeedBLL();
			}


			return instance;
		}



		public void CreateFeed(FeedDetailDto feed)
		{

			feedRepository.InsertEntity(feed);

		}


		public List<FeedDto> GetFeeds()
		{
			return feedRepository.GetEntities().ToList();
		}

		public FeedDetailDto GetFeedDetails(Guid id)
		{
			return feedRepository.GetFeedDetailsById(id);

		}


		public string GetFeedType(Guid id)
		{
			return feedRepository.GetFeedType(id);
		}


		public void UpdateFeed(FeedDetailDto feed)
		{
			feedRepository.UpdateEntity(feed);
		}


		public void DeleteFeed(Guid id)
		{
			feedRepository.DeleteEntity(id);
		}

		public String GenerateXmlFeed(Guid id)
		{
			FeedDetailDto feedDetails = GetFeedDetails(id);

			SyndicationFeed feed = FeedWithDetails(feedDetails);

			feed.Items = GetSyndicationItems(feedDetails, feedDetails.Limit);


			XmlWriterSettings settings = new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				NewLineHandling = NewLineHandling.Entitize,
				NewLineOnAttributes = true,
				Indent = true
			};

			using (MemoryStream stream = new MemoryStream())
			{
				using (XmlWriter writer = XmlWriter.Create(stream, settings))
				{
					Rss20FeedFormatter formatter = new Rss20FeedFormatter(feed, false);
					formatter.WriteTo(writer);
					writer.Flush();
				}

				return System.Text.Encoding.UTF8.GetString(stream.ToArray());
			}
		}


		public SyndicationFeed FeedWithDetails(FeedDetailDto feedDetails)
		{

			SyndicationFeed feed = new SyndicationFeed(feedDetails.Title, feedDetails.Description, new Uri(feedDetails.Link), Guid.NewGuid().ToString(), DateTime.Now);

			return feed;
		}


		private List<SyndicationItem> GetSyndicationItems(FeedDetailDto feedDetails, int? limit)
		{
			List<SyndicationItem> items = new List<SyndicationItem>();
			List<string> attributes = GetProperties(feedDetails);


			GetProducts(feedDetails, limit).ForEach((ProductDetailDto product) =>
			{
				SyndicationItem item = new SyndicationItem();

				attributes.ForEach((string attribute) =>
				{
					item.ElementExtensions.Add(new XElement(attribute.ToLower(), product.GetType().GetProperty(attribute).GetValue(product)));
				});

				item.ElementExtensions.Add(new XElement("url", $"https://localhost:44327/Products/Search?Query={product.Name.Trim()}&CategoryId=&Sort="));

				items.Add(item);
			});


			return items;
		}



		public List<Dictionary<string, object>> GenerateJsonFeed(Guid id)
		{
			FeedDetailDto feedDetails = GetFeedDetails(id);

			return GetFormmatedObjects(feedDetails);
		}

		public List<Dictionary<string, object>> GetFormmatedObjects(FeedDetailDto feedDetails)
		{
			List<string> properties = GetProperties(feedDetails);

			List<Dictionary<string, object>> List = new List<Dictionary<string, object>>();


			GetProducts(feedDetails, feedDetails.Limit).ForEach((ProductDetailDto product) =>
			{
				Dictionary<string, object> objects = new Dictionary<string, object>();

				properties.ForEach(property =>
				{
					objects.Add(property, product.GetType().GetProperty(property).GetValue(product, null));
				});

				objects.Add("url", $"https://localhost:44327/Products/Search?Query={product.Name.Trim()}&CategoryId=&Sort=");

				List.Add(objects);
			});

			return List;

		}


		private List<string> GetProperties(FeedDetailDto feedDetails)
		{
			return feedDetails.Attributes.ConvertAll<string>((FeedAttributeDto attribute) =>
			{
				return attribute.Attribute;
			});
		}

		private List<ProductDetailDto> GetProducts(FeedDetailDto feedDetails, int? limit)
		{
			List<ProductDetailDto> products = new List<ProductDetailDto>();

			foreach (FeedCategoryDto category in feedDetails.Categories)
			{
				products.AddRange(controller.GetProductsDetailsFromCategoryId(category.CategoryId));
			}

			if (limit != null && limit < products.Count)
			{
				return products.Take((int)limit).ToList();
			}

			return products;
		}

		public void ModifyFeed(FeedDetailDto feed, List<string> attributes, List<string> feedCategories, List<CategoryDto> categories) {

			List<FeedAttributeDto> feedAttributeDtos = new List<FeedAttributeDto>();
			List<FeedCategoryDto> feedCategoryDtos = new List<FeedCategoryDto>();

			feedAttributeDtos.Add(new FeedAttributeDto { FeedAttributeId = Guid.NewGuid(), Attribute = "ProductId" });

			attributes.ForEach(attribute => feedAttributeDtos.Add(new FeedAttributeDto { FeedAttributeId = Guid.NewGuid(), Attribute = attribute }));
			feedCategories.ForEach(category =>
			{
				CategoryDto c = categories.Where((CategoryDto cdto) => cdto.CategoryId.ToString() == category).First();

				feedCategoryDtos.Add(new FeedCategoryDto { FeedCategoryId = Guid.NewGuid(), FeedCategoryName = c.Name, CategoryId = c.CategoryId });

			});

			feed.Attributes = feedAttributeDtos;
			feed.Categories = feedCategoryDtos;

	
		}

	}
}
