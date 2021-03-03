namespace MvcCodeFirstProject_Ali.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class my07 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chefs",
                c => new
                    {
                        ChefID = c.Int(nullable: false, identity: true),
                        ChefName = c.String(),
                        EmailAddress = c.String(),
                        CellPhone = c.String(),
                        ContactAddress = c.String(),
                    })
                .PrimaryKey(t => t.ChefID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Chefs");
        }
    }
}
