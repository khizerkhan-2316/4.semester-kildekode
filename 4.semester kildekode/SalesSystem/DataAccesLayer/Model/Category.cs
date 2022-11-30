using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }

        [Required(AllowEmptyStrings = false), MinLength(2), MaxLength(40)]
        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }


        public Category(string name)
        {
            CategoryId = Guid.NewGuid();
            Name = name;
            this.Products = new List<Product>();
            
        }

        public Category()
        {
            this.Products = new List<Product>();

        }


    
    }
}
