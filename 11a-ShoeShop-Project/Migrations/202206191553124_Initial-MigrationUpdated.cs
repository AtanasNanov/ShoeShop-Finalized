namespace _11a_ShoeShop_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrationUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shoes", "ShoeType_Id", "dbo.ShoeTypes");
            DropIndex("dbo.Shoes", new[] { "ShoeType_Id" });
            RenameColumn(table: "dbo.Shoes", name: "ShoeType_Id", newName: "ShoeTypeId");
            AlterColumn("dbo.Shoes", "ShoeTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Shoes", "ShoeTypeId");
            AddForeignKey("dbo.Shoes", "ShoeTypeId", "dbo.ShoeTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shoes", "ShoeTypeId", "dbo.ShoeTypes");
            DropIndex("dbo.Shoes", new[] { "ShoeTypeId" });
            AlterColumn("dbo.Shoes", "ShoeTypeId", c => c.Int());
            RenameColumn(table: "dbo.Shoes", name: "ShoeTypeId", newName: "ShoeType_Id");
            CreateIndex("dbo.Shoes", "ShoeType_Id");
            AddForeignKey("dbo.Shoes", "ShoeType_Id", "dbo.ShoeTypes", "Id");
        }
    }
}
