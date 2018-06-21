namespace DancerWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dancers3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dancers", "Password", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Teachers", "Password", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Dancers", "Password", c => c.String(nullable: false));
        }
    }
}
