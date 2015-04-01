using Briefcase.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace Briefcase.Data
{
    public class Seeder
    {
        public static void Seed(ApplicationDbContext db,
            bool users = true,
            bool roles = true,
            bool states = true,
            bool addresses = true,
            bool jobs = true,
            bool jobStatuses = true,
            bool contacts = true,
            bool userJobs = true,
            bool searchTerms = true,
            bool userSearch = true)
        {
            if (roles)
            {
                SeedRoles(db);
            }

            if (users)
            {
                SeedUsers(db);
            }

            if (states)
            {
                SeedStates(db);
            }

            if (addresses)
            {
                SeedAddresses(db);
            }

            if (jobs)
            {
                SeedJobs(db);
            }

            if (contacts)
            {
                SeedContacts(db);
            }

            if (jobStatuses)
            {
                SeedJobStatuses(db);
            }

            if (userJobs)
            {
                SeedUserJobStatuses(db);
            }

            if (searchTerms)
            {
                SeedSearchTerms(db);
            }

            if (userSearch)
            {
                SeedUserSearch(db);
            }
        }

        private static void SeedRoles(ApplicationDbContext db)
        {
            var store = new RoleStore<IdentityRole>(db);
            var manager = new RoleManager<IdentityRole>(store);

            if (!db.Roles.Any(u => u.Name == "User"))
            {
                manager.Create(new IdentityRole { Name = "User" });
            }
            db.SaveChanges();

            if (!db.Roles.Any(u => u.Name == "Admin"))
            {
                manager.Create(new IdentityRole { Name = "Admin" });
            }
            db.SaveChanges();

            if (!db.Roles.Any(u => u.Name == "Company"))
            {
                manager.Create(new IdentityRole { Name = "Company" });
            }
            db.SaveChanges();
        }

        private static void SeedUsers(ApplicationDbContext db)
        {
            var store = new UserStore<ApplicationUser>(db);
            var manager = new UserManager<ApplicationUser>(store);

            if (!db.Users.Any(u => u.UserName == "user1"))
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "user1",
                    Email = "user1@test.com",
                    EmailConfirmed = true,
                    FirstName = "user",
                    LastName = "one",
                    IsDeleted = false
                };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "User");
                db.SaveChanges();
            }

            if (!db.Users.Any(u => u.UserName == "user2"))
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "user2",
                    Email = "user2@test.com",
                    EmailConfirmed = true,
                    FirstName = "user",
                    LastName = "two",
                    IsDeleted = false
                };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "User");
                db.SaveChanges();
            }

            if (!db.Users.Any(u => u.UserName == "admin1"))
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "admin1",
                    Email = "admin1@test.com",
                    EmailConfirmed = true,
                    FirstName = "admin",
                    LastName = "one",
                    IsDeleted = false
                };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "Admin");
                db.SaveChanges();
            }

            if (!db.Users.Any(u => u.UserName == "admin2"))
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "admin2",
                    Email = "admin2@test.com",
                    EmailConfirmed = true,
                    FirstName = "admin",
                    LastName = "two",
                    IsDeleted = false
                };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "Admin");
                db.SaveChanges();
            }

            if (!db.Users.Any(u => u.UserName == "company1"))
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "company1",
                    Email = "company1@test.com",
                    EmailConfirmed = true,
                    FirstName = "company",
                    LastName = "one",
                    IsDeleted = false
                };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "Company");
                db.SaveChanges();
            }
        }

        private static void SeedSearchTerms(ApplicationDbContext db)
        {
            db.Searches.AddOrUpdate(s => s.SearchTerm,
                    new Search { SearchTerm = "web development", StateId = 7 },
                    new Search { SearchTerm = "javascript", StateId = 40 }
                );
            db.SaveChanges();
        }

        private static void SeedJobs(ApplicationDbContext db)
        {
            db.Jobs.AddOrUpdate(j => j.JobKey,
                    new Job { JobKey = "83400e947276d20b", IsActive = true, Title = "Javascript Developer", Location = "Houston, TX", Company = "HP" },
                    new Job { JobKey = "9d2c6535dc61d3b6", IsActive = true, Title = "Web Developer", Location = "Austin, TX", Company = "Coder For Rent" },
                    new Job { JobKey = "066f952bb6793d2b", IsActive = true, Title = "Web Dev", Location = "San Antonio, TX", Company = "HTC" }
                );
            db.SaveChanges();
        }

        private static void SeedUserSearch(ApplicationDbContext db)
        {
            var user1Id = db.Users.FirstOrDefault(u => u.UserName == "user1").Id;
            var user2Id = db.Users.FirstOrDefault(u => u.UserName == "user2").Id;

            db.UserSearches.AddOrUpdate(s => s.SearchId,
                    new UserSearch { SearchId = 1, UserId = user1Id },
                    new UserSearch { SearchId = 2, UserId = user2Id }
                );
            db.SaveChanges();
        }

        private static void SeedJobStatuses(ApplicationDbContext db)
        {
            var poc1Id = db.Contacs.FirstOrDefault(p => p.PocId == 1).PocId;
            var poc2Id = db.Contacs.FirstOrDefault(p => p.PocId == 2).PocId;
            var poc3Id = db.Contacs.FirstOrDefault(p => p.PocId == 3).PocId;
            var job1Id = db.Jobs.FirstOrDefault(j => j.JobId == 1).JobId;
            var job2Id = db.Jobs.FirstOrDefault(j => j.JobId == 2).JobId;

            db.JobStatuses.AddOrUpdate(j => j.PocId,
                    new JobStatus { IsDeleted = false, Applied = false, JobId = job1Id },
                    new JobStatus { IsDeleted = false, Applied = false, JobId = job2Id },
                    new JobStatus { IsDeleted = false, Applied = false, JobId = job2Id }
                );
            db.SaveChanges();
        }

        private static void SeedUserJobStatuses(ApplicationDbContext db)
        {
            
            var user1Id = db.Users.FirstOrDefault(u => u.UserName == "user1").Id;
            var user2Id = db.Users.FirstOrDefault(u => u.UserName == "user2").Id;

            db.UserJobStatuses.AddOrUpdate(u => u.UserJobStatusId,
                    new UserJobStatus { UserId = user1Id, StatusId = 1 },
                    new UserJobStatus { UserId = user1Id, StatusId = 1 },
                    new UserJobStatus { UserId = user2Id, StatusId = 3 }
                );
        }

        private static void SeedContacts(ApplicationDbContext db)
        {
            var job1Id = db.Jobs.FirstOrDefault(j => j.JobId == 1).JobId;
            var job2Id = db.Jobs.FirstOrDefault(j => j.JobId == 2).JobId;
            var job3Id = db.Jobs.FirstOrDefault(j => j.JobId == 3).JobId;

            db.Contacs.AddOrUpdate(c => c.JobId,
                    new CompanyContact { IsDeleted = false, PhoneNumber = "555-555-5555", Email = "1@gmail.com", FirstName = "terri", LastName = "tate", JobId = 1 },
                    new CompanyContact { IsDeleted = false, PhoneNumber = "555-555-5555", Email = "2@gmail.com", FirstName = "ricky", LastName = "richardson", JobId = 2 },
                    new CompanyContact { IsDeleted = false, PhoneNumber = "555-555-5555", Email = "3@gmail.com", FirstName = "samuel", LastName = "samson", JobId = 3 }
                );
            db.SaveChanges();
        }

        private static void SeedAddresses(ApplicationDbContext db)
        {
            var user1Id = db.Users.FirstOrDefault(u => u.UserName == "user1").Id;
            var user2Id = db.Users.FirstOrDefault(u => u.UserName == "user2").Id;

            db.Addresses.AddOrUpdate(a => a.Street1,
                    new Address { IsDeleted = false, City = "Houston", StateId = 8, Street1 = "123 Mockingbird Ln.", UserId = user1Id, Zip = "90210" },
                    new Address { IsDeleted = false, City = "Salt Lake", StateId = 10, Street1 = "1090 north.", UserId = user2Id, Zip = "84117" },
                    new Address { IsDeleted = false, City = "Los Angeles", StateId = 45, Street1 = "1222 south", UserId = user2Id, Zip = "73883" }
                );
            db.SaveChanges();
        }

        private static void SeedStates(ApplicationDbContext db)
        {
            db.States.AddOrUpdate(s => s.StateName,
                new State { StateName = "Alabama", StateAbbreviation = "AL" }, new State { StateName = "Alaska", StateAbbreviation = "AK" }, new State { StateName = "Arizona", StateAbbreviation = "AR" },
                new State { StateName = "California", StateAbbreviation = "CA" }, new State { StateName = "Colorado", StateAbbreviation = "CO" }, new State { StateName = "Connecticut", StateAbbreviation = "CT" },
                new State { StateName = "Delaware", StateAbbreviation = "DE" }, new State { StateName = "District of Columbia", StateAbbreviation = "DC" }, new State { StateName = "Florida", StateAbbreviation = "FL" },
                new State { StateName = "Georgia", StateAbbreviation = "GA" }, new State { StateName = "Hawaii", StateAbbreviation = "HI" }, new State { StateName = "Idaho", StateAbbreviation = "ID" },
                new State { StateName = "Illinois", StateAbbreviation = "IL" }, new State { StateName = "Indiana", StateAbbreviation = "IN" }, new State { StateName = "Iowa", StateAbbreviation = "IA" },
                new State { StateName = "Kansas", StateAbbreviation = "KS" }, new State { StateName = "Arkansas", StateAbbreviation = "AK" }, new State { StateName = "Kentucky", StateAbbreviation = "KY" },
                new State { StateName = "Louisiana", StateAbbreviation = "LA" }, new State { StateName = "Maine", StateAbbreviation = "ME" }, new State { StateName = "MaryLand", StateAbbreviation = "MD" },
                new State { StateName = "Massachusetts", StateAbbreviation = "MA" }, new State { StateName = "Michigan", StateAbbreviation = "MI" }, new State { StateName = "Minnesota", StateAbbreviation = "MN" },
                new State { StateName = "Mississippi", StateAbbreviation = "MS" }, new State { StateName = "Missouri", StateAbbreviation = "MO" }, new State { StateName = "Montana", StateAbbreviation = "MT" },
                new State { StateName = "Nebraska", StateAbbreviation = "NE" }, new State { StateName = "Nevada", StateAbbreviation = "NV" }, new State { StateName = "New Hampshire", StateAbbreviation = "NH" },
                new State { StateName = "New Jersey", StateAbbreviation = "NJ" }, new State { StateName = "New Mexico", StateAbbreviation = "NM" }, new State { StateName = "New York", StateAbbreviation = "NY" },
                new State { StateName = "North Carolina", StateAbbreviation = "NC" }, new State { StateName = "North Dakota", StateAbbreviation = "ND" }, new State { StateName = "Ohio", StateAbbreviation = "OH" },
                new State { StateName = "Oklahoma", StateAbbreviation = "OK" }, new State { StateName = "Oregon", StateAbbreviation = "OR" }, new State { StateName = "Pennsylvania", StateAbbreviation = "PA" },
                new State { StateName = "Rhode Island", StateAbbreviation = "RI" }, new State { StateName = "South Carolina", StateAbbreviation = "SC" }, new State { StateName = "South Dakota", StateAbbreviation = "SD" },
                new State { StateName = "Tennessee", StateAbbreviation = "TN" }, new State { StateName = "Texas", StateAbbreviation = "TX" }, new State { StateName = "Utah", StateAbbreviation = "UT" },
                new State { StateName = "Vermont", StateAbbreviation = "VT" }, new State { StateName = "Virgina", StateAbbreviation = "VA" }, new State { StateName = "Washington", StateAbbreviation = "WA" },
                new State { StateName = "West Virginia", StateAbbreviation = "WV" }, new State { StateName = "Wisconsin", StateAbbreviation = "WI" }, new State { StateName = "Wyoming", StateAbbreviation = "WY" });
            db.SaveChanges();
        }
    }
}
