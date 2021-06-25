using System.Collections.Generic;
using GE.DataAccess.Models;

namespace GE.DataAccess.DataAccess
{
    public interface IUserDataAccess
    {
        List<UserModel> GetUserById(string Id);
    }
}