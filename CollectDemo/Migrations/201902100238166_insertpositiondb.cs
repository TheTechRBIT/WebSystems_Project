namespace CollectDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertpositiondb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionID = c.Int(nullable: false, identity: true),
                        PositionName = c.String(),
                    })
                .PrimaryKey(t => t.PositionID);
            
            AddColumn("dbo.BaseballCards", "PositionID", c => c.Int(nullable: false));
            CreateIndex("dbo.BaseballCards", "PositionID");
            AddForeignKey("dbo.BaseballCards", "PositionID", "dbo.Positions", "PositionID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BaseballCards", "PositionID", "dbo.Positions");
            DropIndex("dbo.BaseballCards", new[] { "PositionID" });
            DropColumn("dbo.BaseballCards", "PositionID");
            DropTable("dbo.Positions");
        }
    }
}
