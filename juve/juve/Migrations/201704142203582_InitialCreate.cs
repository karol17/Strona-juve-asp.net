namespace juve.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coments",
                c => new
                    {
                        ComentId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        User_UserId = c.Int(),
                        News_NewsId = c.Int(),
                    })
                .PrimaryKey(t => t.ComentId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .ForeignKey("dbo.News", t => t.News_NewsId)
                .Index(t => t.User_UserId)
                .Index(t => t.News_NewsId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Adres = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Image = c.String(),
                        Header = c.String(),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.NewsId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Number = c.Int(nullable: false),
                        BirthDay = c.DateTime(nullable: false),
                        Photo = c.String(),
                        Position = c.Int(nullable: false),
                        GoalCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Coments", "News_NewsId", "dbo.News");
            DropForeignKey("dbo.Coments", "User_UserId", "dbo.Users");
            DropIndex("dbo.Coments", new[] { "News_NewsId" });
            DropIndex("dbo.Coments", new[] { "User_UserId" });
            DropTable("dbo.Players");
            DropTable("dbo.News");
            DropTable("dbo.Users");
            DropTable("dbo.Coments");
        }
    }
}
