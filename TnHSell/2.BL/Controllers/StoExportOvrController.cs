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
    public class StoExportOvrController : ApiController
    {
        StoExportDT exportDT = new StoExportDT();
        StoExportDetailDT exportDetailDT = new StoExportDetailDT();
        IBaseBR businessRule = BRFactory.GenerateBRObject(typeof(StoExportBR));
        [Route("StoExportOvr/Save")]
        [HttpGet, HttpPost]
        public HttpResponseMessage Save(string exportJson, string exportDetailsJson)
        {
            string exportId = "";
            string errMessage = "";
            StoExportContract exportDTO = JsonConvert.DeserializeObject<StoExportContract>(exportJson);
            StoExportDetailContract[] exportDetailDTOs = JsonConvert.DeserializeObject<StoExportDetailContract[]>(exportDetailsJson);
            SqlTransaction tran = DataProvider.beginTrans();
            try
            {
                businessRule.RegistInstants(exportDTO);
                if (exportDTO.Id > 0)
                {
                    exportId = exportDT.Update(exportDTO, tran);
                }
                else
                {
                    businessRule.RegistRule("Insert");
                    if (businessRule.CheckRules(out errMessage))
                        exportId = exportDT.Insert(exportDTO, tran);
                    else
                        return handleBRFailed(errMessage, tran);
                }
                if (Converter.ToInt32(exportId) > 0)
                {
                    foreach (StoExportDetailContract exportDetailDTO in exportDetailDTOs)
                    {
                        exportDetailDTO.Exportid = Converter.ToInt32(exportId);
                        exportDetailDT.Insert(exportDetailDTO, tran);
                        errMessage = StoreModel.Export(exportDTO.Storeid.ToString(), exportDTO.Code, Converter.ToInt32(exportDetailDTO.Quantity), exportDetailDTO.Productid.ToString(), tran);
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
            return Request.CreateResponse<string>(HttpStatusCode.OK, errMessage != string.Empty ? errMessage : exportId);
        }

        [Route("StoExportOvr/GetDetail")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetDetail(string exportId)
        {
            try
            {
                InvoiceDetailDT invDetailDT = new InvoiceDetailDT();
                DataTable dt = invDetailDT.GetGridData("StoExport", "ExportId =" + exportId, " OrderNum ASC");
                return Request.CreateResponse<string>(HttpStatusCode.OK, JsonConvert.SerializeObject(dt));
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }

        [Route("StoExportOvr/GetCode")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetCode()
        {
            try
            {
                return Request.CreateResponse<string>(HttpStatusCode.OK, CodeModel.GetStoreExportCode());
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
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
    }
}
