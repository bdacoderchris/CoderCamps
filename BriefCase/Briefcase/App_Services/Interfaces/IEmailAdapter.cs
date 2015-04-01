using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefcase.App_Services.Interfaces
{
    public interface IEmailAdapter
    {
        void WelcomeEmail(string email);
    }
}
