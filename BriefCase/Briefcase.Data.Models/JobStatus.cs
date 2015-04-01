using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefcase.Data.Models
{
    public class JobStatus
    {
        [Key]
        public int StatusId { get; set; }
        public bool Applied { get; set; }
        public DateTime? PhoneInterview { get; set; }
        public DateTime? FirstInterview { get; set; }
        public DateTime? SecondInterview { get; set; }
        public bool Offer { get; set; }
        public DateTime? FollowUp1 { get; set; }
        public DateTime? FollowUp2 { get; set; }
        public DateTime? FollowUp3 { get; set; }
        public string Notes1 { get; set; }
        public string Notes2 { get; set; }

        public int? PocId { get; set; }
        [ForeignKey("PocId")]
        public virtual CompanyContact Contact1 { get; set; }

        public int JobId { get; set; }
        [ForeignKey("JobId")]
        public virtual Job Job { get; set; }
       

        public bool IsDeleted { get; set; }
        
    }
}
