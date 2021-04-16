namespace KJPFit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workoutupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workout", "IsFavorited", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workout", "IsFavorited");
        }
    }
}
