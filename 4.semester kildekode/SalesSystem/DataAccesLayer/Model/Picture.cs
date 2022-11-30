using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccessLayer.Model
{
	public class Picture
	{
		[Key]
		public Guid PictureId { get; set; }

		[Required(AllowEmptyStrings = false)]
		public string Title { get; set; }

		[Required(AllowEmptyStrings = false)]
		public string ImagePath { get; set; }

		[NotMapped]
		public HttpPostedFileBase ImageFile { get; set; }
		

		public Picture(string title, string imagePath)
		{
			PictureId = Guid.NewGuid();
			Title = title;
			ImagePath = imagePath;	

		}

		public Picture() {
			PictureId = Guid.NewGuid();
			Title = "Placeholder";
			ImagePath = "~/Images/Placeholder.jpg";
			
		}
	}
}
