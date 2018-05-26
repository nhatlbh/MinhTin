
using System;
using System.Data;
using TnHSell.DTContract;
using TnHSell.DT;

namespace TnHSell.BR
{
    public class AdmUserRule : BaseRule
    {

        static AdmUserDT dta = new AdmUserDT();
        public AdmUserRule IsExits(string cond, string message)
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

        public AdmUserRule ValidateInstant(AdmUserContract dto)
        {
            return this;
        }
    }
}