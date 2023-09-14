var dateTime = DateTime.Now;
Console.WriteLine($"DateTime: {dateTime}"); 
var dateTimeOffset = DateTimeOffset.Now;
Console.WriteLine($"DateTimeOffset: {dateTimeOffset}"); 

//TimeZone vs Offset 
static List<TimeZoneInfo> GetTimeZoneFromOffset(TimeSpan offset) =>
    TimeZoneInfo.GetSystemTimeZones()
    .Where(tz => tz.BaseUtcOffset == offset)
    .ToList();
    
var timeZones = GetTimeZoneFromOffset(dateTimeOffset.Offset);
foreach (TimeZoneInfo timeZone in timeZones)
{
    Console.WriteLine($"Time Zone: {timeZone}");
} 
 
//Kind Property
var dateTimeUtc = DateTime.UtcNow; 
Console.WriteLine($"DateTime Kind: {dateTimeUtc.Kind}"); 
var dateTimeLocal = DateTime.Now; 
Console.WriteLine($"DateTime Kind: {dateTimeLocal.Kind}"); 
var dateTimeUnspecified = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified); 
Console.WriteLine($"DateTime Kind: {dateTimeUnspecified.Kind}"); 

var dateTimeOffsetUnspecified = DateTimeOffset.Now;
Console.WriteLine($"DateTimeOffset Kind: {dateTimeOffsetUnspecified.DateTime.Kind}");