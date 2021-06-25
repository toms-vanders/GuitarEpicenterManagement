using System.Collections.Generic;
using GE.DataAccess.Models;

namespace GE.DataAccess.DataAccess
{
    public interface IProductDataAccess
    {
        ProductModel GetProductById(int productId);
        List<ProductModel> GetProducts();
    }
}