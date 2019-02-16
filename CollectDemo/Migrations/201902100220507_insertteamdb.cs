namespace CollectDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertteamdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamID = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                    })
                .PrimaryKey(t => t.TeamID);
            
            AddColumn("dbo.BaseballCards", "TeamID", c => c.Int(nullable: false));
            CreateIndex("dbo.BaseballCards", "TeamID");
            AddForeignKey("dbo.BaseballCards", "TeamID", "dbo.Teams", "TeamID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BaseballCards", "TeamID", "dbo.Teams");
            DropIndex("dbo.BaseballCards", new[] { "TeamID" });
            DropColumn("dbo.BaseballCards", "TeamID");
            DropTable("dbo.Teams");
        }
    }
}
