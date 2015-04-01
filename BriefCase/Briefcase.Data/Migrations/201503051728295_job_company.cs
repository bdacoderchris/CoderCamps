namespace Briefcase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class job_company : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Company", c => c.String());
            DropColumn("dbo.Jobs", "Snippet");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "Snippet", c => c.String());
            DropColumn("dbo.Jobs", "Company");
        }
    }
}
