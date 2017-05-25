namespace juve.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuniecieComent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Coments", "News_NewsId", "dbo.News");
            DropIndex("dbo.Coments", new[] { "News_NewsId" });
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
                        News_NewsId = c.Int(),
                    })
                .PrimaryKey(t => t.ComentId);
            
            CreateIndex("dbo.Coments", "News_NewsId");
            AddForeignKey("dbo.Coments", "News_NewsId", "dbo.News", "NewsId");
        }
    }
}
