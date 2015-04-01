using Briefcase.App_Services.Interfaces;
using Briefcase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Postal;


namespace Briefcase.App_Services.Adapters
{
    public class EmailDataAdapter : IEmailAdapter
    {
        public void WelcomeEmail(string id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var user = db.Users.Where(u => u.Id == id).FirstOrDefault();
                dynamic email = new Email("Welcome");
                email.To = user.Email;
                email.PersonName = user.FirstName;
                email.Send();
            }
        }
    }
}