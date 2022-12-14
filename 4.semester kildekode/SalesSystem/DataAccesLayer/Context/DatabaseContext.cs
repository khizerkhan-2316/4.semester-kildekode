using DataAccessLayer.Model;
using System.Data.Entity;

namespace DataAccessLayer.Context
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext() : base("DatabaseContext")
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }  

        public DbSet<SalesLine> SalesLines { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<PaymentOption> PaymentOptions { get; set; }

        public DbSet<Picture> Pictures { get; set; }    

        public DbSet<Feed> Feeds { get; set; }

        public DbSet<FeedAttribute> FeedAttributes { get; set; }

        public DbSet<FeedCategory> FeedCategories { get; set; }

    }
}
