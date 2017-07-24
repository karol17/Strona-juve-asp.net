namespace juve.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsuniecieClub : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Clubs");
        }
        
        public override void Down()
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
    }
}
