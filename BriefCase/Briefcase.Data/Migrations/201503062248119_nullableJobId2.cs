namespace Briefcase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableJobId2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobStatus", "PocId", "dbo.CompanyContacts");
            DropIndex("dbo.JobStatus", new[] { "PocId" });
            AlterColumn("dbo.JobStatus", "PocId", c => c.Int());
            CreateIndex("dbo.JobStatus", "PocId");
            AddForeignKey("dbo.JobStatus", "PocId", "dbo.CompanyContacts", "PocId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobStatus", "PocId", "dbo.CompanyContacts");
            DropIndex("dbo.JobStatus", new[] { "PocId" });
            AlterColumn("dbo.JobStatus", "PocId", c => c.Int(nullable: false));
            CreateIndex("dbo.JobStatus", "PocId");
            AddForeignKey("dbo.JobStatus", "PocId", "dbo.CompanyContacts", "PocId", cascadeDelete: true);
        }
    }
}
