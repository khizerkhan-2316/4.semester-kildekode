namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeedMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feeds",
                c => new
                    {
                        FeedId = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 80),
                        Description = c.String(nullable: false, maxLength: 1000),
                        Format = c.String(nullable: false, maxLength: 10),
                        Limit = c.Int(),
                        link = c.String(nullable: false, maxLength: 100),
                        BuildDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FeedId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Feeds");
        }
    }
}
