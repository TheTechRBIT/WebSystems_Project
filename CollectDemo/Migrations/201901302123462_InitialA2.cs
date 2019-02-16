namespace CollectDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialA2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BaseballCards", "BaseballTeamID", "dbo.BaseballTeams");
            DropIndex("dbo.BaseballCards", new[] { "BaseballTeamID" });
            AddColumn("dbo.BaseballCards", "Team", c => c.String());
            DropColumn("dbo.BaseballCards", "BaseballTeamID");
            DropTable("dbo.BaseballTeams");
        }
        
        public override void Down()
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
            DropColumn("dbo.BaseballCards", "Team");
            CreateIndex("dbo.BaseballCards", "BaseballTeamID");
            AddForeignKey("dbo.BaseballCards", "BaseballTeamID", "dbo.BaseballTeams", "BaseballTeamID", cascadeDelete: true);
        }
    }
}
