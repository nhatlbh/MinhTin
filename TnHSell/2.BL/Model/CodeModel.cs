using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TnHSell.DT;
using Util;

namespace TnHSell.Model
{
    public class CodeModel
    {
        public static string GetSellInvoiceCode()
        {
            SelInvoiceDT sellInvoiceDT = new SelInvoiceDT();
            string mmyy = getMMyy();
            DataTable invoiceTable = sellInvoiceDT.GetByCond("Code like 'SI" + mmyy + "%'", " Code DESC");
            string prefix = "SI" + mmyy;
            string suffix = "0001";
            if (invoiceTable != null && invoiceTable.Rows.Count > 0)
            {
                suffix = getSuffix(invoiceTable.Rows[0]["Code"].ToString());
            }
            return prefix + suffix;
        }
        public static string GetImportInvoiceCode()
        {
            BuyImportinvoiceDT importInvoiceDT = new BuyImportinvoiceDT();
            string mmyy = getMMyy();
            DataTable invoiceTable = importInvoiceDT.GetByCond("Code like 'PN" + mmyy + "%'", " Code DESC");
            string prefix = "PN" + mmyy;
            string suffix = "0001";
            if (invoiceTable != null && invoiceTable.Rows.Count > 0)
            {
                suffix= getSuffix(invoiceTable.Rows[0]["Code"].ToString());
            }
            return prefix + suffix;
        }
        public static string GetSupplierReturnCode()
        {
            BuySupplierreturnDT  suppReturnDT = new BuySupplierreturnDT();
            string mmyy = getMMyy();
            DataTable invoiceTable = suppReturnDT.GetByCond("Code like 'XT" + mmyy + "%'", " Code DESC");
            string prefix = "XT" + mmyy;
            string suffix = "0001";
            if (invoiceTable != null && invoiceTable.Rows.Count > 0)
            {
                suffix = getSuffix(invoiceTable.Rows[0]["Code"].ToString());
            }
            return prefix + suffix;
        }
        public static string GetReceiveProductCode()
        {
            SelReceiveproductDT receiveProductDT = new SelReceiveproductDT();
            string mmyy = getMMyy();
            DataTable invoiceTable = receiveProductDT.GetByCond("Code like 'KT" + mmyy + "%'", " Code DESC");
            string prefix = "KT" + mmyy;
            string suffix = "0001";
            if (invoiceTable != null && invoiceTable.Rows.Count > 0)
            {
                suffix = getSuffix(invoiceTable.Rows[0]["Code"].ToString());
            }
            return prefix + suffix;
        }
        public static string GetReceiptCode()
        {
            FinReceiptDT receiptDT = new FinReceiptDT();
            string mmyy = getMMyy();
            DataTable invoiceTable = receiptDT.GetByCond("Code like 'PT" + mmyy + "%'", " Code DESC");
            string prefix = "PT" + mmyy;
            string suffix = "0001";
            if (invoiceTable != null && invoiceTable.Rows.Count > 0)
            {
                suffix = getSuffix(invoiceTable.Rows[0]["Code"].ToString());
            }
            return prefix + suffix;
        }
        public static string GetMoneySlipCode()
        {
            FinMoneyslipDT moneySlipDT = new FinMoneyslipDT();
            string mmyy = getMMyy();
            DataTable invoiceTable = moneySlipDT.GetByCond("Code like 'PC" + mmyy + "%'", " Code DESC");
            string prefix = "PC" + mmyy;
            string suffix = "0001";
            if (invoiceTable != null && invoiceTable.Rows.Count > 0)
            {
                suffix = getSuffix(invoiceTable.Rows[0]["Code"].ToString());
            }
            return prefix + suffix;
        }
        public static string GetStoreExchangeCode()
        {
            StoExchangeDT storeExchangeDT = new StoExchangeDT();
            string mmyy = getMMyy();
            DataTable invoiceTable = storeExchangeDT.GetByCond("Code like 'CK" + mmyy + "%'", " Code DESC");
            string prefix = "CK" + mmyy;
            string suffix = "0001";
            if (invoiceTable != null && invoiceTable.Rows.Count > 0)
            {
                suffix = getSuffix(invoiceTable.Rows[0]["Code"].ToString());
            }
            return prefix + suffix;
        }
        public static string GetStoreExportCode()
        {
            StoExchangeDT storeExchangeDT = new StoExchangeDT();
            string mmyy = getMMyy();
            DataTable invoiceTable = storeExchangeDT.GetByCond("Code like 'XH" + mmyy + "%'", " Code DESC");
            string prefix = "XH" + mmyy;
            string suffix = "0001";
            if (invoiceTable != null && invoiceTable.Rows.Count > 0)
            {
                suffix = getSuffix(invoiceTable.Rows[0]["Code"].ToString());
            }
            return prefix + suffix;
        }
        public static string GetGuaranteeCode()
        {
            BuyGuaranteeDT guaranteeDT = new BuyGuaranteeDT();
            string mmyy = getMMyy();
            DataTable invoiceTable = guaranteeDT.GetByCond("Code like 'BH" + mmyy + "%'", " Code DESC");
            string prefix = "BH" + mmyy;
            string suffix = "0001";
            if (invoiceTable != null && invoiceTable.Rows.Count > 0)
            {
                suffix = getSuffix(invoiceTable.Rows[0]["Code"].ToString());
            }
            return prefix + suffix;
        }
        public static string GetGuarReturnCode()
        {
            GuarReturnDT guarReturnDT = new GuarReturnDT();
            string mmyy = getMMyy();
            DataTable invoiceTable = guarReturnDT.GetByCond("Code like 'TK" + mmyy + "%'", " Code DESC");
            string prefix = "TK" + mmyy;
            string suffix = "0001";
            if (invoiceTable != null && invoiceTable.Rows.Count > 0)
            {
                suffix = getSuffix(invoiceTable.Rows[0]["Code"].ToString());
            }
            return prefix + suffix;
        }

        static string getMMyy()
        {
            string month = DateTime.Now.Month.ToString();
            month = month.Length < 2 ? "0" + month : month;
            string year = DateTime.Now.Year.ToString();
            year = year.Substring(2, 2);
            return year + month;
        }
        static string getSuffix(string code)
        {
            string suffix = "0000";
            int number = Converter.ToInt32(code.Substring(6, 4)) + 1;
            suffix = suffix.Substring(0, suffix.Length - number.ToString().Length) + number.ToString();
            return suffix;
        }
    }
}