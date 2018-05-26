
using System;
using System.Data;
using TnHSell.DTContract;
using TnHSell.DT;

namespace TnHSell.BR
{
    public class CatConvresultRule : BaseRule
    {

        static CatConvresultDT dta = new CatConvresultDT();
        public CatConvresultRule IsExits(string cond, string message)
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

        public CatConvresultRule ValidateInstant(CatConvresultContract dto)
        {
            return this;
        }
    }
}