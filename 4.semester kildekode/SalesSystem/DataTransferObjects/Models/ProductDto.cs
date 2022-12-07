using System;
using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects
{
	public class ProductDto
	{
		[Key]

		public Guid ProductId { get; set; }

		[Display(Name = "Navn")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "Der skal angives et navn")]
		[MinLength(2, ErrorMessage = "Navn skal være større end 1 karakter."), MaxLength(40, ErrorMessage = "Navn skal være mindre end 40 karakter")]
		public string Name { get; set; }





		public override string ToString()
		{
			return $"{Name}";
		}

	}
}
