namespace DancerWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dancer444 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dancers", "CompanyAddress", c => c.String());
            AddColumn("dbo.Dancers", "CompanyName", c => c.String());
            AddColumn("dbo.Dancers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.Teachers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Phone = c.Int(nullable: false),
                        CompanyAddress = c.String(),
                        CompanyName = c.String(),
                        City = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Dancers", "Discriminator");
            DropColumn("dbo.Dancers", "CompanyName");
            DropColumn("dbo.Dancers", "CompanyAddress");
        }
    }
}
