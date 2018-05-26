
using System;
using System.Data;
using TnHSell.DTContract;
using TnHSell.DT;

namespace TnHSell.BR
{
    public class SelReceiveproductDetailRule : BaseRule
    {

        static SelReceiveproductDetailDT dta = new SelReceiveproductDetailDT();
        public SelReceiveproductDetailRule IsExits(string cond, string message)
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

        public SelReceiveproductDetailRule ValidateInstant(SelReceiveproductDetailContract dto)
        {
            return this;
        }
    }
}