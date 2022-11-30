namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 40),
                        Description = c.String(nullable: false, maxLength: 1000),
                        Price = c.Double(nullable: false),
                        SalePrice = c.Double(),
                        Category_CategoryId = c.Guid(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.PaymentOptions",
                c => new
                    {
                        PaymentOptionId = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PaymentOptionId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Guid(nullable: false),
                        AmountPaid = c.Double(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SaleId = c.Guid(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        AmountReturned = c.Double(),
                        Discount = c.Double(),
                        SaleDate = c.DateTime(nullable: false),
                        Payment_PaymentId = c.Guid(),
                        PaymentOption_PaymentOptionId = c.Guid(),
                    })
                .PrimaryKey(t => t.SaleId)
                .ForeignKey("dbo.Payments", t => t.Payment_PaymentId)
                .ForeignKey("dbo.PaymentOptions", t => t.PaymentOption_PaymentOptionId)
                .Index(t => t.Payment_PaymentId)
                .Index(t => t.PaymentOption_PaymentOptionId);
            
            CreateTable(
                "dbo.SalesLines",
                c => new
                    {
                        SalesLineId = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        Product_ProductId = c.Guid(),
                        Sale_SaleId = c.Guid(),
                    })
                .PrimaryKey(t => t.SalesLineId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .ForeignKey("dbo.Sales", t => t.Sale_SaleId)
                .Index(t => t.Product_ProductId)
                .Index(t => t.Sale_SaleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesLines", "Sale_SaleId", "dbo.Sales");
            DropForeignKey("dbo.SalesLines", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Sales", "PaymentOption_PaymentOptionId", "dbo.PaymentOptions");
            DropForeignKey("dbo.Sales", "Payment_PaymentId", "dbo.Payments");
            DropForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.SalesLines", new[] { "Sale_SaleId" });
            DropIndex("dbo.SalesLines", new[] { "Product_ProductId" });
            DropIndex("dbo.Sales", new[] { "PaymentOption_PaymentOptionId" });
            DropIndex("dbo.Sales", new[] { "Payment_PaymentId" });
            DropIndex("dbo.Products", new[] { "Category_CategoryId" });
            DropTable("dbo.SalesLines");
            DropTable("dbo.Sales");
            DropTable("dbo.Payments");
            DropTable("dbo.PaymentOptions");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
