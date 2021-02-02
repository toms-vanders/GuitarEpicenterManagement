using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using GE.DataAccess.DataAccess;
using GE.DataAccess.Models;
using Microsoft.AspNet.Identity;

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
    }
}
