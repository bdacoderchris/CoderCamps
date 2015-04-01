using ComicBookApp.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComicBookApp.Models
{
    //VModel for Home Page
    public class IndexViewModel
    {
        public string PageName { get; set; }
        public List<Comic> Comics { get; set; }

    }
    //VModel for Create Comic Page
    public class CreateViewModel
    {
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public string Cover { get; set; }
        public string Studio { get; set; }
        public string StudioId { get; set; }
    }
    //VModel for Update Comic Page
    public class UpdateViewModel
    {
        public Comic Comic { get; set; }
    }
}