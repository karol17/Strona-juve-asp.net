namespace juve.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtrybutyWalidacyjne : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Text", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "Text", c => c.String());
        }
    }
}
