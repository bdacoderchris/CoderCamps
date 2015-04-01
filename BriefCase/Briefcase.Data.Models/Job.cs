using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefcase.Data.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        public string JobKey { get; set; }
        public bool IsActive { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Company { get; set; }
    }
}
