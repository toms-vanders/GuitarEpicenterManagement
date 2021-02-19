using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GE.DataAccess.DataAccess;
using GE.DataAccess.Models;
using GE.WebAPI.Models;
using Microsoft.AspNet.Identity;

namespace GE.WebAPI.Controllers
{
    [Authorize]
    public class SaleController : ApiController
    {
        public void Post(SaleModel sale)
        {
            SaleDataAccess data = new SaleDataAccess();
            string userId = RequestContext.Principal.Identity.GetUserId();
            
            data.SaveSale(sale, userId);
        }

        [Route("GetSalesReport")]
        public List<SaleReportModel> GetSalesReport()
        {
            SaleDataAccess data = new SaleDataAccess();
            return data.GetSaleReport();
        }
    }
}
