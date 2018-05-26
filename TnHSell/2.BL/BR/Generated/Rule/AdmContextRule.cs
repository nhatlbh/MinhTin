
using System;
using System.Data;
using TnHSell.DTContract;
using TnHSell.DT;

namespace TnHSell.BR
{
    public class AdmContextRule : BaseRule
    {

        static AdmContextDT dta = new AdmContextDT();
        public AdmContextRule IsExits(string cond, string message)
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

        public AdmContextRule ValidateInstant(AdmContextContract dto)
        {
            return this;
        }
    }
}