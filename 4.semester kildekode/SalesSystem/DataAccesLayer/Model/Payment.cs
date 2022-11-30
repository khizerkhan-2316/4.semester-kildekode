using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Payment
    {
        [Key]
        public Guid PaymentId { get; set; }

        [Required, Range(0, double.MaxValue)]
        public double AmountPaid { get; set; }

        [DataType(DataType.DateTime), Required]
        public DateTime PaymentDate { get; set; }



       public Payment()
        {
            PaymentId = Guid.NewGuid();
            PaymentDate = DateTime.Now;

        }


        public Payment(double amountPaid)
        {
            PaymentId = Guid.NewGuid();
            AmountPaid = amountPaid;
            PaymentDate = DateTime.Now;

        }

    }
}
