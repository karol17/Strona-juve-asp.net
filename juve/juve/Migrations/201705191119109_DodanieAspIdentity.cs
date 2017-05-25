namespace juve.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodanieAspIdentity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_Imie", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_Nazwisko", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_Miasto", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_Telefon", c => c.String());
            DropColumn("dbo.Coments", "User_UserId");
            DropColumn("dbo.Coments", "User_FirstName");
            DropColumn("dbo.Coments", "User_LastName");
            DropColumn("dbo.Coments", "User_Login");
            DropColumn("dbo.Coments", "User_Password");
            DropColumn("dbo.Coments", "User_Email");
            DropColumn("dbo.Coments", "User_PhoneNumber");
            DropColumn("dbo.Coments", "User_Adres");
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_UserId");
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_FirstName");
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_LastName");
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_Login");
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_Password");
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_PhoneNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_Password", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_Login", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Coments", "User_Adres", c => c.String());
            AddColumn("dbo.Coments", "User_PhoneNumber", c => c.String());
            AddColumn("dbo.Coments", "User_Email", c => c.String());
            AddColumn("dbo.Coments", "User_Password", c => c.String());
            AddColumn("dbo.Coments", "User_Login", c => c.String());
            AddColumn("dbo.Coments", "User_LastName", c => c.String());
            AddColumn("dbo.Coments", "User_FirstName", c => c.String());
            AddColumn("dbo.Coments", "User_UserId", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_Telefon");
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_Miasto");
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_Nazwisko");
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_Imie");
        }
    }
}
