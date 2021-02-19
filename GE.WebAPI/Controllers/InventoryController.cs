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
    public class InventoryController : ApiController
    {
        public List<InventoryModel> GetSalesReport()
        {
            InventoryDataAccess data = new InventoryDataAccess();
            return data.GetInventory();
        }

        public void Post(InventoryModel item)
        {
            InventoryDataAccess data = new InventoryDataAccess();
            data.SaveInventoryRecord(item);
        }
    }
}
