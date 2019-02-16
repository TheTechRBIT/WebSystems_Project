namespace CollectDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialA : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaseballTeams",
                c => new
                    {
                        BaseballTeamID = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                    })
                .PrimaryKey(t => t.BaseballTeamID);
            
            AddColumn("dbo.BaseballCards", "BaseballTeamID", c => c.Int(nullable: false));
            AddColumn("dbo.BaseballCards", "CardYear", c => c.Int(nullable: false));
            CreateIndex("dbo.BaseballCards", "BaseballTeamID");
            AddForeignKey("dbo.BaseballCards", "BaseballTeamID", "dbo.BaseballTeams", "BaseballTeamID", cascadeDelete: true);
            DropColumn("dbo.BaseballCards", "PlayerTeam");
            DropColumn("dbo.ManufacturerInfoes", "ManufacturerYear");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ManufacturerInfoes", "ManufacturerYear", c => c.Int(nullable: false));
            AddColumn("dbo.BaseballCards", "PlayerTeam", c => c.String());
            DropForeignKey("dbo.BaseballCards", "BaseballTeamID", "dbo.BaseballTeams");
            DropIndex("dbo.BaseballCards", new[] { "BaseballTeamID" });
            DropColumn("dbo.BaseballCards", "CardYear");
            DropColumn("dbo.BaseballCards", "BaseballTeamID");
            DropTable("dbo.BaseballTeams");
        }
    }
}
