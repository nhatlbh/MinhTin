
using System;
using System.Data;
using TnHSell.DTContract;
using TnHSell.DT;

namespace TnHSell.BR
{
    public class CatPaymenttypeRule : BaseRule
    {

        static CatPaymenttypeDT dta = new CatPaymenttypeDT();
        public CatPaymenttypeRule IsExits(string cond, string message)
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

        public CatPaymenttypeRule ValidateInstant(CatPaymenttypeContract dto)
        {
            return this;
        }
    }
}