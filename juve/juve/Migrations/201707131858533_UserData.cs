namespace juve.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserData_FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserData_LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserData_Adres", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserData_City", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserData_PhoneNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserData_Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserData_Email");
            DropColumn("dbo.AspNetUsers", "UserData_PhoneNumber");
            DropColumn("dbo.AspNetUsers", "UserData_City");
            DropColumn("dbo.AspNetUsers", "UserData_Adres");
            DropColumn("dbo.AspNetUsers", "UserData_LastName");
            DropColumn("dbo.AspNetUsers", "UserData_FirstName");
        }
    }
}
