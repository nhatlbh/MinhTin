
using TnHSell.DTContract;

namespace TnHSell.DFR
{
    public class BuyImportinvoiceDetailDFR
    {
        public static string GetGridData(string sessionKey,string cond, out string order)
        {
            //cond = cond == string.Empty ? "" : " AND ";
            //cond +=  CatSalestaffContract.Columns[(int)CatSalestaffColumns.ID] + " = 1 ";
            order = "OrderNum DESC, Id DESC";
            return cond;
        }

        public static string GetComboboxData(string sessionKey,out string columns,string cond, out string order)
        {
            //cond = cond == string.Empty ? "" : cond + " AND ";
            //cond += cond + CatSalestaffContract.Columns[(int)CatSalestaffColumns.ID] + " = 1 ";
            columns = "";
            order = "OrderNum DESC";
            return cond;
        }
    }
}