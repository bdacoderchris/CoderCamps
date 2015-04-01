using Briefcase.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefcase.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobStatus> JobStatuses { get; set; }
        public DbSet<Search> Searches { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<CompanyContact> Contacs { get; set; }
        //public DbSet<UserJob> UserJobs { get; set; }
        public DbSet<UserSearch> UserSearches { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<UserJobStatus> UserJobStatuses { get; set; }



        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
