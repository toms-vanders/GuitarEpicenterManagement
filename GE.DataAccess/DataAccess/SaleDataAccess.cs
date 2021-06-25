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
    public class SaleDataAccess : ISaleDataAccess
    {
        private readonly IProductDataAccess _productData;
        private readonly ISqlDataAccess _sql;

        public SaleDataAccess(IProductDataAccess productData, ISqlDataAccess sql)
        {
            _productData = productData;
            _sql = sql;
        }
        public void SaveSale(SaleModel saleInfo, string cashierId)
        {
            //TODO: Make this SOLID/DRY/Better
            // Start filling in the sale detail models we will save to the database
            List<SaleDetailDBModel> details = new List<SaleDetailDBModel>();
            var taxRate = ConfigHelper.GetTaxRate() / 100;

            foreach (var item in saleInfo.SaleDetails)
            {
                var detail = new SaleDetailDBModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                };

                // Get the infromation about this product
                var productInfo = _productData.GetProductById(detail.ProductId);

                if (productInfo == null)
                {
                    throw new Exception($"The product Id of { detail.ProductId } could not be found in the database");
                }

                detail.PurchasePrice = (productInfo.RetailPrice * detail.Quantity);

                if (productInfo.IsTaxable)
                {
                    detail.Tax = (detail.PurchasePrice * taxRate);
                }

                details.Add(detail);
            }

            //Create the Sale model
            SaleDBModel sale = new SaleDBModel
            {
                SubTotal = details.Sum(x => x.PurchasePrice),
                Tax = details.Sum(x => x.Tax),
                CashierId = cashierId,
            };

            sale.Total = sale.SubTotal + sale.Tax;

            //Save the sale model

            try
            {
                _sql.StartTransaction("GuitarEpicenterData");

                _sql.SaveDataInTransaction("dbo.spSale_Insert", sale);

                //Get ID from the sale model
                sale.Id = _sql.LoadDataInTransaction<int, dynamic>("spSale_Lookup", new { sale.CashierId, sale.SaleDate }).FirstOrDefault();

                //Finish fillin in the sale detail models
                foreach (var item in details)
                {
                    item.SaleId = sale.Id;
                    // Save the sale detail models         
                    _sql.SaveDataInTransaction("dbo.spSaleDetail_Insert", item);
                }
                _sql.CommitTransaction();
            }
            catch
            {
                _sql.RollbackTransaction();
                throw;
            }


        }

        public List<SaleReportModel> GetSaleReport()
        {
            var output = _sql.LoadData<SaleReportModel, dynamic>("dbo.spSale_SaleReport", new { }, "GuitarEpicenterData");

            return output;
        }
    }
}
