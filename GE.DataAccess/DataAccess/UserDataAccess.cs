using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GE.DataAccess.Internal.DataAccess;
using GE.DataAccess.Models;
using Microsoft.Extensions.Configuration;

namespace GE.DataAccess.DataAccess
{
    public class UserDataAccess
    {
        private readonly IConfiguration _config;

        public UserDataAccess(IConfiguration config)
        {
            _config = config;
        }
        public List<UserModel> GetUserById(string Id)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var p = new { Id = Id };

            var output = sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", p, "GuitarEpicenterData");

            return output;
        }
    }
}
