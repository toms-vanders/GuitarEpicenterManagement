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
    public class UserDataAccess : IUserDataAccess
    {
        private readonly ISqlDataAccess _sql;

        public UserDataAccess(ISqlDataAccess sql)
        {
            _sql = sql;
        }
        public List<UserModel> GetUserById(string Id)
        {
            var output = _sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", new { Id }, "GuitarEpicenterData");

            return output;
        }
    }
}
