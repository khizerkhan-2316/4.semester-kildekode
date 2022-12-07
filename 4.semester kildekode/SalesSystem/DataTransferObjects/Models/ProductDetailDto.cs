using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DataTransferObjects.Models
{
	[DataContractAttribute]
	public class ProductDetailDto
	{
		[Key]
		[DataMember]
		public Guid ProductId { get; set; }

		[Display(Name = "Navn")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "Der skal angives et navn.")]
		[MinLength(2, ErrorMessage = "Navn skal være større end 1 karakter."), MaxLength(40, ErrorMessage = "Navn skal være mindre end 40 karakter")]
		[DataMember]
		public string Name { get; set; }

		[Display(Name = "Beskrivelse")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "Der skal angives en beskrivelse")]
		[MinLength(10, ErrorMessage = "Beskrivelse skal være større end 9 karakter."), MaxLength(1000, ErrorMessage = "Beskrivelse skal være mindre end 1001 karakter.")]
		[DataMember]

		public string Description { get; set; }

		[Display(Name = "Pris")]
		[RegularExpression("([0-9]+)", ErrorMessage = "Det skal være et tal")]
		[Required(ErrorMessage = "Der skal angives en pris"), Range(1, double.MaxValue, ErrorMessage = "Prisen skal være større end 0")]
		[DataMember]
		public double Price { get; set; }

		[Display(Name = "Salgspris")]
		[RegularExpression("([0-9]+)", ErrorMessage = "Det skal være et tal")]
		[Range(1, double.MaxValue, ErrorMessage = "Prisen skal være større end 0.")]
		[DataMember]

		public double? SalePrice { get; set; }

		[Display(Name = "Kategori")]
		[Required(ErrorMessage = "Produktet skal have en kategori")]
		[DataMember]

		public virtual CategoryDto Category { get; set; }

		[DataMember]
		public virtual PictureDto Picture { get; set; }

		public override string ToString()
		{
			return SalePrice == null ? $"Navn: {Name}, Pris: {Price}" : $"Navn: {Name}, Pris: {Price}, Salgspris: {SalePrice}";
		}

	}
}
