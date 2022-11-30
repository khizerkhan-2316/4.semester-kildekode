using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class PaymentOption
    {
        [Key]
        public Guid PaymentOptionId { get; set; }

        [Required, MinLength(3), MaxLength(40)]
        public string Name { get; set; }

        public PaymentOption()
        {


        }


        public PaymentOption(string name)
        {
            PaymentOptionId = Guid.NewGuid();
            Name = name;
        }   
    }
}
