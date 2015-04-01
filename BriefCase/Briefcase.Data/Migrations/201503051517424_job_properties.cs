namespace Briefcase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class job_properties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Title", c => c.String());
            AddColumn("dbo.Jobs", "Snippet", c => c.String());
            AddColumn("dbo.Jobs", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "Location");
            DropColumn("dbo.Jobs", "Snippet");
            DropColumn("dbo.Jobs", "Title");
        }
    }
}
