
using TnHSell.DTContract;
using TnHSell.DTO;
using TnHSell.Model;

namespace TnHSell.DFR
{
    public class CatCustomerDFR
    {
        public static string GetGridData(string sessionKey, string cond, out string order)
        {
            cond = InvoiceFilterModel.getFilterCond(cond, sessionKey);
            order = " OrderNum DESC, Id DESC";
            return cond;
        }

        public static string GetComboboxData(string sessionKey, out string columns, string cond, out string order)
        {
            cond = InvoiceFilterModel.getFilterCond(cond, sessionKey);
            columns = "";
            order = "OrderNum DESC";
            return cond;
        }
    }
}