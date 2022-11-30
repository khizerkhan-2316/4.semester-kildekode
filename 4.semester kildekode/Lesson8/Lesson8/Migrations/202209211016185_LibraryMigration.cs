namespace Lesson8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LibraryMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Libraries",
                c => new
                    {
                        LibraryID = c.Guid(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.LibraryID);
            
            AddColumn("dbo.Books", "LibraryID", c => c.Guid(nullable: true));
            CreateIndex("dbo.Books", "LibraryID");
            AddForeignKey("dbo.Books", "LibraryID", "dbo.Libraries", "LibraryID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "LibraryID", "dbo.Libraries");
            DropIndex("dbo.Books", new[] { "LibraryID" });
            DropColumn("dbo.Books", "LibraryID");
            DropTable("dbo.Libraries");
        }
    }
}
