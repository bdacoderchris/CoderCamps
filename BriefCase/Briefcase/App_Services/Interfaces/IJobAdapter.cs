using Briefcase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefcase.App_Services.Interfaces
{
    public interface IJobAdapter
    {
        JobViewModel GetJob(int id, string userId);
        JobViewModel GetSearchJobs();
        void CreateJob(JobViewModel job, string UserId);
        void DeactiveJob(int id);
        void UpdateJobStatus(JobViewModel vm);
    }
}
