namespace FreightHepler
{
    using System;
    using System.Runtime.InteropServices;

    public class SysDateTime
    {
        public static bool AsyncBeijingTime()
        {
            DateTime serverDate = MyWebService.Instance.GetServerDate();
            if (serverDate != DateTime.MinValue)
            {
                Set(serverDate);
                return true;
            }
            return false;
        }

        [DllImport("Kernel32.dll")]
        public static extern void GetSystemTime(ref SystemTime sysTime);
        public static void Set(DateTime dateTime)
        {
            try
            {
                DateTime time = dateTime.ToUniversalTime();
                SystemTime sysTime = new SystemTime {
                    wYear = (ushort) time.Year,
                    wMonth = (ushort) time.Month,
                    wDay = (ushort) time.Day,
                    wHour = (ushort) time.Hour,
                    wMinute = (ushort) time.Minute,
                    wSecond = (ushort) time.Second,
                    wMiliseconds = (ushort) time.Millisecond
                };
                SetSystemTime(ref sysTime);
            }
            catch
            {
            }
        }

        [DllImport("Kernel32.dll")]
        public static extern bool SetSystemTime(ref SystemTime sysTime);

        [StructLayout(LayoutKind.Sequential)]
        public struct SystemTime
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMiliseconds;
        }
    }
}

