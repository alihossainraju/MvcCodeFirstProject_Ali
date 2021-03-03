namespace MvcCodeFirstProject_Ali.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class my08 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Position = c.String(nullable: false, maxLength: 30),
                        Office = c.String(nullable: false, maxLength: 30),
                        Salary = c.Int(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
