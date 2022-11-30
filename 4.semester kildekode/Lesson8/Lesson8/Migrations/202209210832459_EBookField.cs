namespace Lesson8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EBookField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "EBook", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "EBook");
        }
    }
}
