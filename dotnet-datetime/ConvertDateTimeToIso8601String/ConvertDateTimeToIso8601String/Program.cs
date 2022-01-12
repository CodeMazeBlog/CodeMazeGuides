using ConvertDateTimeToIso8601String;

var localTime = new DateTime(2022, 1, 13, 16, 25, 35, 125, DateTimeKind.Local);
var utcTime = new DateTime(2022, 1, 13, 16, 25, 35, 125, DateTimeKind.Utc);

// Sortable datetime format specifier
Console.WriteLine($"Local: {localTime.ToString("s")}");
Console.WriteLine($"UTC: {utcTime.ToString("s")}");

// Round-trip datetime format specifier
Console.WriteLine($"Local: {localTime.ToString("o")}");
Console.WriteLine($"UTC: {utcTime.ToString("o")}");

// Universal datetime format specifier
Console.WriteLine($"Local: {localTime.ToUniversalIso8601()}");
Console.WriteLine($"UTC: {utcTime.ToUniversalIso8601()}");

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
};

customFormats.ToList().ForEach(f => Console.WriteLine($"{f} \t {localTime.ToString(f)}"));

var format = "yyyy-MM-ddTHH:mm:ssK";
Console.WriteLine(new DateTime(2022, 1, 13, 16, 25, 30, DateTimeKind.Unspecified).ToString(format));
Console.WriteLine(new DateTime(2022, 1, 13, 16, 25, 30, DateTimeKind.Local).ToString(format));
Console.WriteLine(new DateTime(2022, 1, 13, 16, 25, 30, DateTimeKind.Utc).ToString(format));

// Week dates - short form
Console.WriteLine(localTime.ToShortIso8601WeekDateString());
Console.WriteLine(localTime.ToShortIso8601WeekDateString(useSeparator: false));

// Week dates - extended form
Console.WriteLine(localTime.ToExtendedIso8601WeekDateString());
Console.WriteLine(localTime.ToExtendedIso8601WeekDateString(useSeparator: false));

// Ordinal dates
Console.WriteLine(localTime.ToIso8601OrdinalDateString());
Console.WriteLine(localTime.ToIso8601OrdinalDateString(useSeparator: false));
