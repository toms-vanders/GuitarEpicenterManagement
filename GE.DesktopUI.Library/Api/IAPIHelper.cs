using System.Threading.Tasks;
using GE.DesktopUI.Library.Models;

namespace GE.DesktopUI.Library.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}