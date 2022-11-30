using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStoreMVC.Models
{
    public class Book : Product
    {

        public string Author;
        public string Publisher;
        public short Published;
        public string ISBN;


        public Book(string title, decimal price, string imageUrl, string author, string publisher, short published, string iSBN) : base(title, price, imageUrl)
        {
            Author = author;
            Publisher = publisher;
            Published = published;
            ISBN = iSBN;
        } 
        
        public Book(string author, string title, decimal price, short published) : base(title, price){
            this.Author = author;
            this.Published = published;
            

        }
    }
}