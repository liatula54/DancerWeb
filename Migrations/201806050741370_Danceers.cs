namespace DancerWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Danceers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dancers", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Dancers", "GroupDancersId", "dbo.GroupDancers");
            DropIndex("dbo.Dancers", new[] { "GroupDancersId" });
            DropIndex("dbo.Dancers", new[] { "TeacherId" });
            RenameColumn(table: "dbo.Dancers", name: "GroupDancersId", newName: "GroupDancers_Id");
            AlterColumn("dbo.Dancers", "GroupDancers_Id", c => c.Int());
            CreateIndex("dbo.Dancers", "GroupDancers_Id");
            AddForeignKey("dbo.Dancers", "GroupDancers_Id", "dbo.GroupDancers", "Id");
            DropColumn("dbo.Dancers", "TeacherId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dancers", "TeacherId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Dancers", "GroupDancers_Id", "dbo.GroupDancers");
            DropIndex("dbo.Dancers", new[] { "GroupDancers_Id" });
            AlterColumn("dbo.Dancers", "GroupDancers_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Dancers", name: "GroupDancers_Id", newName: "GroupDancersId");
            CreateIndex("dbo.Dancers", "TeacherId");
            CreateIndex("dbo.Dancers", "GroupDancersId");
            AddForeignKey("dbo.Dancers", "GroupDancersId", "dbo.GroupDancers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Dancers", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
        }
    }
}
