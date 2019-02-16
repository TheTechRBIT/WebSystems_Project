namespace CollectDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertcoachdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coaches",
                c => new
                    {
                        CoachID = c.Int(nullable: false, identity: true),
                        CoachName = c.String(),
                    })
                .PrimaryKey(t => t.CoachID);
            
            AddColumn("dbo.BaseballCards", "CoachID", c => c.Int(nullable: false));
            CreateIndex("dbo.BaseballCards", "CoachID");
            AddForeignKey("dbo.BaseballCards", "CoachID", "dbo.Coaches", "CoachID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BaseballCards", "CoachID", "dbo.Coaches");
            DropIndex("dbo.BaseballCards", new[] { "CoachID" });
            DropColumn("dbo.BaseballCards", "CoachID");
            DropTable("dbo.Coaches");
        }
    }
}
