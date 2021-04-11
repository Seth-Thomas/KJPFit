namespace KJPFit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databasesetup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workout", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workout", "OwnerId");
        }
    }
}
