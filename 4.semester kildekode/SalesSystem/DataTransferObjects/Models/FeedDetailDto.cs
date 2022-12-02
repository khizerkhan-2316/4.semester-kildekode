using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataTransferObjects.Models
{
	public class FeedDetailDto
	{

		[Key]
		public Guid FeedId { get; set; }


		[Display(Name = "Titel")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "Der skal angives en titel")]
		[MinLength(4, ErrorMessage = "Titel skal være på mindst 4 karakter"), MaxLength(80, ErrorMessage = "Titel skal være på maksium 80 karakter")]
		public string Title { get; set; }

		[Display(Name = "Beskrivelse")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "Der skal angives en beskrivelse")]
		[MinLength(10, ErrorMessage = "Beskrivelse skal være på mindst 10 karakter"), MaxLength(1000, ErrorMessage = "Beskrivelse skal være på maksium 1000 karakter")]

		public string Description { get; set; }

		[Display(Name = "Feed format")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "Der skal vælges et format")]
		[MinLength(1, ErrorMessage = "Format skal være på minimum 1 karakter."), MaxLength(10, ErrorMessage = "Format skal være på maks 10 karakter")]
		public string Format { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "Limit skal være på minimum 1")]
		public int? Limit { get; set; }

		
		[MinLength(5, ErrorMessage = "Link skal være på minimum 5 karakter."), MaxLength(100, ErrorMessage = "Link skal være på maksismum 100 karakter.")]
		public string Link { get; set; }

		[Required]
		public virtual List<FeedAttributeDto> Attributes { get; set; }

		[Required]
		public virtual List<FeedCategoryDto> Categories { get; set; }


		[Required, DataType(DataType.DateTime)]
		public DateTime BuildDateTime { get; set; }


		public FeedDetailDto()
		{
			FeedId = Guid.NewGuid();
			Attributes = new List<FeedAttributeDto>();
			Categories = new List<FeedCategoryDto>();
			BuildDateTime = DateTime.Now;
		}
	}
}
