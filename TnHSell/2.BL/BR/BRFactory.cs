using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TnHSell.BR
{
    public class BRFactory
    {
        public static IBaseBR GenerateBRObject(Type type)
        {
            if (type.FullName == typeof(BuyGuaranteeBR).FullName)
                return new BuyGuaranteeBR();
            if (type.FullName == typeof(BuyImportinvoiceBR).FullName)
                return new BuyImportinvoiceBR();
            if (type.FullName == typeof(BuyImportinvoiceDetailBR).FullName)
                return new BuyImportinvoiceDetailBR();
            if (type.FullName == typeof(BuyPoBR).FullName)
                return new BuyPoBR();
            if (type.FullName == typeof(BuyPoDetailBR).FullName)
                return new BuyPoDetailBR();
            if (type.FullName == typeof(BuySupplierreturnBR).FullName)
                return new BuySupplierreturnBR();
            if (type.FullName == typeof(BuySupplierreturnDetailBR).FullName)
                return new BuySupplierreturnDetailBR();
            if (type.FullName == typeof(CatBranchBR).FullName)
                return new CatBranchBR();
            if (type.FullName == typeof(CatColorBR).FullName)
                return new CatColorBR();
            if (type.FullName == typeof(CatCustomerBR).FullName)
                return new CatCustomerBR();
            if (type.FullName == typeof(CatDistrictBR).FullName)
                return new CatDistrictBR();
            if (type.FullName == typeof(CatIocodeBR).FullName)
                return new CatIocodeBR();
            if (type.FullName == typeof(CatManagementgroupBR).FullName)
                return new CatManagementgroupBR();
            if (type.FullName == typeof(CatManufactureBR).FullName)
                return new CatManufactureBR();
            if (type.FullName == typeof(CatPaymenttypeBR).FullName)
                return new CatPaymenttypeBR();
            if (type.FullName == typeof(CatProductBR).FullName)
                return new CatProductBR();
            if (type.FullName == typeof(CatProductPriceBR).FullName)
                return new CatProductPriceBR();
            if (type.FullName == typeof(CatProductStoreBR).FullName)
                return new CatProductStoreBR();
            if (type.FullName == typeof(CatProductgroupBR).FullName)
                return new CatProductgroupBR();
            if (type.FullName == typeof(CatProducttypeBR).FullName)
                return new CatProducttypeBR();
            if (type.FullName == typeof(CatProvinceBR).FullName)
                return new CatProvinceBR();
            if (type.FullName == typeof(CatSalestaffBR).FullName)
                return new CatSalestaffBR();
            if (type.FullName == typeof(CatStoreBR).FullName)
                return new CatStoreBR();
            if (type.FullName == typeof(CatStoretypeBR).FullName)
                return new CatStoretypeBR();
            if (type.FullName == typeof(CatSupplierBR).FullName)
                return new CatSupplierBR();
            if (type.FullName == typeof(CatUnitBR).FullName)
                return new CatUnitBR();
            if (type.FullName == typeof(CusConversationBR).FullName)
                return new CusConversationBR();
            if (type.FullName == typeof(FinImportpaymentBR).FullName)
                return new FinImportpaymentBR();
            if (type.FullName == typeof(FinMoneyslipBR).FullName)
                return new FinMoneyslipBR();
            if (type.FullName == typeof(FinReceiptBR).FullName)
                return new FinReceiptBR();
            if (type.FullName == typeof(FinReceivepaymentBR).FullName)
                return new FinReceivepaymentBR();
            if (type.FullName == typeof(FinSupplierreturnReceiptBR).FullName)
                return new FinSupplierreturnReceiptBR();
            if (type.FullName == typeof(ProducttypeCustomerBR).FullName)
                return new ProducttypeCustomerBR();
            if (type.FullName == typeof(SelInvoiceBR).FullName)
                return new SelInvoiceBR();
            if (type.FullName == typeof(SelInvoiceDetailBR).FullName)
                return new SelInvoiceDetailBR();
            if (type.FullName == typeof(SelInvoiceReceiptBR).FullName)
                return new SelInvoiceReceiptBR();
            if (type.FullName == typeof(SelReceiveproductBR).FullName)
                return new SelReceiveproductBR();
            if (type.FullName == typeof(SelReceiveproductDetailBR).FullName)
                return new SelReceiveproductDetailBR();
            if (type.FullName == typeof(StaffMgntgroupBR).FullName)
                return new StaffMgntgroupBR();
            if (type.FullName == typeof(StaffProducttypeBR).FullName)
                return new StaffProducttypeBR();
            if (type.FullName == typeof(StoExchangeBR).FullName)
                return new StoExchangeBR();
            if (type.FullName == typeof(StoExchangeDetailBR).FullName)
                return new StoExchangeDetailBR();
            if (type.FullName == typeof(StoExportBR).FullName)
                return new StoExportBR();
            if (type.FullName == typeof(StoExportDetailBR).FullName)
                return new StoExportDetailBR();
            if (type.FullName == typeof(CatChanelBR).FullName)
                return new CatChanelBR();
            if (type.FullName == typeof(CatConvresultBR).FullName)
                return new CatConvresultBR();
            if (type.FullName == typeof(CusConversationBR).FullName)
                return new CusConversationBR();
            if (type.FullName == typeof(AdmContextBR).FullName)
                return new AdmContextBR();
            if (type.FullName == typeof(AdmMapBR).FullName)
                return new AdmMapBR();
            if (type.FullName == typeof(AdmRoleBR).FullName)
                return new AdmRoleBR();
            if (type.FullName == typeof(AdmRolecontextBR).FullName)
                return new AdmRolecontextBR();
            if (type.FullName == typeof(AdmRoleserviceBR).FullName)
                return new AdmRoleserviceBR();
            if (type.FullName == typeof(AdmServiceBR).FullName)
                return new AdmServiceBR();
            if (type.FullName == typeof(AdmUserBR).FullName)
                return new AdmUserBR();
            if (type.FullName == typeof(AdmUserroleBR).FullName)
                return new AdmUserroleBR();
            if (type.FullName == typeof(LoginSessionBR).FullName)
                return new LoginSessionBR();
            if (type.FullName == typeof(BuyGuaranteeDetailBR).FullName)
                return new BuyGuaranteeDetailBR();
            if (type.FullName == typeof(CatGuaranteestatusBR).FullName)
                return new CatGuaranteestatusBR();
            if (type.FullName == typeof(CatReceipttypeBR).FullName)
                return new CatReceipttypeBR();
            if (type.FullName == typeof(GuarReturnBR).FullName)
                return new GuarReturnBR();
            if (type.FullName == typeof(AdmRightBR).FullName)
                return new AdmRightBR();
            return null;
        }
    }
}