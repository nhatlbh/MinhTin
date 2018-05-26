
using System;
using System.Data;
using TnHSell.DTContract;
using TnHSell.DT;

namespace TnHSell.BR
{
    public class SelInvoiceReceiptRule : BaseRule
    {

        static SelInvoiceReceiptDT dta = new SelInvoiceReceiptDT();
        public SelInvoiceReceiptRule IsExits(string cond, string message)
        {
            try
            {
                DataTable dt = dta.GetByCond(cond);
                if (dt != null && dt.Rows.Count > 0)
                {
                    IsPassed = false;
                    ErrMessage += message;
                }
                return this;
            }
            catch (Exception e)
            {
                IsPassed = false;
                throw e;
            }
        }

        public SelInvoiceReceiptRule ValidateInstant(SelInvoiceReceiptContract dto)
        {
            return this;
        }
    }
}