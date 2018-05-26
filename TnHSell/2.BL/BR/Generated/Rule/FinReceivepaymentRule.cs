
using System;
using System.Data;
using TnHSell.DTContract;
using TnHSell.DT;

namespace TnHSell.BR
{
    public class FinReceivepaymentRule : BaseRule
    {

        static FinReceivepaymentDT dta = new FinReceivepaymentDT();
        public FinReceivepaymentRule IsExits(string cond, string message)
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

        public FinReceivepaymentRule ValidateInstant(FinReceivepaymentContract dto)
        {
            return this;
        }
    }
}