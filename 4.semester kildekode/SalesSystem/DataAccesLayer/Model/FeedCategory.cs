using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
	public class FeedCategory
	{
		[Key]
		public Guid FeedCategoryId { get; set; }

		[Required]	
		public Guid CategoryId { get; set; }

		[Required]	
		public string FeedCategoryName { get; set;}


		public FeedCategory()
		{
			FeedCategoryId = Guid.NewGuid();
		}

		public FeedCategory(Guid categoryId, string feedCategoryName)
		{
			FeedCategoryId = Guid.NewGuid();
			CategoryId = categoryId;
			FeedCategoryName = feedCategoryName;
		}
	}
}
