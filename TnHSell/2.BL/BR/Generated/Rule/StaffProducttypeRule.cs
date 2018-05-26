
using System;
using System.Data;
using TnHSell.DTContract;
using TnHSell.DT;

namespace TnHSell.BR
{
    public class StaffProducttypeRule : BaseRule
    {

        static StaffProducttypeDT dta = new StaffProducttypeDT();
        public StaffProducttypeRule IsExits(string cond, string message)
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

        public StaffProducttypeRule ValidateInstant(StaffProducttypeContract dto)
        {
            return this;
        }
    }
}