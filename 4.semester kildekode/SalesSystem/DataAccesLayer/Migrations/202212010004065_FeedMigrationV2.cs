namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeedMigrationV2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeedAttributes",
                c => new
                    {
                        FeedAttributeId = c.Guid(nullable: false),
                        Attribute = c.String(),
                        Feed_FeedId = c.Guid(),
                    })
                .PrimaryKey(t => t.FeedAttributeId)
                .ForeignKey("dbo.Feeds", t => t.Feed_FeedId)
                .Index(t => t.Feed_FeedId);
            
            CreateTable(
                "dbo.FeedCategories",
                c => new
                    {
                        FeedCategoryId = c.Guid(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                        FeedCategoryName = c.String(nullable: false),
                        Feed_FeedId = c.Guid(),
                    })
                .PrimaryKey(t => t.FeedCategoryId)
                .ForeignKey("dbo.Feeds", t => t.Feed_FeedId)
                .Index(t => t.Feed_FeedId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeedCategories", "Feed_FeedId", "dbo.Feeds");
            DropForeignKey("dbo.FeedAttributes", "Feed_FeedId", "dbo.Feeds");
            DropIndex("dbo.FeedCategories", new[] { "Feed_FeedId" });
            DropIndex("dbo.FeedAttributes", new[] { "Feed_FeedId" });
            DropTable("dbo.FeedCategories");
            DropTable("dbo.FeedAttributes");
        }
    }
}
