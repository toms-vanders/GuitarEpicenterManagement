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
    public class InventoryController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IInventoryDataAccess _inventoryData;

        public InventoryController(IConfiguration config, IInventoryDataAccess inventoryData)
        {
            _config = config;
            _inventoryData = inventoryData;
        }

        public IInventoryDataAccess InventoryData { get; }

        [Authorize(Roles = "Manager,Admin")]
        [HttpGet]
        public List<InventoryModel> GetSalesReport()
        {

            return _inventoryData.GetInventory();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public void Post(InventoryModel item)
        {
            _inventoryData.SaveInventoryRecord(item);
        }
    }
}
