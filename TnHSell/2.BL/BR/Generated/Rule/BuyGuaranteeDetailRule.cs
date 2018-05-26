
using System;
using System.Data;
using TnHSell.DTContract;
using TnHSell.DT;

namespace TnHSell.BR
{
    public class BuyGuaranteeDetailRule : BaseRule
    {

        static BuyGuaranteeDetailDT dta = new BuyGuaranteeDetailDT();
        public BuyGuaranteeDetailRule IsExits(string cond, string message)
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

        public BuyGuaranteeDetailRule ValidateInstant(BuyGuaranteeDetailContract dto)
        {
            return this;
        }
    }
}