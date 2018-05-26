
using System;
using System.Data;
using TnHSell.DTContract;
using TnHSell.DT;

namespace TnHSell.BR
{
    public class CatSalestaffRule : BaseRule
    {

        static CatSalestaffDT dta = new CatSalestaffDT();
        public CatSalestaffRule IsExits(string cond, string message)
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

        public CatSalestaffRule ValidateInstant(CatSalestaffContract dto)
        {
            return this;
        }
    }
}