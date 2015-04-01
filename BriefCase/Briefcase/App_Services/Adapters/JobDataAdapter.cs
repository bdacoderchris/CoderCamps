using Briefcase.App_Services.Interfaces;
using Briefcase.Data;
using Briefcase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Security.Principal;
using System.Diagnostics;
using System.Data.Entity.Migrations;
using Briefcase.Data.Models;

namespace Briefcase.App_Services.Adapters
{
    public class JobDataAdapter : IJobAdapter
    {
        //Gets a single job detail that is saved to a User's Profile
        public JobViewModel GetJob(int id, string userId)
        {
            JobViewModel job;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                job = db.UserJobStatuses.Where(j => j.UserId == userId && j.Status.JobId == id).Select(j => new JobViewModel
                {
                    Applied = j.Status.Applied,
                    PhoneInterview = j.Status.PhoneInterview,
                    FirstInterview = j.Status.FirstInterview,
                    SecondInterview = j.Status.SecondInterview,
                    Offer = j.Status.Offer,
                    FollowUp1 = j.Status.FollowUp1,
                    FollowUp2 = j.Status.FollowUp2,
                    FollowUp3 = j.Status.FollowUp3,
                    Notes1 = j.Status.Notes1,
                    PocId = j.Status.PocId,
                    StatusId = j.Status.StatusId,
                    IsActive = j.Status.Job.IsActive,
                    JobId = j.Status.JobId,
                    JobKey = j.Status.Job.JobKey,
                    Company = j.Status.Job.Company,
                    Location = j.Status.Job.Location,
                    Title = j.Status.Job.Title
                }).FirstOrDefault();
            }
            return job;
        }


        //Gets jobs based on previous search terms
        public JobViewModel GetSearchJobs()
        {
            throw new NotImplementedException();
        }

        //Adds a job from user search to user profile
        public void CreateJob(JobViewModel job, string UserId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Job newJob = new Job();
                newJob.IsActive = job.IsActive;
                newJob.JobKey = job.JobKey;
                newJob.Company = job.Company;
                newJob.Location = job.Location;
                newJob.Title = job.Title;

                // If the job isn't already in the database, adds it.
                if (!db.Jobs.Any(j => j.JobKey == job.JobKey))
                {
                    db.Jobs.Add(newJob);
                    db.SaveChanges();
                }

                // Creates a new jobStatus
                JobStatus newJobStatus = new JobStatus();
                newJobStatus.JobId = newJob.JobId;
                db.JobStatuses.AddOrUpdate(newJobStatus);
                db.SaveChanges();

                // Connects jobStatus to Job
                UserJobStatus newUJS = new UserJobStatus();
                newUJS.UserId = UserId;
                newUJS.StatusId = newJobStatus.StatusId;
                db.UserJobStatuses.AddOrUpdate(newUJS);
                db.SaveChanges();
            }
        }


        //Removes saved job from user profile/Sets 'IsActive' to false
        public void DeactiveJob(int id)
        {

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Jobs.FirstOrDefault(j => j.JobId == id).IsActive = false;
                db.SaveChanges();

            }

        }

        //Changes status fields of a saved job in user profile
        public void UpdateJobStatus(JobViewModel vm)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                JobStatus jobStatus = db.JobStatuses.FirstOrDefault(j => j.StatusId == vm.StatusId);
                jobStatus.Applied = vm.Applied;
                jobStatus.PhoneInterview = vm.PhoneInterview;
                jobStatus.FirstInterview = vm.FirstInterview;
                jobStatus.SecondInterview = vm.SecondInterview;
                jobStatus.Offer = vm.Offer;
                jobStatus.FollowUp1 = vm.FollowUp1;
                jobStatus.FollowUp2 = vm.FollowUp2;
                jobStatus.FollowUp3 = vm.FollowUp3;
                jobStatus.Notes1 = vm.Notes1;
                jobStatus.Notes2 = vm.Notes2;
                jobStatus.IsDeleted = vm.IsDeleted;
                db.SaveChanges();
            }
        }
    }
}