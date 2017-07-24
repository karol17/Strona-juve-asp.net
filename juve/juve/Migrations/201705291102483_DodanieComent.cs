namespace juve.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodanieComent : DbMigration
    {
        public override void Up()
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
                        News_NewsId = c.Int(),
                    })
                .PrimaryKey(t => t.ComentId)
                .ForeignKey("dbo.News", t => t.News_NewsId)
                .Index(t => t.News_NewsId);
            
        }

        public override void Down()
        {
            DropForeignKey("dbo.Coments", "News_NewsId", "dbo.News");
            DropIndex("dbo.Coments", new[] { "News_NewsId" });
            DropTable("dbo.Coments");
        }
    }
}
