using System.Collections.Generic;
using GE.DataAccess.Models;

namespace GE.DataAccess.DataAccess
{
    public interface ISaleDataAccess
    {
        List<SaleReportModel> GetSaleReport();
        void SaveSale(SaleModel saleInfo, string cashierId);
    }
}