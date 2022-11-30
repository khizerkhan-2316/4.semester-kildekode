namespace Lesson8.Migrations
{
    using Lesson8.DAL;
    using Lesson8.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Windows.Documents;

    internal sealed class Configuration : DbMigrationsConfiguration<Lesson8.DAL.BookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Lesson8.DAL.BookContext";
        }

        protected override void Seed(Lesson8.DAL.BookContext context)
        {

      

        }
    }
}
