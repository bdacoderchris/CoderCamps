﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Briefcase.ViewModels
{
    public class ContactViewModel
    {
        public int PocId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int JobId { get; set; }
        public bool IsDeleted { get; set; }
    }
}