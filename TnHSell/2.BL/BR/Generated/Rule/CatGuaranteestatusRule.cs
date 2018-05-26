
using System;
using System.Data;
using TnHSell.DTContract;
using TnHSell.DT;

namespace TnHSell.BR
{
    public class CatGuaranteestatusRule : BaseRule
    {

        static CatGuaranteestatusDT dta = new CatGuaranteestatusDT();
        public CatGuaranteestatusRule IsExits(string cond, string message)
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

        public CatGuaranteestatusRule ValidateInstant(CatGuaranteestatusContract dto)
        {
            return this;
        }
    }
}