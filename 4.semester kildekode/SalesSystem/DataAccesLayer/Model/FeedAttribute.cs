using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
