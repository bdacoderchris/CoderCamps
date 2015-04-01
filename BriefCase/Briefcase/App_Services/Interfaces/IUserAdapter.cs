using Briefcase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefcase.App_Services
{
    public interface IUserAdapter
    {
        UserViewModel GetUser(string id);
        void UpdateUser(UserViewModel model);

        void CreateUser(UserViewModel model);
        void DeleteUser(string id);
        void DeleteUserJob(int id);
        void CreateContact(ContactViewModel model);
        void UpdateContact(ContactViewModel model);
        void DeleteContact(int id);
    }
}
