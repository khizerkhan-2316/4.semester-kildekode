﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects.Models
{
    public class PaymentOptionDto
    {
		[Key]
		public Guid PaymentOptionId { get; set; }

        [Display(Name = "Betalingsmulighed")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "Der skal angives et navn."), MinLength(3, ErrorMessage ="Skal være større end 2 karakter"), MaxLength(40, ErrorMessage = "Skal være mindre end 41 karakter.")]
		public string Name { get; set; }



        public override string ToString()
        {
            return Name;
        }
    }


}
