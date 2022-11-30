using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects.Models
{

    public  class CategoryDto
    {

        [Key]
        public Guid CategoryId { get; set; }

		[Display(Name = "Kategori")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "Der skal angives et kategorinavn")]
		[MinLength(2, ErrorMessage = "Kategori navn skal være større end 1 karakter."), MaxLength(40, ErrorMessage = "Kateogri navn skal være mindre end 41 karakter.")]
		public string Name { get; set; }


        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
