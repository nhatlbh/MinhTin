
using System.Data;
using TnHSell.DT;
using TnHSell.DTContract;
using TnHSell.DTO;
using TnHSell.Model;
using Util;

namespace TnHSell.DFR
{
    public class SelInvoiceDFR
    {
        public static string GetGridData(string sessionKey, string cond, out string order)
        {
            //cond = cond == string.Empty ? "" : " AND ";
            //cond +=  CatSalestaffContract.Columns[(int)CatSalestaffColumns.ID] + " = 1 ";
            cond = InvoiceFilterModel.getFilterCond(cond, sessionKey);
            order = "OrderNum DESC, Id DESC";
            return cond;
        }

        public static string GetComboboxData(string sessionKey, out string columns, string cond, out string order)
        {
            //cond = cond == string.Empty ? "" : cond + " AND ";
            //cond += cond + CatSalestaffContract.Columns[(int)CatSalestaffColumns.ID] + " = 1 ";
            cond = InvoiceFilterModel.getFilterCond(cond, sessionKey);
            columns = " ID, Code ";
            order = "OrderNum DESC";
            return cond;
        }
    }
}