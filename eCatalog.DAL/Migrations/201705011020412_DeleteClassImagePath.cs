namespace eCatalog.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteClassImagePath : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImagePaths", "HandphoneId", "dbo.Handphones");
            DropIndex("dbo.ImagePaths", new[] { "HandphoneId" });
            AddColumn("dbo.Handphones", "ImageUrl", c => c.String());
            DropTable("dbo.ImagePaths");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ImagePaths",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Path = c.String(),
                        HandphoneId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Handphones", "ImageUrl");
            CreateIndex("dbo.ImagePaths", "HandphoneId");
            AddForeignKey("dbo.ImagePaths", "HandphoneId", "dbo.Handphones", "Id", cascadeDelete: true);
        }
    }
}
