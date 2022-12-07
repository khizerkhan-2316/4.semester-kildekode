using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Model
{
	public class FeedAttribute
	{
		[Key]

		public Guid FeedAttributeId { get; set; }
		public string Attribute { get; set; }



		public FeedAttribute()
		{
			FeedAttributeId = Guid.NewGuid();
		}


		public FeedAttribute(string attribute)
		{
			FeedAttributeId = Guid.NewGuid();
			Attribute = attribute;
		}
	}
}
