using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GE.DataAccess.DataAccess;
using GE.DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        public List<ProductModel> Get()
        {
            ProductDataAccess data = new ProductDataAccess();

            return data.GetProducts();
        }
    }
}
