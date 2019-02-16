namespace CollectDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaseballCards",
                c => new
                    {
                        BaseballCardID = c.Int(nullable: false, identity: true),
                        CardNumber = c.String(),
                        PlayerID = c.Int(nullable: false),
                        PlayerTeam = c.String(),
                        PlayerPosition = c.String(),
                        PlayerNumber = c.Int(nullable: false),
                        ManufacturerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BaseballCardID)
                .ForeignKey("dbo.ManufacturerInfoes", t => t.ManufacturerID, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.PlayerID, cascadeDelete: true)
                .Index(t => t.PlayerID)
                .Index(t => t.ManufacturerID);
            
            CreateTable(
                "dbo.ManufacturerInfoes",
                c => new
                    {
                        ManufacturerID = c.Int(nullable: false, identity: true),
                        ManufacturerName = c.String(),
                        ManufacturerYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ManufacturerID);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerID = c.Int(nullable: false, identity: true),
                        PlayerName = c.String(),
                    })
                .PrimaryKey(t => t.PlayerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BaseballCards", "PlayerID", "dbo.Players");
            DropForeignKey("dbo.BaseballCards", "ManufacturerID", "dbo.ManufacturerInfoes");
            DropIndex("dbo.BaseballCards", new[] { "ManufacturerID" });
            DropIndex("dbo.BaseballCards", new[] { "PlayerID" });
            DropTable("dbo.Players");
            DropTable("dbo.ManufacturerInfoes");
            DropTable("dbo.BaseballCards");
        }
    }
}
