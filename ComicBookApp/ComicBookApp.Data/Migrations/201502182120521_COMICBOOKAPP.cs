namespace ComicBookApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class COMICBOOKAPP : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comics",
                c => new
                    {
                        ComicId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        Cover = c.String(),
                        StudioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ComicId)
                .ForeignKey("dbo.Studios", t => t.StudioId, cascadeDelete: true)
                .Index(t => t.StudioId);
            
            CreateTable(
                "dbo.Studios",
                c => new
                    {
                        StudioId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.StudioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comics", "StudioId", "dbo.Studios");
            DropIndex("dbo.Comics", new[] { "StudioId" });
            DropTable("dbo.Studios");
            DropTable("dbo.Comics");
        }
    }
}
