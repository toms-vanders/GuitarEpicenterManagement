using System.Collections.Generic;
using System.Threading.Tasks;
using GE.DesktopUI.Library.Models;

namespace GE.DesktopUI.Library.Api
{
    public interface IProductEndpoint
    {
        Task<List<ProductModel>> GetAll();
    }
}