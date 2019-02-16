namespace CollectDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class help : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BaseballCards", "CoachID", "dbo.Coaches");
            DropForeignKey("dbo.BaseballCards", "PositionID", "dbo.Positions");
            DropForeignKey("dbo.BaseballCards", "TeamID", "dbo.Teams");
            DropIndex("dbo.BaseballCards", new[] { "TeamID" });
            DropIndex("dbo.BaseballCards", new[] { "CoachID" });
            DropIndex("dbo.BaseballCards", new[] { "PositionID" });
            DropColumn("dbo.BaseballCards", "TeamID");
            DropColumn("dbo.BaseballCards", "CoachID");
            DropColumn("dbo.BaseballCards", "PositionID");
            DropTable("dbo.Coaches");
            DropTable("dbo.Positions");
            DropTable("dbo.Teams");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamID = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                    })
                .PrimaryKey(t => t.TeamID);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionID = c.Int(nullable: false, identity: true),
                        PositionName = c.String(),
                    })
                .PrimaryKey(t => t.PositionID);
            
            CreateTable(
                "dbo.Coaches",
                c => new
                    {
                        CoachID = c.Int(nullable: false, identity: true),
                        CoachName = c.String(),
                    })
                .PrimaryKey(t => t.CoachID);
            
            AddColumn("dbo.BaseballCards", "PositionID", c => c.Int(nullable: false));
            AddColumn("dbo.BaseballCards", "CoachID", c => c.Int(nullable: false));
            AddColumn("dbo.BaseballCards", "TeamID", c => c.Int(nullable: false));
            CreateIndex("dbo.BaseballCards", "PositionID");
            CreateIndex("dbo.BaseballCards", "CoachID");
            CreateIndex("dbo.BaseballCards", "TeamID");
            AddForeignKey("dbo.BaseballCards", "TeamID", "dbo.Teams", "TeamID", cascadeDelete: true);
            AddForeignKey("dbo.BaseballCards", "PositionID", "dbo.Positions", "PositionID", cascadeDelete: true);
            AddForeignKey("dbo.BaseballCards", "CoachID", "dbo.Coaches", "CoachID", cascadeDelete: true);
        }
    }
}
