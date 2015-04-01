using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefcase.Data.Models
{
    public class UserSearch
    {
         [Key]
        public int UserSearchId { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User {get; set;}
        
        public int SearchId { get; set; }
        [ForeignKey("SearchId")]
        public virtual Search Search { get; set; }

    }
}
