namespace DancerWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dancers2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dancers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Dancers", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "Password", c => c.String());
            AlterColumn("dbo.Teachers", "Email", c => c.String());
            AlterColumn("dbo.Dancers", "Password", c => c.String());
            AlterColumn("dbo.Dancers", "Email", c => c.String());
        }
    }
}
