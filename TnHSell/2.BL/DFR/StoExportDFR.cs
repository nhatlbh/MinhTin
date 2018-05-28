
using TnHSell.DTContract;
using TnHSell.Model;

namespace TnHSell.DFR
{
    public class StoExportDFR
    {
        public static string GetGridData(string sessionKey,string cond, out string order)
        {
            //cond = cond == string.Empty ? "" : " AND ";
            //cond +=  CatSalestaffContract.Columns[(int)CatSalestaffColumns.ID] + " = 1 ";
            cond = InvoiceFilterModel.getFilterCond(cond, sessionKey);
            order = "OrderNum DESC, Id DESC";
            return cond;
        }

        public static string GetComboboxData(string sessionKey,out string columns,string cond, out string order)
        {
            //cond = cond == string.Empty ? "" : cond + " AND ";
            //cond += cond + CatSalestaffContract.Columns[(int)CatSalestaffColumns.ID] + " = 1 ";
            cond = InvoiceFilterModel.getFilterCond(cond, sessionKey);
            columns = "";
            order = "OrderNum DESC";
            return cond;
        }
    }
}