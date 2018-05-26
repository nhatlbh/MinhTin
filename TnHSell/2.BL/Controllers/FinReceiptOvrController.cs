using DTA;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TnHSell.DT;
using TnHSell.DTContract;
using TnHSell.Model;
using Util;

namespace TnHSell.Controllers
{
    public class FinReceiptOvrController : ApiController
    {
        FinReceiptDT receiptDT = new FinReceiptDT();
        FinSupplierreturnReceiptDT suppReturnDT = new FinSupplierreturnReceiptDT();
        SelInvoiceReceiptDT invReceiptDT = new SelInvoiceReceiptDT();
        [Route("FinReceiptOvr/Save")]
        [HttpGet, HttpPost]
        public HttpResponseMessage Save(string type, string receiptJson, string receiptDetailJson)
        {
            SqlTransaction tran = DataProvider.beginTrans();
            try
            {
                FinReceiptContract receiptDTO = JsonConvert.DeserializeObject<FinReceiptContract>(receiptJson);
                int receiptId = receiptDTO.Id;
                if (receiptId == 0)
                {
                    {
                        receiptId = Converter.ToInt32(receiptDT.Insert(receiptDTO, tran));
                    }
                    if (type == "SellInvoice")
                    {
                        SaveInvReceipt(receiptId, receiptDetailJson, tran);
                    }
                    if (type == "SuppReturn")
                    {
                        SaveSuppReceipt(receiptId, receiptDetailJson, tran);
                    }
                }
                tran.Commit();
                return Request.CreateResponse<string>(HttpStatusCode.OK, receiptId.ToString());
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                tran.Rollback();
                return Request.CreateResponse<string>(HttpStatusCode.OK, "Lỗi: Không lưu thành công."); ;
            }
        }

        [Route("FinReceiptOvr/GetDetail")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetDetail(string receiptId)
        {
            try
            {
                ReceiptDetailDT rctDetailDT = new ReceiptDetailDT();
                DataTable dtReceipt = receiptDT.GetByCond("ID=" + receiptId);
                DataTable dtDetail = new DataTable();
                if (dtReceipt != null)
                {
                    if (dtReceipt.Rows[0]["Type"].ToString() == "1")
                    {
                        dtDetail = rctDetailDT.GetSellInvoiceReceipt(receiptId);
                    }
                    else if (dtReceipt.Rows[0]["Type"].ToString() == "2")
                    {
                        dtDetail = rctDetailDT.GetSuppReturnReceipt(receiptId);
                    }
                }
                return Request.CreateResponse<string>(HttpStatusCode.OK, JsonConvert.SerializeObject(dtDetail));
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return Request.CreateResponse<string>(HttpStatusCode.OK, "Lỗi: Không đọc được chi tiết phiếu thu."); ;
            }
        }

        [Route("FinReceiptOvr/GetSellInvoice")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetSellInvoice(string customerId)
        {
            try
            {
                ReceiptDetailDT rctDetailDT = new ReceiptDetailDT();
                DataTable dt = rctDetailDT.GetSellInvoice("CustomerId=" + customerId);
                return Request.CreateResponse<string>(HttpStatusCode.OK, JsonConvert.SerializeObject(dt));
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }
        [Route("FinReceiptOvr/GetSuppReturn")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetSuppReturn(string supplierId)
        {
            try
            {
                ReceiptDetailDT rctDetailDT = new ReceiptDetailDT();
                DataTable dt = rctDetailDT.GetSuppReturn("SupplierID=" + supplierId);
                return Request.CreateResponse<string>(HttpStatusCode.OK, JsonConvert.SerializeObject(dt));
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }


        [Route("FinReceiptOvr/GetCode")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetCode()
        {
            try
            {
                return Request.CreateResponse<string>(HttpStatusCode.OK, CodeModel.GetReceiptCode());
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }
        void SaveInvReceipt(int receiptId, string invReceiptJson, SqlTransaction tran)
        {
            try
            {
                SelInvoiceDT invDT = new SelInvoiceDT();
                List<SelInvoiceReceiptContract> invReceipts = JsonConvert.DeserializeObject<List<SelInvoiceReceiptContract>>(invReceiptJson);
                foreach (SelInvoiceReceiptContract invReceipt in invReceipts)
                {
                    invReceipt.Receiptid = receiptId;
                    invDT.Update(new string[] { " TotalDebt" }, new string[] { " TotalDebt-" + invReceipt.Total }, " ID=" + invReceipt.Invoiceid);
                    invReceiptDT.Insert(invReceipt, tran);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        void SaveSuppReceipt(int receiptId, string invReceiptJson, SqlTransaction tran)
        {
            try
            {
                BuySupplierreturnDT invDT = new BuySupplierreturnDT();
                List<FinSupplierreturnReceiptContract> suppReceipts = JsonConvert.DeserializeObject<List<FinSupplierreturnReceiptContract>>(invReceiptJson);
                foreach (FinSupplierreturnReceiptContract suppReceipt in suppReceipts)
                {
                    suppReceipt.Receiptid = receiptId;
                    invDT.Update(new string[] { " TotalDebt" }, new string[] { " TotalDebt-" + suppReceipt.Total }, " ID=" + suppReceipt.Supplierreturnid);
                    suppReturnDT.Insert(suppReceipt, tran);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
