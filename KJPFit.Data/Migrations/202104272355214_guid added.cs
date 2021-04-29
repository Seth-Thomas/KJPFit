namespace KJPFit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class guidadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercise", "Category", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exercise", "Category");
        }
    }
}
