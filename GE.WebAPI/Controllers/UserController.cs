﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using GE.DataAccess.DataAccess;
using GE.DataAccess.Models;
using GE.WebAPI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GE.WebAPI.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        [HttpGet]
        public UserModel GetById()
        {
            string userId = RequestContext.Principal.Identity.GetUserId();

            UserDataAccess data = new UserDataAccess();

            return data.GetUserById(userId).First();

        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("api/User/Admin/GetAllUsers")]
        public List<ApplicationUserModel> GetAllUsers()
        {
            List<ApplicationUserModel> output = new List<ApplicationUserModel>();

            using (var context = new ApplicationDbContext())
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var users = userManager.Users.ToList();
                var roles = context.Roles.ToList();

                foreach (var user in users)
                {
                    ApplicationUserModel u = new ApplicationUserModel
                    {
                        Id = user.Id,
                        Email = user.Email
                    };

                    foreach (var r in user.Roles)
                    {
                        u.Roles.Add(r.RoleId, roles.Where(x => x.Id == r.RoleId).First().Name);
                    }

                    output.Add(u);
                }
            }

            return output;
        }
    }
}
