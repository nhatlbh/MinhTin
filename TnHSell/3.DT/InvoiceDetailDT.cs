using DTA;
using System.Data;

namespace TnHSell.DT
{
  public  class InvoiceDetailDT
    {
        public DataTable GetGridData(string controller, string cond, string order = "")

        {
            string tableName = getTableName(controller);
            if (tableName != "")
            {
                string query = @"SELECT 
                            InvDetail.*, Cat_Product.Name as Product_Name, unit.Name as Unit_Name
                            FROM " + tableName + @" InvDetail
			                     Left Join Cat_Product on  InvDetail.ProductID = Cat_Product.ID 
			                     Left Join Cat_Unit unit on Cat_Product.UnitID=unit.ID "
                          + " WHERE 1=1 AND (Deleted=0 OR Deleted IS NULL)";
                if (cond != null && cond != string.Empty)
                {
                    query += " AND " + cond;
                }
                if (order != "")
                {
                    query += " ORDER BY " + order;
                }
                DataTable dt = DataProvider.ExecuteQuery(query);
                return dt;
            }
            return null;
        }
        string getTableName(string controller)
        {
            switch (controller)
            {
                case "SelInvoice":
                    return "Sel_Invoice_Detail";
                case "BuyImportInvoice":
                    return "Buy_ImportInvoice_Detail";
                case "BuySupplierReturn":
                    return "Buy_SupplierReturn_Detail";
                case "StoExchange":
                    return "Sto_Exchange_Detail";
                case "StoExport":
                    return "Sto_Export";
                case "BuyGuarantee":
                    return "Buy_Guarantee_Detail";
                case "SelReceiveproduct":
                    return "Sel_ReceiveProduct_Detail";
                case "GuarReturn":
                    return "Guar_Return_Detail";
            }
            return "";
        }
    }
}
