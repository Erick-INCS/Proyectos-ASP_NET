namespace CoffeStreet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prd_desc_im_changed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImagePath", c => c.String());
            AlterColumn("dbo.Products", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Description", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "ImagePath");
        }
    }
}
