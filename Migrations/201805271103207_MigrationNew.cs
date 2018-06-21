namespace DancerWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationNew : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Teachers", newName: "Dancers");
            CreateTable(
                "dbo.GroupDancers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Dancers", "GroupDancersId", c => c.Int(nullable: false));
            AddColumn("dbo.Dancers", "Level", c => c.Int());
            CreateIndex("dbo.Dancers", "GroupDancersId");
            AddForeignKey("dbo.Dancers", "GroupDancersId", "dbo.GroupDancers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dancers", "GroupDancersId", "dbo.GroupDancers");
            DropIndex("dbo.Dancers", new[] { "GroupDancersId" });
            DropColumn("dbo.Dancers", "Level");
            DropColumn("dbo.Dancers", "GroupDancersId");
            DropTable("dbo.GroupDancers");
            RenameTable(name: "dbo.Dancers", newName: "Teachers");
        }
    }
}
