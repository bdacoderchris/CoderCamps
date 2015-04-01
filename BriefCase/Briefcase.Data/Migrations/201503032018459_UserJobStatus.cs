namespace Briefcase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserJobStatus : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserJobs", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.UserJobs", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.JobStatus", "UserJobId", "dbo.UserJobs");
            DropIndex("dbo.JobStatus", new[] { "UserJobId" });
            DropIndex("dbo.UserJobs", new[] { "UserId" });
            DropIndex("dbo.UserJobs", new[] { "JobId" });
            CreateTable(
                "dbo.UserJobStatus",
                c => new
                    {
                        UserJobStatusId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserJobStatusId)
                .ForeignKey("dbo.JobStatus", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.StatusId);
            
            AddColumn("dbo.JobStatus", "JobId", c => c.Int(nullable: false));
            CreateIndex("dbo.JobStatus", "JobId");
            AddForeignKey("dbo.JobStatus", "JobId", "dbo.Jobs", "JobId", cascadeDelete: true);
            DropColumn("dbo.JobStatus", "UserJobId");
            DropTable("dbo.UserJobs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserJobs",
                c => new
                    {
                        UserJobId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        JobId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserJobId);
            
            AddColumn("dbo.JobStatus", "UserJobId", c => c.Int(nullable: false));
            DropForeignKey("dbo.UserJobStatus", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserJobStatus", "StatusId", "dbo.JobStatus");
            DropForeignKey("dbo.JobStatus", "JobId", "dbo.Jobs");
            DropIndex("dbo.UserJobStatus", new[] { "StatusId" });
            DropIndex("dbo.UserJobStatus", new[] { "UserId" });
            DropIndex("dbo.JobStatus", new[] { "JobId" });
            DropColumn("dbo.JobStatus", "JobId");
            DropTable("dbo.UserJobStatus");
            CreateIndex("dbo.UserJobs", "JobId");
            CreateIndex("dbo.UserJobs", "UserId");
            CreateIndex("dbo.JobStatus", "UserJobId");
            AddForeignKey("dbo.JobStatus", "UserJobId", "dbo.UserJobs", "UserJobId", cascadeDelete: true);
            AddForeignKey("dbo.UserJobs", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.UserJobs", "JobId", "dbo.Jobs", "JobId", cascadeDelete: true);
        }
    }
}
