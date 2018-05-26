using System;

namespace Util
{
    public class Converter
    {
        public static int ToInt32(object value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public static int ToInt32(object value, int defaultValue)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch (Exception e)
            {
                return defaultValue;
            }
        }
        public static int? ToInt32(object value, int? defaultValue)
        {
            try
            {
                if (Convert.ToInt32(value) > 0)
                {
                    return Convert.ToInt32(value);
                }
                else
                    return defaultValue;
            }
            catch (Exception e)
            {
                return defaultValue;
            }
        }
        public static decimal ToDecimal(object value)
        {
            try
            {
                return Convert.ToDecimal(value);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public static decimal ToDecimal(object value, int defaultValue)
        {
            try
            {
                return Convert.ToDecimal(value);
            }
            catch (Exception e)
            {
                return defaultValue;
            }
        }
        public static string ToString(object value)
        {
            try
            {
                return value.ToString();
            }
            catch (Exception e)
            {
                return "";
            }
        }
        public static DateTime ToDateTime(object value)
        {
            try
            {
                return Convert.ToDateTime(value.ToString());
            }
            catch (Exception e)
            {
                return DateTime.MinValue;
            }
        }
        public static DateTime ToDateTime(object value, string format)
        {
            try
            {
                return DateTime.ParseExact(value.ToString(), format, null);
            }
            catch (Exception e)
            {
                return DateTime.MinValue;
            }
        }
        public static bool ToBoolean(object value)
        {
            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return false;
            }
        }
    }
}
