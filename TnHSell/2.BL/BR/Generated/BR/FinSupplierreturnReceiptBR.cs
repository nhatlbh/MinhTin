
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class FinSupplierreturnReceiptBR : CommonBR
    {
        FinSupplierreturnReceiptContract finsupplierreturnreceiptContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.finsupplierreturnreceiptContract = (FinSupplierreturnReceiptContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            FinSupplierreturnReceiptRule finsupplierreturnreceiptRule = new FinSupplierreturnReceiptRule();
           // if (context == "Insert")
           // {
           //     rules.Add(finsupplierreturnreceiptRule.ValidateInstant(finsupplierreturnreceiptContract));
           // }
        }
    }
}
