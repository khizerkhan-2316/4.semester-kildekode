using Lesson8.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8.DAL
{
    public class BookContext : DbContext
    {

        public BookContext() : base("Name=BookContext")
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Library> Libraries { get; set; }
    }
}
