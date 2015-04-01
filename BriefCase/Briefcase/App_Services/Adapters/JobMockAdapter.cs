using Briefcase.App_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Briefcase.App_Services.Adapters
{
    public class JobMockAdapter : IJobAdapter
    {
        public ViewModels.JobViewModel GetJob(int id, string userId)
        {
            throw new NotImplementedException();
        }

        public ViewModels.JobViewModel GetSearchJobs()
        {
            throw new NotImplementedException();
        }




        public void DeactiveJob(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateJobStatus(ViewModels.JobViewModel vm)
        {
            throw new NotImplementedException();
        }


        public void CreateJob(ViewModels.JobViewModel job, string UserId)
        {
            throw new NotImplementedException();
        }

        public void CreateJobStatus(ViewModels.JobViewModel vm)
        {
            throw new NotImplementedException();
        }
    }
}