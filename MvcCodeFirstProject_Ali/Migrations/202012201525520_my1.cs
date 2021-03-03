namespace MvcCodeFirstProject_Ali.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class my1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Guides",
                c => new
                    {
                        GuideID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Age = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.Int(nullable: false),
                        Address = c.String(nullable: false),
                        VisitDate = c.DateTime(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GuideID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Guides");
        }
    }
}
