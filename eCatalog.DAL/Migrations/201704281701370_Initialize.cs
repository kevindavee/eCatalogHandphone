namespace eCatalog.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Handphones",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        ProductDescription = c.String(),
                        SellPrice = c.Int(nullable: false),
                        BuyPrice = c.Int(),
                        Seen = c.Int(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                        BrandId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.ImagePaths",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Path = c.String(),
                        HandphoneId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Handphones", t => t.HandphoneId, cascadeDelete: true)
                .Index(t => t.HandphoneId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImagePaths", "HandphoneId", "dbo.Handphones");
            DropForeignKey("dbo.Handphones", "BrandId", "dbo.Brands");
            DropIndex("dbo.ImagePaths", new[] { "HandphoneId" });
            DropIndex("dbo.Handphones", new[] { "BrandId" });
            DropTable("dbo.ImagePaths");
            DropTable("dbo.Handphones");
            DropTable("dbo.Brands");
        }
    }
}
