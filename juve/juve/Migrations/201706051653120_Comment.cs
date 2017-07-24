namespace juve.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Comment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Coments", "news_NewsId", "dbo.News");
            DropIndex("dbo.Coments", new[] { "news_NewsId" });
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        User_Email = c.String(nullable: false),
                        User_Password = c.String(nullable: false),
                        User_RememberMe = c.Boolean(nullable: false),
                        news_NewsId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.News", t => t.news_NewsId)
                .Index(t => t.news_NewsId);
            
            DropTable("dbo.Coments");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.Coments",
                c => new
                {
                    ComentId = c.Int(nullable: false, identity: true),
                    Text = c.String(),
                    User_Email = c.String(nullable: false),
                    User_Password = c.String(nullable: false),
                    User_RememberMe = c.Boolean(nullable: false),
                    news_NewsId = c.Int(),
                })
                .PrimaryKey(t => t.ComentId);

            DropForeignKey("dbo.Comments", "news_NewsId", "dbo.News");
            DropIndex("dbo.Comments", new[] { "news_NewsId" });
            DropTable("dbo.Comments");
            CreateIndex("dbo.Coments", "news_NewsId");
            AddForeignKey("dbo.Coments", "news_NewsId", "dbo.News", "NewsId");
        }
    }
}
