using TnHSell.DT;
using TnHSell.DTContract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Util;

namespace TnHSell.Controllers
{
    public class TreeDataController : ApiController
    {
        AdmMapDT mapDt = new AdmMapDT();
        AdmContextDT contextDt = new AdmContextDT();
        [Route("TreeData/CreateTreeMap")]
        [HttpGet, HttpPost]
        public HttpResponseMessage CreateTreeMap()
        {
            try
            {
                DataTable dt = mapDt.GetAll();
                if (dt != null)
                {
                    List<KendoTreeNode> treeNodes = new List<KendoTreeNode>();
                    DataRow[] firstLevelRows = dt.Select("PathLevel=1", "OrderNum ASC");
                    foreach (DataRow row in firstLevelRows)
                    {
                        treeNodes.Add(BuildTreeNode(row, dt));
                    }
                    return Request.CreateResponse<string>(HttpStatusCode.OK, JsonConvert.SerializeObject(treeNodes));
                }
                return Request.CreateResponse<string>(HttpStatusCode.OK, "");
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }
        KendoTreeNode BuildTreeNode(DataRow parentRow, DataTable dt)
        {
            KendoTreeNode node = BuildSingleTreeNode(parentRow);
            DataRow[] childRows = dt.Select("ParentID=" + parentRow["ID"].ToString(), "OrderNum ASC");
            if (childRows.Length == 0)
            {
                DataTable leafTable = contextDt.GetComboboxData("ID, Name, OrderNum", "MapID=" + parentRow["ID"].ToString());
                if (leafTable != null)
                {
                    foreach (DataRow leafRow in leafTable.Select("", "OrderNum ASC"))
                        node.items.Add(BuildSingleTreeNode(leafRow, true));
                }
            }
            else
            {
                foreach (DataRow childRow in childRows)
                {
                    node.items.Add(BuildTreeNode(childRow, dt));
                }
            }
            return node;
        }

        KendoTreeNode BuildSingleTreeNode(DataRow row, bool isContextNode = false)
        {
            KendoTreeNode result = new KendoTreeNode();
            result.id = isContextNode ? (int)row["ID"] + 100000 : (int)row["ID"];
            result.text = row["Name"].ToString();
            result.expanded = "true";
            result.spriteCssClass = "";
            return result;
        }
    }
}
