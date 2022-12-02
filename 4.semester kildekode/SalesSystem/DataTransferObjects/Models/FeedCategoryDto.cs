using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
