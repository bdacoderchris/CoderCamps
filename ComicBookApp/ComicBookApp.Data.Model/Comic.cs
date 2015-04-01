using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookApp.Data.Model
{
    public class Comic
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Cover { get; set; }
        public int ComicId { get; set; }
        public int StudioId { get; set; }

        public virtual Studio Studio { get; set; }
    }
}
