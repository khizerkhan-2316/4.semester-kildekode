namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelValidationV2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Picture_PictureId", "dbo.Pictures");
            DropForeignKey("dbo.Sales", "Payment_PaymentId", "dbo.Payments");
            DropForeignKey("dbo.Sales", "PaymentOption_PaymentOptionId", "dbo.PaymentOptions");
            DropForeignKey("dbo.SalesLines", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.Products", new[] { "Picture_PictureId" });
            DropIndex("dbo.Sales", new[] { "Payment_PaymentId" });
            DropIndex("dbo.Sales", new[] { "PaymentOption_PaymentOptionId" });
            DropIndex("dbo.SalesLines", new[] { "Product_ProductId" });
            AlterColumn("dbo.Products", "Picture_PictureId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Pictures", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Pictures", "ImagePath", c => c.String(nullable: false));
            AlterColumn("dbo.PaymentOptions", "Name", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Sales", "Payment_PaymentId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Sales", "PaymentOption_PaymentOptionId", c => c.Guid(nullable: false));
            AlterColumn("dbo.SalesLines", "Product_ProductId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Products", "Picture_PictureId");
            CreateIndex("dbo.Sales", "Payment_PaymentId");
            CreateIndex("dbo.Sales", "PaymentOption_PaymentOptionId");
            CreateIndex("dbo.SalesLines", "Product_ProductId");
            AddForeignKey("dbo.Products", "Picture_PictureId", "dbo.Pictures", "PictureId", cascadeDelete: true);
            AddForeignKey("dbo.Sales", "Payment_PaymentId", "dbo.Payments", "PaymentId", cascadeDelete: true);
            AddForeignKey("dbo.Sales", "PaymentOption_PaymentOptionId", "dbo.PaymentOptions", "PaymentOptionId", cascadeDelete: true);
            AddForeignKey("dbo.SalesLines", "Product_ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesLines", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Sales", "PaymentOption_PaymentOptionId", "dbo.PaymentOptions");
            DropForeignKey("dbo.Sales", "Payment_PaymentId", "dbo.Payments");
            DropForeignKey("dbo.Products", "Picture_PictureId", "dbo.Pictures");
            DropIndex("dbo.SalesLines", new[] { "Product_ProductId" });
            DropIndex("dbo.Sales", new[] { "PaymentOption_PaymentOptionId" });
            DropIndex("dbo.Sales", new[] { "Payment_PaymentId" });
            DropIndex("dbo.Products", new[] { "Picture_PictureId" });
            AlterColumn("dbo.SalesLines", "Product_ProductId", c => c.Guid());
            AlterColumn("dbo.Sales", "PaymentOption_PaymentOptionId", c => c.Guid());
            AlterColumn("dbo.Sales", "Payment_PaymentId", c => c.Guid());
            AlterColumn("dbo.PaymentOptions", "Name", c => c.String());
            AlterColumn("dbo.Pictures", "ImagePath", c => c.String());
            AlterColumn("dbo.Pictures", "Title", c => c.String());
            AlterColumn("dbo.Products", "Picture_PictureId", c => c.Guid());
            CreateIndex("dbo.SalesLines", "Product_ProductId");
            CreateIndex("dbo.Sales", "PaymentOption_PaymentOptionId");
            CreateIndex("dbo.Sales", "Payment_PaymentId");
            CreateIndex("dbo.Products", "Picture_PictureId");
            AddForeignKey("dbo.SalesLines", "Product_ProductId", "dbo.Products", "ProductId");
            AddForeignKey("dbo.Sales", "PaymentOption_PaymentOptionId", "dbo.PaymentOptions", "PaymentOptionId");
            AddForeignKey("dbo.Sales", "Payment_PaymentId", "dbo.Payments", "PaymentId");
            AddForeignKey("dbo.Products", "Picture_PictureId", "dbo.Pictures", "PictureId");
        }
    }
}
