using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStoreMVC.Models
{
    public class Product
    {

        public string Title;

        public decimal Price;

        public string ImageUrl;


        public Product(string title, decimal price, string imageUrl)
        {
            Title = title;
            Price = price;
            ImageUrl = imageUrl;
        }

        public Product(string title, decimal price)
        {
            this.Title = title;
            this.Price = price;
        }
    }
}