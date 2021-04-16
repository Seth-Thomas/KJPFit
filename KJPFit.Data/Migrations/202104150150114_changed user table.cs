namespace KJPFit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedusertable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.User", "HeightInInches", c => c.Int(nullable: false));
            AddColumn("dbo.User", "DateJoined", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.User", "Height");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Height", c => c.Int(nullable: false));
            DropColumn("dbo.User", "DateJoined");
            DropColumn("dbo.User", "HeightInInches");
            DropColumn("dbo.User", "OwnerId");
        }
    }
}
