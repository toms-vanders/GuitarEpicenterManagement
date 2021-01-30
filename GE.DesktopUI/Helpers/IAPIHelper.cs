using System.Threading.Tasks;
using GE.DesktopUI.Models;

namespace GE.DesktopUI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}