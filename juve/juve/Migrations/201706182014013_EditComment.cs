namespace juve.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditComment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "news_NewsId", "dbo.News");
            DropIndex("dbo.Comments", new[] { "news_NewsId" });
            RenameColumn(table: "dbo.Comments", name: "news_NewsId", newName: "NewsId");
            AddColumn("dbo.Comments", "Login", c => c.String());
            AlterColumn("dbo.Comments", "NewsId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "NewsId");
            AddForeignKey("dbo.Comments", "NewsId", "dbo.News", "NewsId", cascadeDelete: true);
            DropColumn("dbo.Comments", "User_Email");
            DropColumn("dbo.Comments", "User_Password");
            DropColumn("dbo.Comments", "User_RememberMe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "User_RememberMe", c => c.Boolean(nullable: false));
            AddColumn("dbo.Comments", "User_Password", c => c.String(nullable: false));
            AddColumn("dbo.Comments", "User_Email", c => c.String(nullable: false));
            DropForeignKey("dbo.Comments", "NewsId", "dbo.News");
            DropIndex("dbo.Comments", new[] { "NewsId" });
            AlterColumn("dbo.Comments", "NewsId", c => c.Int());
            DropColumn("dbo.Comments", "Login");
            RenameColumn(table: "dbo.Comments", name: "NewsId", newName: "news_NewsId");
            CreateIndex("dbo.Comments", "news_NewsId");
            AddForeignKey("dbo.Comments", "news_NewsId", "dbo.News", "NewsId");
        }
    }
}
