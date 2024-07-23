namespace WebprojectCK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixcartpro : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "Product_productID", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "Product_productID" });
            DropColumn("dbo.Carts", "productID");
            RenameColumn(table: "dbo.Carts", name: "Product_productID", newName: "productID");
            AlterColumn("dbo.Carts", "productID", c => c.Int(nullable: false));
            AlterColumn("dbo.Carts", "productID", c => c.Int(nullable: false));
            CreateIndex("dbo.Carts", "productID");
            AddForeignKey("dbo.Carts", "productID", "dbo.Products", "productID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "productID", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "productID" });
            AlterColumn("dbo.Carts", "productID", c => c.Int());
            AlterColumn("dbo.Carts", "productID", c => c.Long(nullable: false));
            RenameColumn(table: "dbo.Carts", name: "productID", newName: "Product_productID");
            AddColumn("dbo.Carts", "productID", c => c.Long(nullable: false));
            CreateIndex("dbo.Carts", "Product_productID");
            AddForeignKey("dbo.Carts", "Product_productID", "dbo.Products", "productID");
        }
    }
}
