
using System;
using System.Data;
using TnHSell.DTContract;
using TnHSell.DT;

namespace TnHSell.BR
{
    public class FinReceiptRule : BaseRule
    {

        static FinReceiptDT dta = new FinReceiptDT();
        public FinReceiptRule IsExits(string cond, string message)
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

        public FinReceiptRule ValidateInstant(FinReceiptContract dto)
        {
            return this;
        }
    }
}