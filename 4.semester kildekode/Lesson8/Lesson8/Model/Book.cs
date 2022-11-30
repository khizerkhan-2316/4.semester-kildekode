using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8.Model
{
    public class Book
    {

        public int ID { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }   
        public double Price { get; set; }
        public double? SalePrice { get; set; }
        public string Language { get; set; }    
        public string ISBN { get; set; }
        
        public bool EBook { get; set; }

        public virtual Library library { get; set; }

        public Guid LibraryID { get; set; }


        public Book(string title, string description, string author, string genre, double price, double salePrice, string language, string isbn)
        {
            Title = title;
            Description = description;
            Author = author;
            Genre = genre;
            Price = price;
            SalePrice = salePrice;
            Language = language;
            ISBN = isbn;
        }


        public Book()
        {

        }


        public Book(string title, string description, string author, string genre, double price, string language, string isbn)
        {
            Title = title;
            Description = description;
            Author= author; 
            Genre = genre;
            Price = price;
            Language = language;
            ISBN = isbn;
        }

        public override string ToString()
        {
            return SalePrice == null ? $"Book: {Title}, {Genre}, {Language}, {Price}" : $"Book: {Title}, {Genre}, {Language}, {Price}, Saleprice: {SalePrice}";
        }


    }



    
}
