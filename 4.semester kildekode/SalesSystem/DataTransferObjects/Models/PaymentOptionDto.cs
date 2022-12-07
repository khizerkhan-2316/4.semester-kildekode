using System;
using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects.Models
{
	public class PaymentOptionDto
	{
		[Key]
		public Guid PaymentOptionId { get; set; }

		[Display(Name = "Betalingsmulighed")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "Der skal angives et navn."), MinLength(3, ErrorMessage = "Skal være større end 2 karakter"), MaxLength(40, ErrorMessage = "Skal være mindre end 41 karakter.")]
		public string Name { get; set; }



		public override string ToString()
		{
			return Name;
		}
	}


}
