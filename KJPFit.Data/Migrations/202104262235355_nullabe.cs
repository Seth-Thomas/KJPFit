namespace KJPFit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullabe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Exercise", "Sets", c => c.Int());
            AlterColumn("dbo.Exercise", "Reps", c => c.Int());
            AlterColumn("dbo.Exercise", "Weight", c => c.Int());
            AlterColumn("dbo.Exercise", "DistanceInMiles", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exercise", "DistanceInMiles", c => c.Int(nullable: false));
            AlterColumn("dbo.Exercise", "Weight", c => c.Int(nullable: false));
            AlterColumn("dbo.Exercise", "Reps", c => c.Int(nullable: false));
            AlterColumn("dbo.Exercise", "Sets", c => c.Int(nullable: false));
        }
    }
}
