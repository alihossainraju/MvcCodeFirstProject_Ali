namespace MvcCodeFirstProject_Ali.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class my4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Guides", "Password");
            DropColumn("dbo.Guides", "ConfirmPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Guides", "ConfirmPassword", c => c.String(nullable: false));
            AddColumn("dbo.Guides", "Password", c => c.String(nullable: false));
        }
    }
}
