namespace _11a_ShoeShop_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShoeSize = c.Int(nullable: false),
                        ShoeType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShoeTypes", t => t.ShoeType_Id)
                .Index(t => t.ShoeType_Id);
            
            CreateTable(
                "dbo.ShoeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shoes", "ShoeType_Id", "dbo.ShoeTypes");
            DropIndex("dbo.Shoes", new[] { "ShoeType_Id" });
            DropTable("dbo.ShoeTypes");
            DropTable("dbo.Shoes");
        }
    }
}
