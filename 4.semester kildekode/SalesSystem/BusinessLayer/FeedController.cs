using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BusinessLayer
{
    public class FeedController
    {
       
        private static FeedController instance;
        private readonly ProductController controller = ProductController.GetController();
        private FeedController()
        {

        }


        public static FeedController GetController()
        {
            if(instance == null)
            {
                instance = new FeedController();
            }


            return instance;
        }


        public SyndicationFeed GenerateFeed()
        {
            SyndicationFeed feed = new SyndicationFeed("RSS Feed", "This is a custom generated RSS feed", new Uri("https://df.dk"), Guid.NewGuid().ToString(), DateTime.Now);

            feed.Items = GetItems();
            return feed;
        }


        private List<SyndicationItem> GetItems()
        {
            List<SyndicationItem> items = new List<SyndicationItem>();

            controller.GetProductsDetails().ForEach((product) =>
            {
                SyndicationItem item = new SyndicationItem(product.Name, product.Description, null, product.ProductId.ToString(), DateTime.Now);
                item.ElementExtensions.Add(new XElement("Price", product.Price));
                item.ElementExtensions.Add(new XElement("SalePrice", product.SalePrice));
                item.Categories.Add(new SyndicationCategory(product.Category.Name));

                items.Add(item);
            });

            return items;
        }
        
    }
}
