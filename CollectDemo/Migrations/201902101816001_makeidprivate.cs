namespace CollectDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makeidprivate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserBaseballCardCollections", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserBaseballCardCollections", "UserID", c => c.String());
        }
    }
}
