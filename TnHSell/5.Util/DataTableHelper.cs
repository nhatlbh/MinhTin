using System.Collections.Generic;
using System.Data;

namespace Util
{
    public class DataTableHelper
    {
        public static string[] ExtractToStringArray(DataTable datatable, string colName)
        {
            List<string> result = new List<string>();
            if (datatable != null)
            {
                DataTable dtDistinct = Distinct(datatable, colName);
                foreach (DataRow row in dtDistinct.Rows)
                {
                    result.Add(row[colName].ToString());
                }
            }
            return result.ToArray();
        }

        public static DataTable Distinct(DataTable dt, string columns)
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
