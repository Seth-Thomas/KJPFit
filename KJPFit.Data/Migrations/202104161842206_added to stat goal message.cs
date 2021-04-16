namespace KJPFit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtostatgoalmessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stat", "GoalMessage", c => c.String());
            AlterColumn("dbo.Stat", "Weight", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stat", "Weight", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Stat", "GoalMessage");
        }
    }
}
