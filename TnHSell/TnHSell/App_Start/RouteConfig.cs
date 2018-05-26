using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace TnHSell
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);

            routes.MapPageRoute("Blank", "page/init", "~/page/blank.aspx");

            //Customer
            routes.MapPageRoute("Customer", "dm/khachhang", "~/page/generated/catcustomer_list.aspx");
            routes.MapPageRoute("ManagementGroup", "dm/nhomquanly", "~/page/generated/catmanagementgroup_list.aspx");
            routes.MapPageRoute("Conversation", "dm/lichsugiaodich", "~/page/generated/cusconversation_list.aspx");
            routes.MapPageRoute("District", "dm/quan", "~/page/generated/catdistrict_list.aspx");
            routes.MapPageRoute("Province", "dm/tinh", "~/page/generated/catprovince_list.aspx");
            routes.MapPageRoute("Chanel", "dm/kenhlienlac", "~/page/generated/catchanel_list.aspx");
            routes.MapPageRoute("ConvResult", "dm/ketquagiaodich", "~/page/generated/catconvresult_list.aspx");


            //Product
            routes.MapPageRoute("Product", "dm/sanpham", "~/page/override/catproduct_list.aspx");
            routes.MapPageRoute("ProductType", "dm/loaisanpham", "~/page/generated/catproducttype_list.aspx");
            routes.MapPageRoute("ProductGroup", "dm/nhomsanpham", "~/page/generated/catproductgroup_list.aspx");
            routes.MapPageRoute("Manufacture", "dm/nhasanxuat", "~/page/generated/catmanufacture_list.aspx");
            routes.MapPageRoute("Supplier", "dm/nhacungcap", "~/page/generated/catsupplier_list.aspx");
            routes.MapPageRoute("Unit", "dm/donvitinh", "~/page/generated/catunit_list.aspx");
            routes.MapPageRoute("Color", "dm/mau", "~/page/generated/catcolor_list.aspx");

            //Store
            routes.MapPageRoute("Store", "dm/kho", "~/page/generated/catstore_list.aspx");
            routes.MapPageRoute("StoreType", "dm/loaikho", "~/page/generated/catstoretype_list.aspx");
            routes.MapPageRoute("StoreExchange", "kho/phieuchuyenkho", "~/page/override/stoexchange_list.aspx");
            routes.MapPageRoute("StoreExport", "kho/phieuxuathumat", "~/page/override/stoexport_list.aspx");


            //Others
            routes.MapPageRoute("SaleStaff", "dm/nhanvien", "~/page/override/catsalestaff_list.aspx");
            routes.MapPageRoute("ReceiptType", "dm/loaithu", "~/page/generated/CatReceipttype_List.aspx");
            routes.MapPageRoute("PaymentType", "dm/loaichi", "~/page/generated/catpaymenttype_list.aspx");
            routes.MapPageRoute("GuaranteeStatus", "dm/trangthaibaohanh", "~/page/generated/catguaranteestatus_list.aspx");
            routes.MapPageRoute("IOCode", "dm/manhapxuat", "~/page/generated/catiocode_list.aspx");
            routes.MapPageRoute("Branch", "dm/chinhanh", "~/page/generated/catbranch_list.aspx");


            //Buy
            routes.MapPageRoute("ImportInvoice", "mh/phieunhaphang", "~/page/override/buyimportinvoice_list.aspx");
            routes.MapPageRoute("SupplierReturn", "mh/phieutrahangncc", "~/page/override/buysupplierreturn_list.aspx");
            routes.MapPageRoute("PO", "mh/dondathang", "~/page/override/buypo_list.aspx");

            //Sell
            routes.MapPageRoute("Invoice", "bh/phieubanhang", "~/page/override/selinvoice_list.aspx");
            routes.MapPageRoute("ReceiveProduct", "bh/phieunhanhangtra", "~/page/override/selreceiveproduct_list.aspx");

            //Finance
            routes.MapPageRoute("Receipt", "nq/phieuthu", "~/page/override/finreceipt_list.aspx");
            routes.MapPageRoute("MoneySlip", "nq/phieuchi", "~/page/override/finmoneyslip_list.aspx");

            //Guarantee
            routes.MapPageRoute("Guarantee", "bhh/phieubaohanh", "~/page/override/BuyGuarantee_List.aspx");
            routes.MapPageRoute("GuarReturn", "bhh/trabaohanh", "~/page/override/GuarReturn_List.aspx");


            //Admin
            routes.MapPageRoute("User", "adm/nguoidung", "~/page/override/admuser_list.aspx");
            routes.MapPageRoute("Role", "adm/phanquyen", "~/page/override/admrole_list.aspx");
            routes.MapPageRoute("Map", "adm/map", "~/page/generated/admmap_list.aspx");
            routes.MapPageRoute("Context", "adm/context", "~/page/generated/admcontext_list.aspx");

        }
    }
}
