using System.Threading.Tasks;
using GE.DesktopUI.Library.Models;

namespace GE.DesktopUI.Library.Api
{
    public interface ISaleEndpoint
    {
        Task PostSale(SaleModel sale);
    }
}