namespace ReviewerAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUserUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameConsoles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CurrentGameSystem = c.Int(nullable: false),
                        GameID_GameID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Games", t => t.GameID_GameID)
                .Index(t => t.GameID_GameID);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Publisher = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        ReasonForGreatness = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.GameID);
            
            AddColumn("dbo.AspNetUsers", "CanEdit", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameConsoles", "GameID_GameID", "dbo.Games");
            DropIndex("dbo.GameConsoles", new[] { "GameID_GameID" });
            DropColumn("dbo.AspNetUsers", "CanEdit");
            DropTable("dbo.Games");
            DropTable("dbo.GameConsoles");
        }
    }
}
