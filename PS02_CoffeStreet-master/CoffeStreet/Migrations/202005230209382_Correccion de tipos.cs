namespace CoffeStreet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correcciondetipos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductTypes", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductTypes", "Description", c => c.Int(nullable: false));
        }
    }
}
