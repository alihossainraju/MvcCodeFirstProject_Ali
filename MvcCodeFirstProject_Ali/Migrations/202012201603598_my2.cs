namespace MvcCodeFirstProject_Ali.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class my2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        HotelID = c.Int(nullable: false, identity: true),
                        HotelName = c.String(nullable: false, maxLength: 30),
                        TouristId = c.Int(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        RoomCharge = c.Int(nullable: false),
                        ServiceCharge = c.Int(nullable: false),
                        FoodCost = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HotelID)
                .ForeignKey("dbo.Tourists", t => t.TouristId, cascadeDelete: true)
                .Index(t => t.TouristId);
            
            CreateTable(
                "dbo.Tourists",
                c => new
                    {
                        TouristId = c.Int(nullable: false, identity: true),
                        TouristName = c.String(nullable: false, maxLength: 30),
                        RoomType = c.String(nullable: false),
                        Contact = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TouristId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hotels", "TouristId", "dbo.Tourists");
            DropIndex("dbo.Hotels", new[] { "TouristId" });
            DropTable("dbo.Tourists");
            DropTable("dbo.Hotels");
        }
    }
}
