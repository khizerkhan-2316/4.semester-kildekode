using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects.Models
{
    public class SaleDto
    {
        [Key]
        public Guid SaleId { get; set; }

		[Display(Name = "Total pris")]
		[Required(ErrorMessage = "Total pris skal angives"), Range(0, double.MaxValue, ErrorMessage = "Prisen skal være et positivt tal")]
		public double TotalPrice { get; set; }


        public override string ToString()
        {
            return $"ID:{SaleId}, Pris: {TotalPrice}";
        }
    }
}
