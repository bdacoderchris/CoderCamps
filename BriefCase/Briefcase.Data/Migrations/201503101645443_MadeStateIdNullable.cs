namespace Briefcase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeStateIdNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "StateId", "dbo.States");
            DropIndex("dbo.Addresses", new[] { "StateId" });
            AlterColumn("dbo.Addresses", "StateId", c => c.Int());
            CreateIndex("dbo.Addresses", "StateId");
            AddForeignKey("dbo.Addresses", "StateId", "dbo.States", "StateId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "StateId", "dbo.States");
            DropIndex("dbo.Addresses", new[] { "StateId" });
            AlterColumn("dbo.Addresses", "StateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Addresses", "StateId");
            AddForeignKey("dbo.Addresses", "StateId", "dbo.States", "StateId", cascadeDelete: true);
        }
    }
}
