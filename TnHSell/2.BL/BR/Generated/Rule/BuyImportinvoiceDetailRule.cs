
using System;
using System.Data;
using TnHSell.DTContract;
using TnHSell.DT;

namespace TnHSell.BR
{
    public class BuyImportinvoiceDetailRule : BaseRule
    {

        static BuyImportinvoiceDetailDT dta = new BuyImportinvoiceDetailDT();
        public BuyImportinvoiceDetailRule IsExits(string cond, string message)
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

        public BuyImportinvoiceDetailRule ValidateInstant(BuyImportinvoiceDetailContract dto)
        {
            return this;
        }
    }
}