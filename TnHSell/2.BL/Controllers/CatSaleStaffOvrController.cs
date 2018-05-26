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
using Util;
using Util;

namespace TnHSell.Controller
{
    public class CatSaleStaffOvrController : ApiController
    {
        CatSalestaffDT staffDT = new CatSalestaffDT();
        StaffMgntgroupDT staffMgntGroupDT = new StaffMgntgroupDT();
        StaffProducttypeDT staffProductTypeDT = new StaffProducttypeDT();
        [Route("CatSaleStaffOvr/GetStaffMgntGroup")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetStaffMgntGroup(string staffId)
        {
            try
            {
                DataTable dt = staffMgntGroupDT.GetByCond("SaleStaffID=" + staffId);
                return Request.CreateResponse<string[]>(HttpStatusCode.OK, DataTableHelper.ExtractToStringArray(dt, "ManagementGroupID"));
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }

        [Route("CatSaleStaffOvr/GetStaffProductType")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetProductPrice(string staffId)
        {
            try
            {
                DataTable dt = staffProductTypeDT.GetByCond("SaleStaffID=" + staffId);
                return Request.CreateResponse<string[]>(HttpStatusCode.OK, DataTableHelper.ExtractToStringArray(dt, "ProductTypeID"));
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }

        [Route("CatSaleStaffOvr/SaveStaff")]
        [HttpGet, HttpPost]
        public HttpResponseMessage SaveProduct(string staffJson, string groupJson, string productTypeJson)
        {
            string staffId = "";
            SqlTransaction tran = DataProvider.beginTrans();
            try
            {
                CatSalestaffContract staff = JsonConvert.DeserializeObject<CatSalestaffContract>(staffJson);
                string[] mgntGroupIds = JsonConvert.DeserializeObject<string[]>(groupJson);
                string[] productTypeIds = JsonConvert.DeserializeObject<string[]>(productTypeJson);
                if (staff.Id > 0)
                {
                    staffId = staffDT.Update(staff, tran);
                }
                else
                {
                    staffId = staffDT.Insert(staff, tran);
                }
                deleteOldStaffGroup(staffId, tran);
                foreach (string groupID in mgntGroupIds)
                {
                    StaffMgntgroupContract staffMgntGroup = new StaffMgntgroupContract() { Salestaffid = Converter.ToInt32(staffId), Managementgroupid = Converter.ToInt32(groupID) };
                    staffMgntGroupDT.Insert(staffMgntGroup, tran);
                }
                deleteOldProductType(staffId, tran);
                foreach (string productTypeId in productTypeIds)
                {
                    StaffProducttypeContract staffProductypeContract = new StaffProducttypeContract() { Producttypeid = Converter.ToInt32(productTypeId), Salestaffid = Converter.ToInt32(staffId) };
                    staffProductTypeDT.Insert(staffProductypeContract, tran);
                }
                DataProvider.CommitTrans(tran);
            }
            catch (Exception e)
            {
                DataProvider.RollbackTrans(tran);
                ExceptionHandler.Log(e);
                return null;
            }
            return Request.CreateResponse<string>(HttpStatusCode.OK, staffId);
        }


        void deleteOldStaffGroup(string staffId, SqlTransaction tran)
        {
            try
            {
                staffMgntGroupDT.DeleteViaCond(StaffMgntgroupContract.Columns[(int)StaffMgntgroupColumns.SaleStaffID] + "  = " + staffId, tran);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        void deleteOldProductType(string staffId, SqlTransaction tran)
        {
            try
            {
                staffProductTypeDT.DeleteViaCond(StaffProducttypeContract.Columns[(int)StaffProducttypeColumns.SaleStaffID] + " = " + staffId, tran);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        string SaleStaffID = StaffMgntgroupContract.Columns[(int)StaffMgntgroupColumns.SaleStaffID];
    }
}
