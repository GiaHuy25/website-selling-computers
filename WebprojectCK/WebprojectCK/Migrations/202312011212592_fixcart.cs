namespace WebprojectCK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixcart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "UserId", "dbo.Users");
            DropIndex("dbo.Carts", new[] { "UserId" });
            DropColumn("dbo.Carts", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Carts", "UserId");
            AddForeignKey("dbo.Carts", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
