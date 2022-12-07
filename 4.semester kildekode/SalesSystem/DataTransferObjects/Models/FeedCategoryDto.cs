using System;
using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects.Models
{
	public class FeedCategoryDto
	{
		[Key]
		public Guid FeedCategoryId { get; set; }

		[Required]
		public Guid CategoryId { get; set; }

		[Required]
		public string FeedCategoryName { get; set; }

		public FeedCategoryDto()
		{
			FeedCategoryId = Guid.NewGuid();

		}


	}
}
