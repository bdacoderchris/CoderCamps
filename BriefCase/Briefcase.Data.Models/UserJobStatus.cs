using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefcase.Data.Models
{
    public class UserJobStatus
    {
        [Key]
        public int UserJobStatusId { get; set; } 
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual JobStatus Status { get; set; }
    }
}
