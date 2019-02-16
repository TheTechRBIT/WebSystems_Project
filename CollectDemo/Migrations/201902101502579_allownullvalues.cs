namespace CollectDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allownullvalues : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BaseballCards", "CoachID", "dbo.Coaches");
            DropForeignKey("dbo.BaseballCards", "ManufacturerID", "dbo.ManufacturerInfoes");
            DropForeignKey("dbo.BaseballCards", "PlayerID", "dbo.Players");
            DropForeignKey("dbo.BaseballCards", "PositionID", "dbo.Positions");
            DropIndex("dbo.BaseballCards", new[] { "PlayerID" });
            DropIndex("dbo.BaseballCards", new[] { "CoachID" });
            DropIndex("dbo.BaseballCards", new[] { "PositionID" });
            DropIndex("dbo.BaseballCards", new[] { "ManufacturerID" });
            AlterColumn("dbo.BaseballCards", "PlayerID", c => c.Int());
            AlterColumn("dbo.BaseballCards", "CoachID", c => c.Int());
            AlterColumn("dbo.BaseballCards", "PositionID", c => c.Int());
            AlterColumn("dbo.BaseballCards", "ManufacturerID", c => c.Int());
            CreateIndex("dbo.BaseballCards", "PlayerID");
            CreateIndex("dbo.BaseballCards", "CoachID");
            CreateIndex("dbo.BaseballCards", "PositionID");
            CreateIndex("dbo.BaseballCards", "ManufacturerID");
            AddForeignKey("dbo.BaseballCards", "CoachID", "dbo.Coaches", "CoachID");
            AddForeignKey("dbo.BaseballCards", "ManufacturerID", "dbo.ManufacturerInfoes", "ManufacturerID");
            AddForeignKey("dbo.BaseballCards", "PlayerID", "dbo.Players", "PlayerID");
            AddForeignKey("dbo.BaseballCards", "PositionID", "dbo.Positions", "PositionID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BaseballCards", "PositionID", "dbo.Positions");
            DropForeignKey("dbo.BaseballCards", "PlayerID", "dbo.Players");
            DropForeignKey("dbo.BaseballCards", "ManufacturerID", "dbo.ManufacturerInfoes");
            DropForeignKey("dbo.BaseballCards", "CoachID", "dbo.Coaches");
            DropIndex("dbo.BaseballCards", new[] { "ManufacturerID" });
            DropIndex("dbo.BaseballCards", new[] { "PositionID" });
            DropIndex("dbo.BaseballCards", new[] { "CoachID" });
            DropIndex("dbo.BaseballCards", new[] { "PlayerID" });
            AlterColumn("dbo.BaseballCards", "ManufacturerID", c => c.Int(nullable: false));
            AlterColumn("dbo.BaseballCards", "PositionID", c => c.Int(nullable: false));
            AlterColumn("dbo.BaseballCards", "CoachID", c => c.Int(nullable: false));
            AlterColumn("dbo.BaseballCards", "PlayerID", c => c.Int(nullable: false));
            CreateIndex("dbo.BaseballCards", "ManufacturerID");
            CreateIndex("dbo.BaseballCards", "PositionID");
            CreateIndex("dbo.BaseballCards", "CoachID");
            CreateIndex("dbo.BaseballCards", "PlayerID");
            AddForeignKey("dbo.BaseballCards", "PositionID", "dbo.Positions", "PositionID", cascadeDelete: true);
            AddForeignKey("dbo.BaseballCards", "PlayerID", "dbo.Players", "PlayerID", cascadeDelete: true);
            AddForeignKey("dbo.BaseballCards", "ManufacturerID", "dbo.ManufacturerInfoes", "ManufacturerID", cascadeDelete: true);
            AddForeignKey("dbo.BaseballCards", "CoachID", "dbo.Coaches", "CoachID", cascadeDelete: true);
        }
    }
}
