using ConvertDateTimeToIso8601String;

var localTime = new DateTime(2022, 1, 13, 16, 25, 35, 125, DateTimeKind.Local);
var utcTime = new DateTime(2022, 1, 13, 16, 25, 35, 125, DateTimeKind.Utc);

// Sortable datetime format specifier
Console.WriteLine($"Local: {localTime.ToString("s")}"); // 2022-01-13T16:25:35
Console.WriteLine($"UTC: {utcTime.ToString("s")}");     // 2022-01-13T16:25:35

// Round-trip datetime format specifier
Console.WriteLine($"Local: {localTime.ToString("o")}"); // 2022-01-13T16:25:35.1250000+06:00
Console.WriteLine($"UTC: {utcTime.ToString("o")}");     // 2022-01-13T16:25:35.1250000Z

// Universal datetime format specifier
Console.WriteLine($"Local: {localTime.ToUniversalIso8601()}");  // 2022-01-13T10:25:35Z
Console.WriteLine($"UTC: {utcTime.ToUniversalIso8601()}");      // 2022-01-13T16:25:35Z

// Basic syntax for custom formats
var output = localTime.ToString("yyyy-MM-ddTHH:mm:ssK");

// ISO 8601 compliant custom formats
var customFormats = new[]
{
    "yyyy-MM-dd",
    "yyyyMMdd",
    "yyyy-MM",
    "--MM-dd",
    "--MMdd",
    "THH:mm:ss.fff",
    "THH:mm:ss",
    "THH:mm",
    "THH",
    "THHmmssfff",
    "yyyyMMddTHHmmssK",
    "yyyyMMddTHHmm",
    "yyyy-MM-ddTHH:mmZ",
    "yyyyMMddTHHmmsszzz",
    "yyyyMMddTHHmmsszz",
};

customFormats.ToList().ForEach(f => Console.WriteLine($"{f} \t {localTime.ToString(f)}"));

var format = "yyyy-MM-ddTHH:mm:ssK";
var unspecified = new DateTime(2022, 1, 13, 16, 25, 30, DateTimeKind.Unspecified);
var utc = new DateTime(2022, 1, 13, 16, 25, 30, DateTimeKind.Utc);
var local = new DateTime(2022, 1, 13, 16, 25, 30, DateTimeKind.Local);

Console.WriteLine(unspecified.ToString(format));            // 2022-01-13T16:25:30
Console.WriteLine(utc.ToString(format));                    // 2022-01-13T16:25:30Z
Console.WriteLine(local.ToString(format));                  // 2022-01-13T16:25:30+06:00
Console.WriteLine(local.ToString("yyyy-MM-ddTHH:mm:sszz")); // 2022-01-13T16:25:30+06

// Week dates - short form
Console.WriteLine(localTime.ToShortIso8601WeekDateString());                        // 2022-W03
Console.WriteLine(localTime.ToShortIso8601WeekDateString(useSeparator: false));     // 2022W03

// Week dates - extended form
Console.WriteLine(localTime.ToExtendedIso8601WeekDateString());                     // 2022-W03-4
Console.WriteLine(localTime.ToExtendedIso8601WeekDateString(useSeparator: false));  // 2022W034

// Ordinal dates
Console.WriteLine(localTime.ToIso8601OrdinalDateString());                      // 2022-013
Console.WriteLine(localTime.ToIso8601OrdinalDateString(useSeparator: false));   // 2022013