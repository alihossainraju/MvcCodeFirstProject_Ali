namespace MvcCodeFirstProject_Ali.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class my3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Hotels", "Total");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hotels", "Total", c => c.Int(nullable: false));
        }
    }
}
