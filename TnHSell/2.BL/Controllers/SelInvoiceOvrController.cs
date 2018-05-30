using DTA;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TnHSell.BR;
using TnHSell.DT;
using TnHSell.DTContract;
using TnHSell.Model;
using Util;

namespace TnHSell.Controllers
{
    public class SelInvoiceOvrController : ApiController
    {
        SelInvoiceDT invoiceDT = new SelInvoiceDT();
        SelInvoiceDetailDT invoiceDetailDT = new SelInvoiceDetailDT();
        IBaseBR businessRule = BRFactory.GenerateBRObject(typeof(SelInvoiceBR));
        [Route("SelInvoiceOvr/Save")]
        [HttpGet, HttpPost]
        public HttpResponseMessage Save(string sellInvoceJson, string invoiceDetailsJson)
        {
            string invoiceId = "";
            string errMessage = "";
            SelInvoiceContract invoiceDTO = JsonConvert.DeserializeObject<SelInvoiceContract>(sellInvoceJson);
            SelInvoiceDetailContract[] invoiceDetailDTOs = JsonConvert.DeserializeObject<SelInvoiceDetailContract[]>(invoiceDetailsJson);
            SqlTransaction tran = DataProvider.beginTrans();
            try
            {
                businessRule.RegistInstants(invoiceDTO);
                if (invoiceDTO.Id > 0)
                {
                    invoiceId = invoiceDT.Update(invoiceDTO, tran);
                    changeDetail(invoiceDTO.Id, invoiceDTO.Code, (int)invoiceDTO.Storeid, invoiceDetailDTOs, tran);
                }
                else
                {
                    businessRule.RegistRule("Insert");
                    if (businessRule.CheckRules(out errMessage))
                        invoiceId = invoiceDT.Insert(invoiceDTO, tran);
                    else
                        return handleBRFailed(errMessage, tran);
                }
                if (Converter.ToInt32(invoiceId) > 0)
                {
                    invoiceDetailDT.DeleteViaCond("InvoiceId=" + invoiceId);
                    foreach (SelInvoiceDetailContract invoiceDetailDTO in invoiceDetailDTOs)
                    {
                        invoiceDetailDTO.Invoiceid = Converter.ToInt32(invoiceId);
                        invoiceDetailDT.Insert(invoiceDetailDTO, tran);
                        errMessage = StoreModel.Export(invoiceDTO.Storeid.ToString(), invoiceDTO.Code, Converter.ToInt32(invoiceDetailDTO.Quantity), invoiceDetailDTO.Productid.ToString(), tran);
                        if (errMessage != "")
                        {
                            DataProvider.RollbackTrans(tran);
                            return Request.CreateResponse<string>(HttpStatusCode.OK, errMessage);
                        }
                    }
                }
                DataProvider.CommitTrans(tran);
            }
            catch (Exception e)
            {
                DataProvider.RollbackTrans(tran);
                ExceptionHandler.Log(e);
            }
            return Request.CreateResponse<string>(HttpStatusCode.OK, errMessage != string.Empty ? errMessage : invoiceId);
        }
        [Route("SelInvoiceOvr/GetDetail")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetDetail(string invoiceId)
        {
            try
            {
                InvoiceDetailDT invDetailDT = new InvoiceDetailDT();
                DataTable dt = invDetailDT.GetGridData("SelInvoice", "InvoiceID=" + invoiceId, " OrderNum ASC");
                return Request.CreateResponse<string>(HttpStatusCode.OK, JsonConvert.SerializeObject(dt));
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }
        [Route("SelInvoiceOvr/GetProductPrice")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetProductPrice(string productId, string IOCodeId)
        {
            try
            {
                CatProductPriceDT priceDT = new CatProductPriceDT();
                DataTable dt = priceDT.GetByCond("ProductID=" + productId + " AND IOCodeID =" + IOCodeId);
                return Request.CreateResponse<string>(HttpStatusCode.OK, JsonConvert.SerializeObject(dt));
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }
        [Route("SelInvoiceOvr/GetInventory")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetInventory(string storeId, string productId)
        {
            try
            {
                return Request.CreateResponse<string>(HttpStatusCode.OK, StoreModel.GetInventory(storeId, productId));
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }
        [Route("SelInvoiceOvr/GetCode")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetCode()
        {
            try
            {
                return Request.CreateResponse<string>(HttpStatusCode.OK, CodeModel.GetSellInvoiceCode());
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }

        [Route("SelInvoiceOvr/Delete")]
        [HttpGet, HttpPost]
        public HttpResponseMessage Delete(string id)
        {
            SqlTransaction tran = DataProvider.beginTrans();
            try
            {
                string message = id;
                FinReceiptDT receiptDT = new FinReceiptDT();
                DataTable dtReceipt = receiptDT.GetByCond("InvoiceId=" + id);
                if (dtReceipt.Rows.Count > 0)
                {
                    message = "Lỗi: Phiếu bán hàng đã thu tiền, không thể xóa.";
                }
                else
                {
                    DataTable dtInvoice = invoiceDT.GetByID(id);
                    DataTable invoiceDetail = invoiceDetailDT.GetByCond("InvoiceId=" + id);
                    foreach (DataRow row in invoiceDetail.Rows)
                    {
                        string invCode = dtInvoice.Rows[0]["Code"].ToString();
                        int storeId = Converter.ToInt32(dtInvoice.Rows[0]["StoreId"]);
                        int productId = Converter.ToInt32(row["ProductId"]);
                        string quantity = row["ProductId"].ToString();
                        StoreModel.ChangeInvoice(invCode, storeId, productId, quantity, tran);
                        invoiceDetailDT.DeleteViaCond("InvoiceId=" + id, tran);
                        invoiceDT.Delete(id, tran);
                        tran.Commit();
                    }
                }
                return Request.CreateResponse<string>(HttpStatusCode.OK, message);
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                tran.Rollback();
                return Request.CreateResponse<string>(HttpStatusCode.OK, "");
            }
            finally {
                tran.Dispose();
            }
        }

        HttpResponseMessage handleBRFailed(string message, SqlTransaction tran)
        {
            try
            {
                DataProvider.RollbackTrans(tran);
                return Request.CreateResponse<string>(HttpStatusCode.OK, message);
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }
        void changeDetail(int invoiceId, string invoiceCode, int storeId, SelInvoiceDetailContract[] invoiceDetailDTOs, SqlTransaction tran)
        {
           DataTable dtOldInvDetail = invoiceDetailDT.GetByCond("InvoiceId=" + invoiceId);
            foreach (SelInvoiceDetailContract invDetail in invoiceDetailDTOs)
            {
                DataRow[] oldDetail = dtOldInvDetail.Select("ProductId=" + invDetail.Productid);
                int quantity = Converter.ToInt32(oldDetail[0]["Quantity"]) - Converter.ToInt32(invDetail.Quantity);
                if (quantity > 0)
                {
                    StoreModel.ChangeInvoice(invoiceCode, storeId, (int)invDetail.Productid, quantity.ToString(), tran);
                } 
            }                        
        }
    }
}
