namespace CollectDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makeidpublic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserBaseballCardCollections", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserBaseballCardCollections", "UserID");
        }
    }
}
