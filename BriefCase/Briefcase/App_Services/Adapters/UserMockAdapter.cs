using Briefcase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Briefcase.App_Services.Adapters
{
    public class UserMockAdapter : IUserAdapter
    {
        public UserViewModel GetUser(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(UserViewModel model)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(string id)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserJob(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(UserViewModel model)
        {
            throw new NotImplementedException();
        }
        
        public void CreateContact(ContactViewModel model)
        {
            throw new NotImplementedException();
        }


        public void UpdateContact(ContactViewModel model)
        {
            throw new NotImplementedException();
        }

        public void DeleteContact(int id)
        {
            throw new NotImplementedException();
        }
    }
}