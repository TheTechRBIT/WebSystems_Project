namespace CollectDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createusercollection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserBaseballCardCollections",
                c => new
                    {
                        CollectionCardID = c.Int(nullable: false, identity: true),
                        BaseballCardID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CollectionCardID)
                .ForeignKey("dbo.BaseballCards", t => t.BaseballCardID, cascadeDelete: true)
                .Index(t => t.BaseballCardID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserBaseballCardCollections", "BaseballCardID", "dbo.BaseballCards");
            DropIndex("dbo.UserBaseballCardCollections", new[] { "BaseballCardID" });
            DropTable("dbo.UserBaseballCardCollections");
        }
    }
}
