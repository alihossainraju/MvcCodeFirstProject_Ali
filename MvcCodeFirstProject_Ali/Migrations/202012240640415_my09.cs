namespace MvcCodeFirstProject_Ali.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class my09 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        FoodID = c.Int(nullable: false, identity: true),
                        FoodName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        ImagePath = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FoodID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Foods");
        }
    }
}
