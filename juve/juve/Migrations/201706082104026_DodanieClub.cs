namespace juve.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodanieClub : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clubs",
                c => new
                    {
                        ClubId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Points = c.Int(nullable: false),
                        ScoredGoals = c.Int(nullable: false),
                        LostGoals = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClubId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clubs");
        }
    }
}
