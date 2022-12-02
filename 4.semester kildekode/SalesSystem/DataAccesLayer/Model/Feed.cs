using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
	public class Feed
	{

		[Key]
		public Guid FeedId { get; set; }

		[Required(AllowEmptyStrings = false), MinLength(4), MaxLength(80)]
		public string Title { get; set; }

		[Required(AllowEmptyStrings = false), MinLength(10), MaxLength(1000)]
		public string Description { get; set; }

		[Required(AllowEmptyStrings = false), MinLength(1), MaxLength(10)]
		public string Format { get; set; }

		[Range(1, int.MaxValue)]
		public int? Limit { get; set; }

		[Required(AllowEmptyStrings =false), MinLength(5), MaxLength(100)]
		public string link { get; set; }

		[Required]
		public virtual List<FeedAttribute> Attributes { get; set; }

		[Required]
		public virtual List<FeedCategory> Categories { get; set; }

		[Required, DataType(DataType.DateTime)]
		public DateTime BuildDateTime { get; set; }

		public Feed() 
		{
			FeedId = Guid.NewGuid();
			Attributes = new List<FeedAttribute>();
			Categories = new List<FeedCategory>();
			BuildDateTime = DateTime.Now;
		
		}	
	}
}
