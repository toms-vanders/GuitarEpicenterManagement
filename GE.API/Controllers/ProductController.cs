using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GE.DataAccess.DataAccess;
using GE.DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductDataAccess _productData;

        public ProductController(IProductDataAccess productData)
        {
            _productData = productData;
        }

        [HttpGet]
        public List<ProductModel> Get()
        {
            return _productData.GetProducts();
        }
    }
}
