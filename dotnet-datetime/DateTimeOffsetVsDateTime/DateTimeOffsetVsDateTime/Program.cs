// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

DateTime dateTime = DateTime.Now;
Console.WriteLine($"DateTime: {dateTime}"); 
DateTimeOffset dateTimeOffset = DateTimeOffset.Now;
Console.WriteLine($"DateTimeOffset: {dateTimeOffset}"); 
//TimeZone vs Offset 
static List<TimeZoneInfo> GetTimeZoneFromOffset(TimeSpan offset) => TimeZoneInfo.GetSystemTimeZones().Where(tz => tz.BaseUtcOffset == offset).ToList();
var timeZones = GetTimeZoneFromOffset(dateTimeOffset.Offset);
foreach (TimeZoneInfo timeZone in timeZones)
{
    Console.WriteLine($"Time Zone: {timeZone}");
}    
DateTime dateTimeUtc = DateTime.UtcNow; 
Console.WriteLine($"DateTime Kind: {dateTimeUtc.Kind}"); 
DateTime dateTimeLocal = DateTime.Now; 
Console.WriteLine($"DateTime Kind: {dateTimeLocal.Kind}"); 
DateTime dateTimeUnspecified = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified); 
Console.WriteLine($"DateTime Kind: {dateTimeUnspecified.Kind}"); 
DateTimeOffset dateTimeOffsetUnspecified = DateTimeOffset.Now;
Console.WriteLine($"DateTimeOffset Kind: {dateTimeOffsetUnspecified.DateTime.Kind}");