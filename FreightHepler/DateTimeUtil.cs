namespace FreightHepler
{
    using System;

    public class DateTimeUtil
    {
        public static DateTime Now()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        public static DateTime Parse(string date, string format)
        {
            date = date.Replace(" ", string.Empty);
            return DateTime.ParseExact(date, format, null);
        }

        public static DateTime SimpleDate(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }

        public static bool TimeInRangle(DateTime time, int index)
        {
            if (index == 1)
            {
                return (((time.Hour < 0) || (time.Hour > 6)) ? ((time.Hour == 6) && (time.Minute == 0)) : true);
            }
            if (index == 2)
            {
                return (((time.Hour < 6) || (time.Hour > 12)) ? ((time.Hour == 12) && (time.Minute == 0)) : true);
            }
            if (index == 3)
            {
                return (((time.Hour < 12) || (time.Hour > 0x12)) ? ((time.Hour == 0x12) && (time.Minute == 0)) : true);
            }
            if (index == 4)
            {
                return (((time.Hour < 0x12) || (time.Hour > 0x17)) ? ((time.Hour == 0) && (time.Minute == 0)) : true);
            }
            return true;
        }

        public static bool TimeInRangle(DateTime time, string textRange)
        {
            try
            {
                textRange = string.IsNullOrEmpty(textRange) ? "00:00--00:00" : textRange;
                textRange = textRange.Replace("--00:00", "--24:00");
                string[] strArray2 = textRange.Split(new string[] { ":", "--" }, 4, StringSplitOptions.RemoveEmptyEntries);
                int num = (time.Hour * 60) + time.Minute;
                int num2 = (int.Parse(strArray2[0]) * 60) + int.Parse(strArray2[1]);
                int num3 = (int.Parse(strArray2[2]) * 60) + int.Parse(strArray2[3]);
                return ((num >= num2) && (num <= num3));
            }
            catch
            {
                return true;
            }
        }
    }
}

