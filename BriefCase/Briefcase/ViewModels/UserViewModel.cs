using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Briefcase.ViewModels
{
    public class UserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public List<AddressViewModel> Addresses { get; set; }
        public List<JobViewModel> Jobs { get; set; }
        public List<StateViewModel> States { get; set; }
    }
}