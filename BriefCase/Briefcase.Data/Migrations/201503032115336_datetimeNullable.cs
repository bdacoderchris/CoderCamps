namespace Briefcase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimeNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobStatus", "PhoneInterview", c => c.DateTime());
            AlterColumn("dbo.JobStatus", "FirstInterview", c => c.DateTime());
            AlterColumn("dbo.JobStatus", "SecondInterview", c => c.DateTime());
            AlterColumn("dbo.JobStatus", "FollowUp1", c => c.DateTime());
            AlterColumn("dbo.JobStatus", "FollowUp2", c => c.DateTime());
            AlterColumn("dbo.JobStatus", "FollowUp3", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobStatus", "FollowUp3", c => c.DateTime(nullable: false));
            AlterColumn("dbo.JobStatus", "FollowUp2", c => c.DateTime(nullable: false));
            AlterColumn("dbo.JobStatus", "FollowUp1", c => c.DateTime(nullable: false));
            AlterColumn("dbo.JobStatus", "SecondInterview", c => c.DateTime(nullable: false));
            AlterColumn("dbo.JobStatus", "FirstInterview", c => c.DateTime(nullable: false));
            AlterColumn("dbo.JobStatus", "PhoneInterview", c => c.DateTime(nullable: false));
        }
    }
}
