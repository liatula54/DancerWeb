namespace DancerWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dancers1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dancers", "StudioAddress", c => c.String());
            AddColumn("dbo.Dancers", "StudioName", c => c.String());
            AddColumn("dbo.Dancers", "Password", c => c.String());
            AddColumn("dbo.Teachers", "Password", c => c.String());
            AlterColumn("dbo.Teachers", "CompanyAddress", c => c.String());
            AlterColumn("dbo.Teachers", "CompanyName", c => c.String());
            DropColumn("dbo.Dancers", "CompanyAddress");
            DropColumn("dbo.Dancers", "CompanyName");
            DropColumn("dbo.Teachers", "Level");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "Level", c => c.Int(nullable: false));
            AddColumn("dbo.Dancers", "CompanyName", c => c.String(nullable: false));
            AddColumn("dbo.Dancers", "CompanyAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "CompanyName", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "CompanyAddress", c => c.String(nullable: false));
            DropColumn("dbo.Teachers", "Password");
            DropColumn("dbo.Dancers", "Password");
            DropColumn("dbo.Dancers", "StudioName");
            DropColumn("dbo.Dancers", "StudioAddress");
        }
    }
}
