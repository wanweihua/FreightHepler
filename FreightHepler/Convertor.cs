namespace FreightHepler
{
    using System;

    public class Convertor
    {
        public static string DateTimeToString(DateTime dateTime_0)
        {
            string str = dateTime_0.ToString("yyyyMMdd");
            for (int i = 0; i < 30; i++)
            {
                if (str == DateTime.Now.AddDays((double) i).ToString("yyyyMMdd"))
                {
                    switch (i)
                    {
                        case 0:
                            return "今天";

                        case 1:
                            return "明天";

                        case 2:
                            return "后天";
                    }
                    return ("第" + (i + 1) + "天");
                }
            }
            return string.Empty;
        }

        public static DateTime ToDateTime(string value, string format)
        {
            DateTime minValue = DateTime.MinValue;
            try
            {
                minValue = DateTime.ParseExact(value, format, null);
            }
            catch
            {
            }
            return minValue;
        }

        public static decimal ToDecimal(string value)
        {
            decimal result = 0M;
            decimal.TryParse(value, out result);
            return result;
        }

        public static double ToDouble(string value)
        {
            double result = 0.0;
            double.TryParse(value, out result);
            return result;
        }

        public static float ToFloat(object value)
        {
            if (value != null)
            {
                return ToFloat(value.ToString());
            }
            return 0f;
        }

        public static float ToFloat(string value)
        {
            float result = 0f;
            float.TryParse(value, out result);
            return result;
        }

        public static int ToInt32(string value)
        {
            int result = 0;
            int.TryParse(value, out result);
            return result;
        }

        public static long ToLong(string value)
        {
            long result = 0L;
            long.TryParse(value, out result);
            return result;
        }
    }
}

