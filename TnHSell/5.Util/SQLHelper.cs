namespace Util
{
    public class SQLHelper
    {
        public static string RejectInjection(string sqlInput)
        {
            return sqlInput.Replace("'", "''");
        }
        public static string RejectValueInjection(string value)
        {
            if (value.IndexOf("'") == 0)
            {
                value = value.Remove(0,1).Remove(value.Length - 2);
                return "'" + value.Replace("'","''") + "'";
            }
            else if (value.IndexOf("N'") == 0)
            {
                value = value.Remove(0, 2).Remove(value.Length - 3);
                return "N'" + value.Replace("'", "''") + "'";
            }
            else
                return value;
        }
    }
}
