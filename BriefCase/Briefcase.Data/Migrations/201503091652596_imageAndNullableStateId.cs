namespace Briefcase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageAndNullableStateId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "StateId", "dbo.States");
            DropIndex("dbo.Addresses", new[] { "StateId" });
            AlterColumn("dbo.Addresses", "StateId", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "Image", c => c.String());
            CreateIndex("dbo.Addresses", "StateId");
            AddForeignKey("dbo.Addresses", "StateId", "dbo.States", "StateId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "StateId", "dbo.States");
            DropIndex("dbo.Addresses", new[] { "StateId" });
            AlterColumn("dbo.AspNetUsers", "Image", c => c.Byte(nullable: false));
            AlterColumn("dbo.Addresses", "StateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Addresses", "StateId");
            AddForeignKey("dbo.Addresses", "StateId", "dbo.States", "StateId", cascadeDelete: true);
        }
    }
}
