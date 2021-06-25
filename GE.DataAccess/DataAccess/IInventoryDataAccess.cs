using System.Collections.Generic;
using GE.DataAccess.Models;

namespace GE.DataAccess.DataAccess
{
    public interface IInventoryDataAccess
    {
        List<InventoryModel> GetInventory();
        void SaveInventoryRecord(InventoryModel item);
    }
}