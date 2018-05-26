using DTA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace TnHSell.DT
{
    public class ReceiptDetailDT
    {
        public DataTable GetSellInvoice(string cond)
        {
            string query = @"SELECT ID, Code, convert(varchar(10),CreateDate,103) as CreateDate, TotalDebt, 0 as Pay FROM Sel_Invoice WHERE 1=1 AND TotalDebt>0";
            query += cond == "" ? cond : " AND " + cond;
            return DataProvider.ExecuteQuery(query);
        }
        public DataTable GetSellInvoiceReceipt(string receiptId)
        {
            if (Converter.ToInt32(receiptId) > 0)
            {
                string query = @"SELECT si.ID, si.Code, convert(varchar(10),si.CreateDate,103) as CreateDate, si.TotalDebt, ir.Total, 0 as Pay
                            FROM  Sel_Invoice_Receipt ir
                            INNER JOIN Sel_Invoice si on ir.InvoiceID = si.ID WHERE ReceiptID = " + receiptId;
                return DataProvider.ExecuteQuery(query);
            }
            else
            {
                return null;
            }

        }
        public DataTable GetSuppReturn(string cond)
        {
            string query = @"SELECT ID, Code,  convert(varchar(10),CreateDate,103) as CreateDate , TotalDebt, 0 as Pay FROM Buy_SupplierReturn WHERE 1=1 AND TotalDebt>0";
            query += cond == "" ? cond : " AND " + cond;
            return DataProvider.ExecuteQuery(query);
        }

        public DataTable GetSuppReturnReceipt(string receiptId)
        {
            if (Converter.ToInt32(receiptId) > 0)
            {
                string query = @"SELECT sr.ID, sr.Code,  convert(varchar(10),sr.CreateDate,103) as CreateDate, sr.TotalDebt, srr.Total, 0 as Pay 
                            FROM  Fin_SupplierReturn_Receipt srr
                            INNER JOIN Buy_SupplierReturn sr on sr.InvoiceID = srr.ID WHERE ReceiptID = " + receiptId;
                return DataProvider.ExecuteQuery(query);
            }
            else
            {
                return null;
            }
        }
    }
}
