namespace juve.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PowiazanieNewsZComent : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Coments", new[] { "News_NewsId" });
            CreateIndex("dbo.Coments", "news_NewsId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Coments", new[] { "news_NewsId" });
            CreateIndex("dbo.Coments", "News_NewsId");
        }
    }
}
