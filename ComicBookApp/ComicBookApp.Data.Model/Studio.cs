using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookApp.Data.Model
{
    public class Studio
    {
        public int StudioId { get; set; }
        public string Name { get; set; }
        public virtual List<Comic> Comics { get; set; }
    }
}
