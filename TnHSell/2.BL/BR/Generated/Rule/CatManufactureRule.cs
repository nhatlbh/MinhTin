
using System;
using System.Data;
using TnHSell.DTContract;
using TnHSell.DT;

namespace TnHSell.BR
{
    public class CatManufactureRule : BaseRule
    {

        static CatManufactureDT dta = new CatManufactureDT();
        public CatManufactureRule IsExits(string cond, string message)
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

        public CatManufactureRule ValidateInstant(CatManufactureContract dto)
        {
            return this;
        }
    }
}