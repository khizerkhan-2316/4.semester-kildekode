using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects.Models
{
	public class FeedAttributeDto
	{

		[Key]

		public Guid FeedAttributeId { get; set; }
		public string Attribute { get; set; }



		public FeedAttributeDto()
		{
			FeedAttributeId = Guid.NewGuid();
		}


		public FeedAttributeDto(string attribute)
		{
			FeedAttributeId = Guid.NewGuid();
			Attribute = attribute;
		}
	}
}
