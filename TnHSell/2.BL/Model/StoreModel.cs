using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TnHSell.DT;
using TnHSell.DTContract;
using Util;

namespace TnHSell.Model
{
    public class StoreModel
    {
        static CatProductStoreDT productStoreDT = new CatProductStoreDT();
        static LogProductexportDT productExportDT = new LogProductexportDT();
        public static void Import(BuyImportinvoiceContract importInvoiceDTO, BuyImportinvoiceDetailContract invoiceDetailDTO, SqlTransaction tran)
        {

            try
            {
                CatProductStoreContract productStoreDTO = new CatProductStoreContract();
                productStoreDTO.Importcode = importInvoiceDTO.Code;
                productStoreDTO.Importdate = importInvoiceDTO.Createdate;
                productStoreDTO.Storeid = importInvoiceDTO.CatStoreid;
                productStoreDTO.Productid = invoiceDetailDTO.Productid;
                productStoreDTO.Inventory = invoiceDetailDTO.Quantity;
                productStoreDTO.Quantity = invoiceDetailDTO.Quantity;
                productStoreDTO.Price = invoiceDetailDTO.Price;
                productStoreDTO.Ordernum = invoiceDetailDTO.Importinvoiceid.ToString();
                productStoreDT.Insert(productStoreDTO, tran);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static string Export(string storeId, string exportCode, int quantity, string productId, SqlTransaction tran)
        {
            try
            {
                DataTable storeProductTable = productStoreDT.GetByCond("ProductID=" + productId + " AND StoreID = " + storeId + " AND Quantity >0 ", "OrderNum ASC", tran);
                int tmpQuantity = 0;
                var totalQuantity = storeProductTable.Compute("SUM(Quantity)", "");
                if (Converter.ToInt32(totalQuantity) < quantity)
                {
                    return "Lỗi: Sản phẩm trong kho không đủ để xuất";
                }
                else
                    foreach (DataRow row in storeProductTable.Rows)
                    {
                        LogProductexportContract productExportDTO = new LogProductexportContract();
                        string storeProductId = row["ID"].ToString();
                        tmpQuantity += Converter.ToInt32(row["Quantity"]);
                        if (tmpQuantity < quantity)
                        {
                            productExportDTO.Storeid = storeId;
                            productExportDTO.Productid = productId;
                            productExportDTO.Importcode = row["ImportCode"].ToString();
                            productExportDTO.Quantity = row["Quantity"].ToString();
                            productExportDTO.Exportdate = DateTime.Now.ToString("dd/MM/yyyy");
                            productExportDTO.Exportcode = exportCode;
                            productExportDTO.Importprice = row["Price"].ToString();
                            productExportDTO.Exportprice = productId;
                            productExportDT.Insert(productExportDTO, tran);
                            productStoreDT.Update(new string[] { "Quantity" }, new string[] { "0" }, " ID=" + storeProductId, tran);
                        }
                        else
                        {
                            int exportQuantity = Converter.ToInt32(row["Quantity"]) - (tmpQuantity - quantity);
                            int productStoreQuantity = Converter.ToInt32(row["Quantity"]) - exportQuantity;
                            productExportDTO.Storeid = storeId;
                            productExportDTO.Productid = productId;
                            productExportDTO.Importcode = row["ImportCode"].ToString();
                            productExportDTO.Quantity = exportQuantity.ToString();
                            productExportDTO.Exportdate = DateTime.Now.ToString("dd/MM/yyyy");
                            productExportDTO.Exportcode = exportCode;
                            productExportDTO.Importprice = row["Price"].ToString();
                            productExportDTO.Exportprice = productId;
                            productExportDT.Insert(productExportDTO, tran);
                            productStoreDT.Update(new string[] { "Quantity" }, new string[] { productStoreQuantity.ToString() }, " ID=" + storeProductId, tran);
                            break;
                        }
                    }
            }
            catch (Exception e)
            {
                throw e;
            }
            return "";
        }
        public static string Exchange(StoExchangeContract storeExchangeDTO, StoExchangeDetailContract storeExchangeDetailDTO, SqlTransaction tran)
        {
            try
            {
                CatProductStoreContract productStoreDTO = new CatProductStoreContract();
                string storeCond = "StoreID=" + storeExchangeDTO.Fromstoreid + " AND ProductId=" + storeExchangeDetailDTO.Productid;
                DataTable fromStoreProductTable = productStoreDT.GetByCond(storeCond, " OrderNum ASC");
                var totalQuantity = fromStoreProductTable.Compute("SUM(Quantity)", "");
                if (Converter.ToInt32(totalQuantity) < Converter.ToInt32(storeExchangeDetailDTO.Quantity))
                {
                    return string.Format("Lỗi: Số lượng trong không đủ để chuyển.");
                }
                else if (storeExchangeDTO.Fromstoreid == storeExchangeDTO.Tostoreid)
                {
                    return "";
                }
                else
                {
                    int tmpQuantity = 0;
                    foreach (DataRow row in fromStoreProductTable.Rows)
                    {
                        tmpQuantity += Converter.ToInt32(row["Quantity"]);
                        if (tmpQuantity < Converter.ToInt32(storeExchangeDetailDTO.Quantity))
                        {
                            productStoreDTO.Importcode = row["ImportCode"].ToString();
                            productStoreDTO.Importdate = row["ImportDate"].ToString();
                            productStoreDTO.Storeid = storeExchangeDTO.Tostoreid;
                            productStoreDTO.Productid = storeExchangeDetailDTO.Productid;
                            productStoreDTO.Inventory = row["Quantity"].ToString();
                            productStoreDTO.Quantity = row["Quantity"].ToString();
                            productStoreDTO.Price = row["Price"].ToString();
                            productStoreDTO.Ordernum = row["OrderNum"].ToString();
                            productStoreDT.Insert(productStoreDTO, tran);
                            productStoreDT.Update(new string[] { "Quantity" }, new string[] { "0" }, "ID=" + row["ID"].ToString(), tran);
                        }
                        else
                        {
                            int exchangedQuantity = Converter.ToInt32(row["Quantity"]) - (tmpQuantity - Converter.ToInt32(storeExchangeDetailDTO.Quantity));
                            int rowNewQuantity = Converter.ToInt32(row["Quantity"]) - exchangedQuantity;
                            productStoreDTO.Importcode = row["ImportCode"].ToString();
                            productStoreDTO.Importdate = row["ImportDate"].ToString();
                            productStoreDTO.Storeid = storeExchangeDTO.Tostoreid;
                            productStoreDTO.Productid = storeExchangeDetailDTO.Productid;
                            productStoreDTO.Inventory = exchangedQuantity.ToString();
                            productStoreDTO.Quantity = exchangedQuantity.ToString();
                            productStoreDTO.Price = row["Price"].ToString();
                            productStoreDTO.Ordernum = row["OrderNum"].ToString();
                            productStoreDT.Insert(productStoreDTO, tran);
                            productStoreDT.Update(new string[] { "Quantity" }, new string[] { rowNewQuantity.ToString() }, "ID=" + row["ID"].ToString(), tran);
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return "";
        }
        public static void ReceiveProduct(SelReceiveproductContract receiveProductDTO, SelReceiveproductDetailContract receiveProductDetailDTO, SqlTransaction tran)
        {
            try
            {
                SelInvoiceDT invoiceDT = new SelInvoiceDT();
                DataTable dtInvoice = invoiceDT.GetByID(receiveProductDTO.Invoiceid.ToString());
                if (dtInvoice != null && dtInvoice.Rows.Count > 0)
                {
                    string invoiceCode = dtInvoice.Rows[0]["Code"].ToString();
                    returnStore(invoiceCode, (int)receiveProductDTO.Storeid, (int)receiveProductDetailDTO.Productid, receiveProductDetailDTO.Quantity, tran);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static void ChangeInvoice(string invoiceCode, int storeId, int productId, string quantity, SqlTransaction tran)
        {
            try
            {
                returnStore(invoiceCode, storeId, productId, quantity, tran);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string GetInventory(string storeId, string productId)
        {
            try
            {
                string cond = "StoreID=" + storeId + " AND ProductId=" + productId;
                DataTable dt = productStoreDT.GetByCond(cond);
                var inventory = dt.Compute("SUM(Quantity)", "");
                return inventory.ToString();
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return "0";
            }
        }

        static void returnStore(string invoiceCode, int storeId, int productId, string quantity, SqlTransaction tran)
        {
            string exportLogCond = "ExportCode='" + invoiceCode + "' AND ProductID=" + productId;
            DataTable dtExportLog = productExportDT.GetByCond(exportLogCond, "", tran);
            if (dtExportLog != null && dtExportLog.Rows.Count > 0)
            {
                string importCode = dtExportLog.Rows[0]["ImportCode"].ToString();
                string storeInventCond = "ImportCode='" + importCode + "' AND StoreID=" + storeId + " AND ProductID=" + productId;
                DataTable dtStoreInvent = productStoreDT.GetByCond(storeInventCond, "", tran);
                if (dtStoreInvent != null && dtStoreInvent.Rows.Count > 0)
                {
                    productStoreDT.Update(new string[] { "Quantity" }, new string[] { "Quantity+" + quantity }, storeInventCond, tran);
                }
                else
                {
                    CatProductStoreContract productStoreDTO = new CatProductStoreContract();
                    productStoreDTO.Importcode = importCode;
                    productStoreDTO.Importdate = DateTime.Now.ToString("dd/MM/yyyy");
                    productStoreDTO.Storeid = storeId;
                    productStoreDTO.Productid = productId;
                    productStoreDTO.Inventory = quantity;
                    productStoreDTO.Quantity = quantity;
                    productStoreDTO.Price = dtExportLog.Rows[0]["ImportPrice"].ToString();
                    productStoreDTO.Ordernum = "0";
                    productStoreDT.Insert(productStoreDTO, tran);
                }
                productExportDT.Update(new string[] { "Quantity" }, new string[] { "Quantity-" + quantity }, exportLogCond, tran);
            }
        }
    }
}