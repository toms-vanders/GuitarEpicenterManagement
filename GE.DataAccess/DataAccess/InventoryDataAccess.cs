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
    public class InventoryDataAccess : IInventoryDataAccess
    {
        private readonly ISqlDataAccess _sql;

        public InventoryDataAccess(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        public List<InventoryModel> GetInventory()
        {
            var output = _sql.LoadData<InventoryModel, dynamic>("dbo.spInventory_GetAll", new { }, "GuitarEpicenterData");

            return output;
        }

        public void SaveInventoryRecord(InventoryModel item)
        {
            _sql.SaveData("dbo.spInventory_Insert", item, "GuitarEpicenterData");
        }
    }
}
