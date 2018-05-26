
using System;
using System.Data;
using TnHSell.DTContract;
using TnHSell.DT;

namespace TnHSell.BR
{
    public class StaffMgntgroupRule : BaseRule
    {

        static StaffMgntgroupDT dta = new StaffMgntgroupDT();
        public StaffMgntgroupRule IsExits(string cond, string message)
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

        public StaffMgntgroupRule ValidateInstant(StaffMgntgroupContract dto)
        {
            return this;
        }
    }
}