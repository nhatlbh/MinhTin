using System;
using System.Collections.Generic;
using System.Data;

namespace Util
{
    public static class DataTableEtension
    {
        public static List<string> ColToListString(this DataTable table, string colName)
        {
            try
            {
                List<string> result = new List<string>();
                foreach (DataRow row in table.Rows)
                {
                    result.Add(row[colName].ToString());
                }
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static DataTable Distinct(this DataTable dt, string columns)
        {
            if (dt != null)
            {
                DataView view = new DataView(dt);
                return view.ToTable(true, columns);
            }
            return dt;
        }
    }
}
