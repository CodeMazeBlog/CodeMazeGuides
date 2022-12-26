namespace ActionAndFuncDelegatesInCSharp;

public class Program
{
    // Delegate definitions
    public delegate DateTime TimeConverter(DateTime dateTime, TimeZoneInfo timeZoneInfo);
    public delegate void LocalTimeAndZoneName(DateTime dateTime);

    /// <summary>
    /// Method returns no value
    /// Display Local Time Name and datetime
    /// </summary>
    /// <param name="dateTime">Current DateTime</param>
    public static void DisplayLocalTimeAndTimeZone(DateTime dateTime)
    {
        Console.WriteLine($"Time in {TimeZoneInfo.Local.DisplayName} is {dateTime}");
    }

    /// <summary>
    /// Method returns value
    /// Converting datetime by using TimeZoneInfo
    /// </summary>
    /// <param name="dateTime">Current DateTime</param>
    /// <param name="timeZoneInfo">TimeZoneInfo to convert to</param>
    /// <returns>Converted DateTime</returns>
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

        // Use Action to encapsulate method which doesn't return any value
        Action<DateTime> localTimeZoneNameAciton = DisplayLocalTimeAndTimeZone;
        // Use Func to encapsulate method which returns a value
        Func<DateTime, TimeZoneInfo, DateTime> timeConverterFunc = ConvertTimeByTimeZone;
        // Execute Action and Func
        localTimeZoneNameAciton(now);
        Console.WriteLine($"Time in {timeZoneName} is {timeConverterFunc(now, TimeZoneInfo.FindSystemTimeZoneById(timeZoneName))}");
    }
}