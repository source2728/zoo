using System;

public class TimeUtil
{
    public static long ConvertDateTimeToLong(DateTime time)
    {
        DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        return (long)(time - startTime).TotalSeconds;
    }

    public static DateTime ConvertLongToDateTime(long timeStamp)
    {
        DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        long lTime = long.Parse(timeStamp + "0000000");
        TimeSpan toNow = new TimeSpan(lTime);
        return dtStart.Add(toNow);
    }

    public static long CurrentTime()
    {
        return ConvertDateTimeToLong(DateTime.Now);
    }
}