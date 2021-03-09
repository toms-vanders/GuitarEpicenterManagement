using System.Collections.Generic;
using System.Threading.Tasks;
using GE.DesktopUI.Library.Models;

namespace GE.DesktopUI.Library.Api
{
    public interface IUserEndpoint
    {
        Task<List<UserModel>> GetAll();
        Task<Dictionary<string, string>> GetAllRoles();
        Task AddUserToRole(string userId, string roleName);
        Task RemoveUserFromRole(string userId, string roleName);
    }
}