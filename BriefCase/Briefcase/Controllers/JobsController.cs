using Briefcase.App_Services.Adapters;
using Briefcase.App_Services.Interfaces;
using Briefcase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Web;

namespace Briefcase.Controllers
{
    public class JobsController : ApiController
    {
        IJobAdapter _adapter;

        public JobsController()
        {
            _adapter = new JobDataAdapter();
        }

        public JobsController(IJobAdapter adpt)
        {
            _adapter = adpt;
        }

        [HttpPost]
        public IHttpActionResult CreateJob(JobViewModel model)
        {
            string UserId = User.Identity.GetUserId(); 
            _adapter.CreateJob(model, UserId);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult DeactivateJob(int id)
        {
            _adapter.DeactiveJob(id);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult UpdateJobStatus(JobViewModel model)
        {
            _adapter.UpdateJobStatus(model);
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetJob(int id)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            return Ok(_adapter.GetJob(id, userId));
        }


    }
}
