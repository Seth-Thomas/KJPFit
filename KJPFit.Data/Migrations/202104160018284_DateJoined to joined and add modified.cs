namespace KJPFit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateJoinedtojoinedandaddmodified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Joined", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.User", "Modified", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.User", "DateJoined");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "DateJoined", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.User", "Modified");
            DropColumn("dbo.User", "Joined");
        }
    }
}
