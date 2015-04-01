using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Briefcase.App_Services;
using Briefcase.App_Services.Adapters;
using Microsoft.AspNet.Identity;
using Briefcase.App_Services.Interfaces;

namespace Briefcase.Controllers
{
    public class EmailsController : ApiController
    {
        IEmailAdapter _adapter;

        public EmailsController()
        {
            _adapter = new EmailDataAdapter();
        }

        public EmailsController(IEmailAdapter adpt)
        {
            _adapter = adpt;
        }

        //Email
        [HttpGet]
        public IHttpActionResult WelcomeEmail()
        {
            string id = User.Identity.GetUserId();
            _adapter.WelcomeEmail(id);
            return Ok();
        }
    }
}
