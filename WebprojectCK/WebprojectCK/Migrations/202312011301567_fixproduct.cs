namespace WebprojectCK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixproduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "productID", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "productID" });
            DropPrimaryKey("dbo.Products");
            AddColumn("dbo.Carts", "Product_productID", c => c.Int());
            AlterColumn("dbo.Products", "productID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Products", "productID");
            CreateIndex("dbo.Carts", "Product_productID");
            AddForeignKey("dbo.Carts", "Product_productID", "dbo.Products", "productID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "Product_productID", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "Product_productID" });
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Products", "productID", c => c.Long(nullable: false, identity: true));
            DropColumn("dbo.Carts", "Product_productID");
            AddPrimaryKey("dbo.Products", "productID");
            CreateIndex("dbo.Carts", "productID");
            AddForeignKey("dbo.Carts", "productID", "dbo.Products", "productID", cascadeDelete: true);
        }
    }
}
