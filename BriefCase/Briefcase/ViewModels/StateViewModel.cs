using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Briefcase.ViewModels
{
    public class StateViewModel
    {
        public int? StateId { get; set; }
        public string StateName { get; set; }
        public string StateAbbreviation { get; set; }
    }
}