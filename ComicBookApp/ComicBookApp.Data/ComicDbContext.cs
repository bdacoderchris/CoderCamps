using ComicBookApp.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookApp.Data
{
    public class ComicDbContext : DbContext
    {
        public ComicDbContext() : base("ComicDbConnection") { }
        public DbSet<Studio> Studio { get; set; }
        public DbSet<Comic> Comics { get; set; }
    }
}
