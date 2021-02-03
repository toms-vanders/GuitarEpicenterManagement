using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GE.DataAccess.DataAccess;
using GE.DataAccess.Models;

namespace GE.WebAPI.Controllers
{
    [Authorize]
    public class ProductController : ApiController
    {
        // GET api/products
        public List<ProductModel> Get()
        {
            ProductDataAccess data = new ProductDataAccess();

            return data.GetProducts();
        }
    }
}
