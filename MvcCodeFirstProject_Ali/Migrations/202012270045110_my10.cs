namespace MvcCodeFirstProject_Ali.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class my10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Guid(nullable: false),
                        ProductName = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TravellerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Travellers", t => t.TravellerID, cascadeDelete: true)
                .Index(t => t.TravellerID);
            
            CreateTable(
                "dbo.Travellers",
                c => new
                    {
                        TravellerID = c.Guid(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TravellerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "TravellerID", "dbo.Travellers");
            DropIndex("dbo.Orders", new[] { "TravellerID" });
            DropTable("dbo.Travellers");
            DropTable("dbo.Orders");
        }
    }
}
