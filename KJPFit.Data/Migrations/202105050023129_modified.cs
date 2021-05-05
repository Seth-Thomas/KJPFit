namespace KJPFit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modified : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Workout", "Modified", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Workout", "Modified", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
