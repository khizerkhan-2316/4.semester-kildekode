using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    internal class Initializer : CreateDatabaseIfNotExists<DatabaseContext>
    {



        protected override void Seed(DatabaseContext context)
        {


            Picture picture = new Picture();

            Product product = new Product("MySQL - All you need to know", "This book is an excellent guide for you on how to use SQL (Structured Query Language) in relational database management systems.", 699, 500);
            Product product1 = new Product("Macbook Pro M1", "Denne nye M1'er er suveræn både til studie og gaming", 20000, 18999);
            Product product2 = new Product("Speedbåd m7 100HK", "Denne fine speedbåd har 100 HK og er af mærket Hailway.", 399999, 200000);


            Category book = new Category("Bøger");
            Category motorboats = new Category("Motorbåde");
            Category laptops = new Category("Bærbare");

            PaymentOption mobilePay = new PaymentOption("MobilePay");
            PaymentOption card = new PaymentOption("Dankort");
            PaymentOption cash = new PaymentOption("Kontant");

            context.PaymentOptions.Add(cash);


            Sale sale = new Sale();
            Sale sale1 = new Sale();
            Sale sale2 = new Sale();

            sale.PaymentOption = mobilePay;
            sale1.PaymentOption = card;
            sale2.PaymentOption = cash;

            sale.Discount = 50;
            sale2.Discount = 25;


            sale.createSalesLine(10, product);
            sale1.createSalesLine(10, product1);
            sale2.createSalesLine(1, product2);
            sale2.createSalesLine(1, product1);
            sale2.createSalesLine(1, product);

            sale.createPayment(10000);
            sale1.createPayment(200000);
            sale2.createPayment(300000);

           

            sale.CalculateAndSetTotalPrice();
            sale1.CalculateAndSetTotalPrice();
            sale2.CalculateAndSetTotalPrice();


            sale.calculateAndSetAmountRetunred();
            sale1.calculateAndSetAmountRetunred();
            sale2.calculateAndSetAmountRetunred();

            product.Category = book;
            product1.Category = laptops;
            product2.Category = motorboats;

            product.Picture = picture;
            product1.Picture = picture;
            product2.Picture = picture; 

            book.Products.Add(product);
            laptops.Products.Add(product1);
            motorboats.Products.Add(product2);

            context.Pictures.Add(picture);

            context.Categories.Add(book);
            context.Categories.Add(motorboats);
            context.Categories.Add(laptops);

            context.Products.Add(product);
            context.Products.Add(product1);
            context.Products.Add(product2);

          

            if (sale.IsPaymentDone())
            {
                context.Sales.Add(sale);
            }

            if (sale1.IsPaymentDone())
            {
                context.Sales.Add(sale1);
            }

            if (sale2.IsPaymentDone())
            {
                context.Sales.Add(sale2);
            }


            context.SaveChanges();
        }

       
    }
}
