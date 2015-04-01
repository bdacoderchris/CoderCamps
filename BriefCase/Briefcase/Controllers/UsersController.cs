using Briefcase.App_Services;
using Briefcase.App_Services.Adapters;
using Briefcase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace Briefcase.Controllers
{
    public class UsersController : ApiController
    {
        IUserAdapter _adapter;

        public UsersController()
        {
            _adapter = new UserDataAdapter();
        }

        public UsersController(IUserAdapter adpt){
            _adapter = adpt;
        }
        public IHttpActionResult GetUser()
        {
            string id = User.Identity.GetUserId();
            return Ok(_adapter.GetUser(id));
        }

        [HttpGet]
        public IHttpActionResult DeleteUser()
        {
            string id = User.Identity.GetUserId();
            _adapter.DeleteUser(id);
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult DeleteUserJob(int id)
        {
            _adapter.DeleteUserJob(id);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult CreateUser(UserViewModel model)
        {
            _adapter.CreateUser(model);
            return Ok();
        }

        public IHttpActionResult UpdateUser(UserViewModel model)
        {
            string id = User.Identity.GetUserId();
            model.UserId = id;
            _adapter.UpdateUser(model);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult CreateContact(ContactViewModel model)
        {
            _adapter.CreateContact(model);
            return Ok();
        }

        public IHttpActionResult UpdateContact(ContactViewModel model)
        {
            _adapter.UpdateContact(model);
            return Ok();
        }

        public IHttpActionResult DeleteContact(int id)
        {
            _adapter.DeleteContact(id);
            return Ok();
        }

    }
}
