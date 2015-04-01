using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Briefcase.ViewModels
{
    public class JobViewModel
    {
        public int JobId { get; set; }
        public string JobKey { get; set; }
        public bool IsActive { get; set; }
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
        public int? PocId2 { get; set; }
        public bool IsDeleted { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
    }
}