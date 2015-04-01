using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using ComicBookApp.Data.Model;

namespace ComicBookApp.Data
{
    public static class Seeder
    {
        public static void Seed(ComicDbContext db)
        {
            db.Studio.AddOrUpdate(c => new { c.Name },
                new Studio {Name = "Marvel",
                            StudioId = 1
                },
                new Studio {Name = "DC Comics",
                            StudioId = 2
                }
            );
            db.SaveChanges();
            db.Comics.AddOrUpdate(c => new {c.Title},
                new Comic {Title = "Captain America",
                           Author = "Stan Lee",
                           Cover = "http://upload.wikimedia.org/wikipedia/en/9/91/CaptainAmerica109.jpg",
                           StudioId = 1,
                           ComicId = 1
                },
                new Comic {Title = "Batman",
                           Author = "Bob Kane",
                           Cover = "http://vignette4.wikia.nocookie.net/batman/images/3/32/Batmanno1.jpg/revision/latest?cb=20101020172136",
                           StudioId = 1,
                           ComicId = 2
                }
                );
            db.SaveChanges();
        }

    }
}
