namespace DancerWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationNew5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Phone = c.Int(nullable: false),
                        CompanyAddress = c.String(nullable: false),
                        CompanyName = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Email = c.String(),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Dancers", "TeacherId", c => c.Int(nullable: false));
            CreateIndex("dbo.Dancers", "TeacherId");
            AddForeignKey("dbo.Dancers", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dancers", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Dancers", new[] { "TeacherId" });
            DropColumn("dbo.Dancers", "TeacherId");
            DropTable("dbo.Teachers");
        }
    }
}
