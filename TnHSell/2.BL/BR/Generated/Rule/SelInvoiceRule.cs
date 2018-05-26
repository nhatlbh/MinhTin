
using System;
using System.Data;
using TnHSell.DTContract;
using TnHSell.DT;

namespace TnHSell.BR
{
    public class SelInvoiceRule : BaseRule
    {

        static SelInvoiceDT dta = new SelInvoiceDT();
        public SelInvoiceRule IsExits(string cond, string message)
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

        public SelInvoiceRule ValidateInstant(SelInvoiceContract dto)
        {
            return this;
        }
    }
}