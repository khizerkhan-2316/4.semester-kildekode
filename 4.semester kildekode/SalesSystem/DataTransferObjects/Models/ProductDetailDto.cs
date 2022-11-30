using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DataTransferObjects.Models
{
    public class ProductDetailDto
    {
        [Key]
        public Guid ProductId { get; set; }

        [Display(Name = "Navn")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Der skal angives et navn.")]
        [MinLength(2, ErrorMessage = "Navn skal være større end 1 karakter."), MaxLength(40, ErrorMessage = "Navn skal være mindre end 40 karakter")]
        public string Name { get; set; }

        [Display(Name = "Beskrivelse")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Der skal angives en beskrivelse")]
        [MinLength(10, ErrorMessage ="Beskrivelse skal være større end 9 karakter."), MaxLength(1000, ErrorMessage = "Beskrivelse skal være mindre end 1001 karakter.")]
        public string Description { get; set; }

        [Display(Name = "Pris")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Det skal være et tal")]
        [Required(ErrorMessage = "Der skal angives en pris"), Range(1, double.MaxValue, ErrorMessage = "Prisen skal være større end 0")]

        public double Price { get; set; }

        [Display(Name = "Salgspris")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Det skal være et tal")]
        [Range(1, double.MaxValue, ErrorMessage = "Prisen skal være større end 0.")]
        public double? SalePrice { get; set; }

        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "Produktet skal have en kategori")]
        public virtual CategoryDto Category { get; set; }

       
        public virtual PictureDto Picture { get; set; }

        public override string ToString()
        {
            return SalePrice == null? $"Navn: {Name}, Pris: {Price}" : $"Navn: {Name}, Pris: {Price}, Salgspris: {SalePrice}";
        }

    }
}
