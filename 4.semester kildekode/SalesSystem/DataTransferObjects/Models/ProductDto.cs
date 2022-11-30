using DataTransferObjects.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
