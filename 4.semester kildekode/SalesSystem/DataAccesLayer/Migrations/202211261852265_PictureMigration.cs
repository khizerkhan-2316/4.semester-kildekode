namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PictureMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        PictureId = c.Guid(nullable: false),
                        Title = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.PictureId);
            
            AddColumn("dbo.Products", "Picture_PictureId", c => c.Guid());
            CreateIndex("dbo.Products", "Picture_PictureId");
            AddForeignKey("dbo.Products", "Picture_PictureId", "dbo.Pictures", "PictureId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Picture_PictureId", "dbo.Pictures");
            DropIndex("dbo.Products", new[] { "Picture_PictureId" });
            DropColumn("dbo.Products", "Picture_PictureId");
            DropTable("dbo.Pictures");
        }
    }
}
