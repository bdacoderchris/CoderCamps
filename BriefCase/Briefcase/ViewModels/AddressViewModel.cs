using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Briefcase.ViewModels
{
    public class AddressViewModel
    {
        public int AddressId { get; set; }
        public string City { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Zip { get; set; }
        public int? StateId { get; set; }
        public StateViewModel State { get; set; }
        public string UserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}