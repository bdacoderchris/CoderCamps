using Briefcase.Data;
using Briefcase.Data.Models;
using Briefcase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Postal;

namespace Briefcase.App_Services.Adapters
{
    public class UserDataAdapter : IUserAdapter
    {
        //Gets ALL user profile information plus Address and all the user's saved jobs for Home View
        public UserViewModel GetUser(string id)
        {
            UserViewModel user;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                user = db.Users.Where(a => a.Id == id).Select(a => new UserViewModel
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Email = a.Email,
                    IsDeleted = a.IsDeleted,
                    Image = a.Image,
                    Addresses = db.Addresses.Where(b => b.UserId == id).Select(b => new AddressViewModel
                    {
                        City = b.City,
                        Street1 = b.Street1,
                        Street2 = b.Street2,
                        Zip = b.Zip,
                        State = new StateViewModel { 
                            StateId = b.State.StateId,
                            StateAbbreviation = b.State.StateAbbreviation,
                            StateName = b.State.StateName
                        },
                        IsDeleted = b.IsDeleted
                    }).ToList(),
                    Jobs = db.UserJobStatuses.Where(x => x.UserId == id).Select(x => new JobViewModel
                    {
                        Applied = x.Status.Applied,
                        JobId = x.Status.JobId,
                        JobKey = x.Status.Job.JobKey,
                        Company = x.Status.Job.Company,
                        Location = x.Status.Job.Location,
                        Title = x.Status.Job.Title,
                        PhoneInterview = x.Status.PhoneInterview,
                        FirstInterview = x.Status.FirstInterview,
                        SecondInterview = x.Status.SecondInterview,
                        Offer = x.Status.Offer,
                        FollowUp1 = x.Status.FollowUp1,
                        FollowUp2 = x.Status.FollowUp2,
                        FollowUp3 = x.Status.FollowUp3,
                        Notes1 = x.Status.Notes1,
                        Notes2 = x.Status.Notes2,
                        StatusId = x.Status.StatusId,
                        PocId = x.Status.PocId,
                        IsDeleted = x.Status.IsDeleted
                    }).ToList(),
                    States = db.States.Select(st => new StateViewModel
                    {
                        StateId = st.StateId,
                        StateAbbreviation = st.StateAbbreviation,
                        StateName = st.StateName
                    }).ToList()
                })
                    .FirstOrDefault();

                return user;
            }

        }

        //Updates user profile information
        public void UpdateUser(UserViewModel model)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Address address = new Address();
                ApplicationUser user = new ApplicationUser();
                user = db.Users.Find(model.UserId);
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.Image = model.Image;
                address = db.Addresses.Where(a => a.UserId == model.UserId).FirstOrDefault();
                address.City = model.Addresses[0].City;
                address.Street1 = model.Addresses[0].Street1;
                address.Street2 = model.Addresses[0].Street2;
                address.Zip = model.Addresses[0].Zip;
                address.StateId = model.Addresses[0].State.StateId;
                db.SaveChanges();
                
            }
        }

        //Soft Delete on User profile/Sets 'IsDeleted' to true
        public void DeleteUser(string id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Users.Find(id).IsDeleted = true;
                db.SaveChanges();
            }
        }

        //Removes a saved job from User profile
        public void DeleteUserJob(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                UserJobStatus js = new UserJobStatus();
                js = db.UserJobStatuses.Where(j => j.Status.JobId == id).FirstOrDefault();
                db.UserJobStatuses.Remove(js);
                db.SaveChanges();
            }
        }

        //Create a new User Profile
        public void CreateUser(UserViewModel model)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var store = new UserStore<ApplicationUser>(db);
                var manager = new UserManager<ApplicationUser>(store);

                if (!db.Users.Any(u => u.UserName == model.Email))
                {
                    ApplicationUser user = new ApplicationUser
                    {
                        UserName = model.Email,
                        LastName = model.LastName,
                        FirstName = model.FirstName,
                        IsDeleted = false,
                        EmailConfirmed = true,
                        Email = model.Email,
                    };
                    
                    manager.Create(user, model.Password);
                     manager.AddToRole(user.Id, "User");
                    db.SaveChanges();

                    Address address = new Address
                    {
                        UserId = user.Id,
                    };
                    db.Addresses.AddOrUpdate(address);
                    db.SaveChanges();

                    dynamic email = new Email("Welcome");
                    email.To = user.Email;
                    email.PersonName = user.FirstName;
                    email.Send();
                }
            }
        }

        //Creates a new company contact in a user's saved job
        public void CreateContact(ContactViewModel model)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                CompanyContact contact = new CompanyContact();
                contact.PhoneNumber = model.PhoneNumber;
                contact.LastName = model.LastName;
                contact.FirstName = model.FirstName;
                contact.Email = model.Email;
                contact.IsDeleted = false;
                contact.JobId = model.JobId;

                db.Contacs.Add(contact);
                db.SaveChanges();

                
            }
        }

        //Updates Company Contact in a saved job
        public void UpdateContact(ContactViewModel model)
        {
            CompanyContact contact;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                contact = db.Contacs.Find(model.PocId);

                contact.IsDeleted = model.IsDeleted;
                contact.FirstName = model.FirstName;
                contact.LastName = model.LastName;
                contact.JobId = model.JobId;
                contact.PhoneNumber = model.PhoneNumber;
                contact.Email = model.Email;

                db.SaveChanges();
            }
        }

        //Removes Company Contact in a saved job
        public void DeleteContact(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                CompanyContact contact = new CompanyContact();
                contact = db.Contacs.Find(id);
                db.Contacs.Remove(contact);
                db.SaveChanges();
            }
        }
    }

}