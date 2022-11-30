using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
