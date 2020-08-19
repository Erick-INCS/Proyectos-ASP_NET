namespace CoffeStreet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Models : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ClientName = c.String(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Cost = c.Single(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Description = c.Int(nullable: false),
                        Type = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductTypes", t => t.Type)
                .Index(t => t.Type);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        Type = c.String(nullable: false, maxLength: 128),
                        Description = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Type);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "Type", "dbo.ProductTypes");
            DropIndex("dbo.Products", new[] { "Type" });
            DropIndex("dbo.Orders", new[] { "ProductId" });
            DropTable("dbo.ProductTypes");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
        }
    }
}
