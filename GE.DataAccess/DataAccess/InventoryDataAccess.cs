using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GE.DataAccess.Internal.DataAccess;
using GE.DataAccess.Models;

namespace GE.DataAccess.DataAccess
{
    public class InventoryDataAccess
    {

        public List<InventoryModel> GetInventory()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<InventoryModel, dynamic>("dbo.spInventory_GetAll", new { }, "GuitarEpicenterData");

            return output;
        }

        public void SaveInventoryRecord(InventoryModel item)
        {
            SqlDataAccess sql = new SqlDataAccess();

            sql.SaveData("dbo.spInventory_Insert", item, "GuitarEpicenterData");
        }
    }
}
