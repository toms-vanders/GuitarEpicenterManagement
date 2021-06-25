using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class SaleController : ControllerBase
    {
        private readonly ISaleDataAccess _saleData;

        public SaleController(ISaleDataAccess saleData)
        {
            _saleData = saleData;
        }
        [Authorize(Roles = "Cashier")]
        [HttpPost]
        public void Post(SaleModel sale)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _saleData.SaveSale(sale, userId);
        }

        [Authorize(Roles = "Admin,Manager")]
        [Route("GetSalesReport")]
        [HttpGet]
        public List<SaleReportModel> GetSalesReport()
        {
            return _saleData.GetSaleReport();
        }
    }
}
