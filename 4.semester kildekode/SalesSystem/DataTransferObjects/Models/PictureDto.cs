using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DataTransferObjects.Models
{
	public class PictureDto
	{
		[Key]
		public Guid PictureId { get; set; }

		[Display(Name = "Titel")]

		public string Title { get; set; }

		[Display(Name = "Billede")]
		public string ImagePath { get; set; }

		public HttpPostedFileBase ImageFile { get; set; }



		public PictureDto(string title, string imagePath)
		{
			PictureId = Guid.NewGuid();
			Title = title;
			ImagePath = imagePath;
		}



		public PictureDto()
		{

		}

		public override string ToString()
		{
			return ImagePath;
		}
	}
}
