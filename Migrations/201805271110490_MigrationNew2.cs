namespace DancerWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationNew2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Dancers", newName: "Teachers");
            DropIndex("dbo.Teachers", new[] { "GroupDancersId" });
            CreateTable(
                    "dbo.Dancers",
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
                        //GroupDancersId = c.Int(nullable: false),
                        //TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
                //.ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                //.Index(t => t.GroupDancersId)
                //.Index(t => t.TeacherId);
            
            AlterColumn("dbo.Teachers", "Level", c => c.Int(nullable: false));
            DropColumn("dbo.Teachers", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Dancers", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Dancers", new[] { "TeacherId" });
            DropIndex("dbo.Dancers", new[] { "GroupDancersId" });
            AlterColumn("dbo.Teachers", "Level", c => c.Int());
            DropTable("dbo.Dancers");
            CreateIndex("dbo.Teachers", "GroupDancersId");
            RenameTable(name: "dbo.Teachers", newName: "Dancers");
        }
    }
}
