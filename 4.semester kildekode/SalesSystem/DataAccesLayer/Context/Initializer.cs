using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataAccessLayer.Context
{
	internal class Initializer : CreateDatabaseIfNotExists<DatabaseContext> // 2 other strategies: 1. DropCreateDatabaseAlways and 2.DropCreateDatabaseIfModelChanges
	{



		protected override void Seed(DatabaseContext context)
		{


			Picture picture = new Picture();

			Product product = new Product("MySQL - All you need to know", "This book is an excellent guide for you on how to use SQL (Structured Query Language) in relational database management systems.", 699, 500);
			Product product1 = new Product("Macbook Pro M1", "Denne nye M1'er er suveræn både til studie og gaming", 20000, 18999);
			Product product2 = new Product("Iphone X", "iPhone X. Du bliver glad for at se dén. Den bliver glad for at se dig.\nBrugt telefon\nMinimal slidtage\nTeknisk og funktionelt som et nyt produkt", 3000, 2990);

			Product product3 = new Product
			("Harry Potter og de vises sten", "Første bind af den eventyrlige og spændende serie om troldmandsaspiranten Harry Potter og hans fantastiske oplevelser.", 600, 400);

			Product product4 = new Product("Lenovo IdeaPad 5I GEN 7 (15' Intel)", "Fantastisk ydeevne og elegant design", 10000, 8500);
			Product product5 = new Product("Oneplus 10 Pro", "iPhone X. OnePlus 10 Pro er 10. generation af fortsat udvikling af teknologi, der giver mening, med støtte fra vores community.", 7000, null);

			Product product6 = new Product("Olsen Banden - For Evigt", "Den udødelige forbrydertrio med Egon, Benny og Kjeld har underholdt danskerne i et halvt århundrede.", 350, 304);
			Product product7 = new Product("Asus Vivobook 15 Pro OLED", "Uanset om du skal browse, arbejde eller underholdes gør Vivobook Pro 15 OLED det til en leg, takket være den hurtige Intel® Core™ i5-11300H processor.", 6500, null);
			Product product8 = new Product("Samsung galaxy S22", "Velkommen til Samsungs flagskibs model Galaxy S22. Samsung sætter endnu engang nye højder for standarden.", 3800, 3500);


			Category book = new Category("Bøger");
			Category mobile = new Category("Mobiltelefoner");
			Category laptops = new Category("Bærbare");

			Feed xml = new Feed
			{
				FeedId = Guid.NewGuid(),
				Title = "Customized XML Feed",
				Description = "Dette er et XML Feed hvor alle attributter og kategorier er valgt, uden en limit. Dette vil sige at alle produkter i alle kategorier, med alle produkt attributter kommer i xml format, som kan bruges til bl.a. annoncering.",
				Format = "xml",
				Limit = null,
				Attributes = new List<FeedAttribute>()
				{
					new FeedAttribute("ProductId"),
					new FeedAttribute("Name"),
					new FeedAttribute("Description"),
					new FeedAttribute("Price"),
					new FeedAttribute("SalePrice"),
					new FeedAttribute("Category"),
					new FeedAttribute("Picture")




				},
				Categories = new List<FeedCategory>()
				{
				   new FeedCategory(book.CategoryId, book.Name),
				   new FeedCategory(mobile.CategoryId, mobile.Name),
				   new FeedCategory(laptops.CategoryId, laptops.Name)

				},
				BuildDateTime = DateTime.Now,
			};


			xml.Link = $"https://localhost:44357/api/Feed/Details/{xml.FeedId}";



			Feed json = new Feed
			{
				FeedId = Guid.NewGuid(),
				Title = "Customized JSON Feed",
				Description = "Dette er et JSON Feed hvor alle attributter og kategorier er valgt, uden en limit. Dette vil sige at alle produkter i alle kategorier, med alle produkt attributter kommer i xml format, som kan bruges til bl.a. annoncering.",
				Format = "json",
				Limit = null,
				Attributes = new List<FeedAttribute>()
				{
					new FeedAttribute("ProductId"),
					new FeedAttribute("Name"),
					new FeedAttribute("Description"),
					new FeedAttribute("Price"),
					new FeedAttribute("SalePrice"),
					new FeedAttribute("Category"),
					new FeedAttribute("Picture")




				},
				Categories = new List<FeedCategory>()
				{
				   new FeedCategory(book.CategoryId, book.Name),
				   new FeedCategory(mobile.CategoryId, mobile.Name),
				   new FeedCategory(laptops.CategoryId, laptops.Name)

				},
				BuildDateTime = DateTime.Now,
			};


			json.Link = $"https://localhost:44357/api/Feed/Details/{json.FeedId}";


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
			product2.Category = mobile;
			product3.Category = book;
			product4.Category = laptops;
			product5.Category = mobile;
			product6.Category = book;
			product7.Category = laptops;
			product8.Category = mobile;

			product.Picture = picture;
			product1.Picture = picture;
			product2.Picture = picture;
			product3.Picture = picture;
			product4.Picture = picture;
			product5.Picture = picture;
			product6.Picture = picture;
			product7.Picture = picture;
			product8.Picture = picture;

			book.Products.Add(product);
			laptops.Products.Add(product1);
			mobile.Products.Add(product2);
			book.Products.Add(product3);
			laptops.Products.Add(product4);
			mobile.Products.Add(product5);
			book.Products.Add(product6);
			laptops.Products.Add(product7);
			mobile.Products.Add(product8);

			context.Pictures.Add(picture);

			context.Categories.Add(book);
			context.Categories.Add(mobile);
			context.Categories.Add(laptops);

			context.Products.Add(product);
			context.Products.Add(product1);
			context.Products.Add(product2);
			context.Products.Add(product3);
			context.Products.Add(product4);
			context.Products.Add(product5);
			context.Products.Add(product6);
			context.Products.Add(product7);
			context.Products.Add(product8);



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


			context.Feeds.Add(xml);
			context.Feeds.Add(json);


			context.SaveChanges();
		}


	}
}
