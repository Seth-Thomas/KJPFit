namespace KJPFit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedToWorkout : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workout", "Modified", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workout", "Modified");
        }
    }
}
