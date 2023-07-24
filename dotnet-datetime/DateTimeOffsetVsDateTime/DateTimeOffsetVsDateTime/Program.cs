// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

DateTime dateTime = DateTime.Now; // Represents the current local time
Console.WriteLine($"DateTime: {dateTime}"); // DateTime: 6/28/2023 11:01:34 PM

DateTimeOffset dateTimeOffset = DateTimeOffset.Now; // Represents the current local time with offset information
Console.WriteLine($"DateTimeOffset: {dateTimeOffset}"); // DateTimeOffset: 6/28/2023 11:01:34 PM +02:00

//TimeZone vs Offset 
static List<TimeZoneInfo> GetTimeZoneFromOffset(TimeSpan offset)
{
    List<TimeZoneInfo> list = new List<TimeZoneInfo>();
    foreach (TimeZoneInfo item in TimeZoneInfo.GetSystemTimeZones())
    {
        if(item.BaseUtcOffset == offset)
        {
            list.Add(item);
        }
    }
    return list;
}

var timeZones = GetTimeZoneFromOffset(dateTimeOffset.Offset);
foreach (TimeZoneInfo timeZone in timeZones)
{
    Console.WriteLine($"Time Zone: {timeZone}");
}    



DateTime dateTimeUtc = DateTime.UtcNow; // Represents the current UTC time
Console.WriteLine($"DateTime Kind: {dateTimeUtc.Kind}"); // DateTime Kind: Utc

DateTime dateTimeLocal = DateTime.Now; // Represents the current local time
Console.WriteLine($"DateTime Kind: {dateTimeLocal.Kind}"); // DateTime Kind: Local

DateTime dateTimeUnspecified = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified); // Represents the current unspecified time
Console.WriteLine($"DateTime Kind: {dateTimeUnspecified.Kind}"); // DateTime Kind: Unspecified



DateTimeOffset dateTimeOffsetUnspecified = DateTimeOffset.Now; // Represents the current time
Console.WriteLine($"DateTimeOffset Kind: {dateTimeOffsetUnspecified.DateTime.Kind}"); // DateTime Kind: Unspecified




