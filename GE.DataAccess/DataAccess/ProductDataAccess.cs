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
    public class ProductDataAccess : IProductDataAccess
    {
        private readonly ISqlDataAccess _sql;

        public ProductDataAccess(ISqlDataAccess sql)
        {
            _sql = sql;
        }
        public List<ProductModel> GetProducts()
        {
            var output = _sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetAll", new { }, "GuitarEpicenterData");

            return output;
        }

        public ProductModel GetProductById(int productId)
        {
            var output = _sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetById", new { Id = productId }, "GuitarEpicenterData").FirstOrDefault();

            return output;
        }
    }
}
