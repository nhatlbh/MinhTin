
using System;
using System.Data;
using TnHSell.DTContract;
using TnHSell.DT;

namespace TnHSell.BR
{
    public class StoExchangeRule : BaseRule
    {

        static StoExchangeDT dta = new StoExchangeDT();
        public StoExchangeRule IsExits(string cond, string message)
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

        public StoExchangeRule ValidateInstant(StoExchangeContract dto)
        {
            return this;
        }
    }
}