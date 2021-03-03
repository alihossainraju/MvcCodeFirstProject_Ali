namespace MvcCodeFirstProject_Ali.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class my5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reporters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Age = c.Int(nullable: false),
                        State = c.String(nullable: false, maxLength: 30),
                        Country = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reporters");
        }
    }
}
