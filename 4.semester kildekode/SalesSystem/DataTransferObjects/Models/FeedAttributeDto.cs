using System;
using System.ComponentModel.DataAnnotations;

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
