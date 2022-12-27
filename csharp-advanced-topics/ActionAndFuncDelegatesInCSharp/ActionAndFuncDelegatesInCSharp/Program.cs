namespace ActionAndFuncDelegatesInCSharp;

public class Program
{
    // Delegate definitions
    public delegate void LocalTimeAndZoneName(DateTime dateTime);
    public delegate DateTime TimeConverter(DateTime dateTime, TimeZoneInfo timeZoneInfo);
    
    public static void DisplayLocalTimeAndTimeZone(DateTime dateTime)
    {
        Console.WriteLine($"Time in {TimeZoneInfo.Local.DisplayName} is {dateTime}");
    }

    public static DateTime ConvertTimeByTimeZone(DateTime dateTime, TimeZoneInfo timeZoneInfo)
    {
        return TimeZoneInfo.ConvertTime(DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified), timeZoneInfo);
    }

    public static void Main()
    {
        DateTime now = DateTime.Now;
        string timeZoneName = "Central Standard Time";
        // Use delegate to encapsulate method
        TimeConverter timeConverter = ConvertTimeByTimeZone;
        LocalTimeAndZoneName localTimeZoneName = DisplayLocalTimeAndTimeZone;
        // Execute delegates
        localTimeZoneName(now);
        Console.WriteLine($"Time in {timeZoneName} is {timeConverter(now, TimeZoneInfo.FindSystemTimeZoneById(timeZoneName))}");

        // Use Action and Func delegates
        Action<DateTime> localTimeZoneNameAciton = DisplayLocalTimeAndTimeZone;
        Func<DateTime, TimeZoneInfo, DateTime> timeConverterFunc = ConvertTimeByTimeZone;
        localTimeZoneNameAciton(now);
        Console.WriteLine($"Time in {timeZoneName} is {timeConverterFunc(now, TimeZoneInfo.FindSystemTimeZoneById(timeZoneName))}");
    }
}