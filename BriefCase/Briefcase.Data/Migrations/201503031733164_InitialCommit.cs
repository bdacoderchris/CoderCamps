namespace Briefcase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCommit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        Zip = c.String(),
                        StateId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.StateId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                        StateAbbreviation = c.String(),
                    })
                .PrimaryKey(t => t.StateId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Image = c.Byte(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.CompanyContacts",
                c => new
                    {
                        PocId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        JobId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PocId)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: false)
                .Index(t => t.JobId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        JobKey = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.JobId);
            
            CreateTable(
                "dbo.JobStatus",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        Applied = c.Boolean(nullable: false),
                        PhoneInterview = c.DateTime(nullable: false),
                        FirstInterview = c.DateTime(nullable: false),
                        SecondInterview = c.DateTime(nullable: false),
                        Offer = c.Boolean(nullable: false),
                        FollowUp1 = c.DateTime(nullable: false),
                        FollowUp2 = c.DateTime(nullable: false),
                        FollowUp3 = c.DateTime(nullable: false),
                        Notes1 = c.String(),
                        Notes2 = c.String(),
                        PocId = c.Int(nullable: false),
                        UserJobId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StatusId)
                .ForeignKey("dbo.CompanyContacts", t => t.PocId, cascadeDelete: false)
                .ForeignKey("dbo.UserJobs", t => t.UserJobId, cascadeDelete: false)
                .Index(t => t.PocId)
                .Index(t => t.UserJobId);
            
            CreateTable(
                "dbo.UserJobs",
                c => new
                    {
                        UserJobId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        JobId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserJobId)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.JobId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Searches",
                c => new
                    {
                        SearchId = c.Int(nullable: false, identity: true),
                        StateId = c.Int(nullable: false),
                        SearchTerm = c.String(),
                    })
                .PrimaryKey(t => t.SearchId)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: false)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.UserSearches",
                c => new
                    {
                        UserSearchId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        SearchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserSearchId)
                .ForeignKey("dbo.Searches", t => t.SearchId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.SearchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSearches", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserSearches", "SearchId", "dbo.Searches");
            DropForeignKey("dbo.Searches", "StateId", "dbo.States");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.JobStatus", "UserJobId", "dbo.UserJobs");
            DropForeignKey("dbo.UserJobs", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserJobs", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.JobStatus", "PocId", "dbo.CompanyContacts");
            DropForeignKey("dbo.CompanyContacts", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Addresses", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Addresses", "StateId", "dbo.States");
            DropIndex("dbo.UserSearches", new[] { "SearchId" });
            DropIndex("dbo.UserSearches", new[] { "UserId" });
            DropIndex("dbo.Searches", new[] { "StateId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.UserJobs", new[] { "JobId" });
            DropIndex("dbo.UserJobs", new[] { "UserId" });
            DropIndex("dbo.JobStatus", new[] { "UserJobId" });
            DropIndex("dbo.JobStatus", new[] { "PocId" });
            DropIndex("dbo.CompanyContacts", new[] { "JobId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Addresses", new[] { "UserId" });
            DropIndex("dbo.Addresses", new[] { "StateId" });
            DropTable("dbo.UserSearches");
            DropTable("dbo.Searches");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.UserJobs");
            DropTable("dbo.JobStatus");
            DropTable("dbo.Jobs");
            DropTable("dbo.CompanyContacts");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.States");
            DropTable("dbo.Addresses");
        }
    }
}
