using DTA;
using System.Data;
using Util;

namespace TnHSell.DT
{
    public class MoneySlipDetailDT
    {
        public DataTable GetImportInvoice(string cond)
        {
            string query = @"SELECT ID, Code, convert(varchar(10),CreateDate,103) as CreateDate, TotalDebt, 0 as Pay FROM Buy_ImportInvoice WHERE 1=1 AND TotalDebt>0";
            query += cond == "" ? cond : " AND " + cond;
            return DataProvider.ExecuteQuery(query);
        }
        public DataTable GetImportPayment(string receiptId)
        {
            if (Converter.ToInt32(receiptId) > 0)
            {
                string query = @"SELECT bi.ID, bi.Code, convert(varchar(10),bi.CreateDate,103) as CreateDate, bi.TotalDebt, ip.Total, 0 as Pay
                            FROM  Fin_ImportPayment ip
                            INNER JOIN Buy_ImportInvoice bi on ip.ImportInvoiceID = bi.ID WHERE MoneySlipID = " + receiptId;
                return DataProvider.ExecuteQuery(query);
            }
            else
            {
                return null;
            }

        }
        public DataTable GetReceiveProduct(string cond)
        {
            string query = @"SELECT ID, Code,  convert(varchar(10),CreateDate,103) as CreateDate , TotalReturn as TotalDebt, 0 as Pay FROM Sel_ReceiveProduct WHERE 1=1 AND TotalReturn>0";
            query += cond == "" ? cond : " AND " + cond;
            return DataProvider.ExecuteQuery(query);
        }

        public DataTable GetReceivePayment(string receiptId)
        {
            if (Converter.ToInt32(receiptId) > 0)
            {
                string query = @"SELECT srp.ID, srp.Code,  convert(varchar(10),srp.CreateDate,103) as CreateDate, srp.TotalReturn as TotalDebt, rp.Total, 0 as Pay 
                            FROM  Fin_ReceivePayment rp
                            INNER JOIN Sel_ReceiveProduct srp on rp.ReceiveProductID = srp.ID WHERE ReceiptID = " + receiptId;
                return DataProvider.ExecuteQuery(query);
            }
            else
            {
                return null;
            }
        }
    }
}
