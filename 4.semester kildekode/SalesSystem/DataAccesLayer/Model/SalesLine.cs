using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class SalesLine
    {
        [Key]
        public Guid SalesLineId { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        public virtual Product Product { get; set; }

   
        [Required, Range(0, double.MaxValue)]  
        public double TotalPrice { get; set; }



        public SalesLine()
        {
        }

        public SalesLine(int quantity, Product product)
        {
            SalesLineId = Guid.NewGuid();
            Quantity = quantity;
            Product = product;
        }


        public void CalculateAndSetTotalPrice(double? discount)
        {


            if(Product.SalePrice != null && discount != null)
            {
                TotalPrice = (double)Product.SalePrice * Quantity;

                TotalPrice -= (double)((TotalPrice / 100) * discount);
                return;
            }


            if(Product.SalePrice != null && discount == null)
            {
                TotalPrice = (double)Product.SalePrice * Quantity;
                return;
            }

            if(discount != null)
            {
                TotalPrice = Product.Price * Quantity;
                TotalPrice -= (double)((TotalPrice / 100) * discount);
                return;
            }

            TotalPrice = Product.Price * Quantity;
        }


    }
}
