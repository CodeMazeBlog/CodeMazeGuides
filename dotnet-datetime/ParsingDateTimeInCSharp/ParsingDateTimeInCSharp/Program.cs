using System.Globalization;
using ParsingDateTimeInCSharp;

const string DATESTRING_MMDDYYYY_HHMMSS = "1/15/2023 02:21:37";
const string DATESTRING_DDMYYYY_HHMMSS_TIME = "15/1/2023 02:21:37";
const string DATESTRING_MMDDYYYY = "1/15/2023";
const string DATESTRING_DDMMYYYY = "15/1/2023";
const string DATESTRING_DD_MM_YYYY = "15-01-2023";
const string DATESTRING_EST_TIMEZONE = "2023/1/15 14:21:37-05:00";
const string DATESTRING_DDMYYYY_HHMMSS = "15/1/2023 10:12:12";

const string DATEFORMAT_DD_MM_YYYY = "dd-MM-yyyy";
const string DATEFORMAT_DDMYYYY_HHMMSS = "dd/M/yyyy hh:mm:ss";
const string DATESTRING_YYYYMMDD_ROUNDTRIP = "2023-01-15T14:12:12.0000000Z";
const string DATEFORMAT_ROUNDTRIP = "o";

const string CULTURE_FR = "fr-FR";
const string CULTURE_EN_GB = "en-GB";

const DateTimeStyles STYLE_ASSUME_UNIVERSAL = DateTimeStyles.AssumeUniversal;
const DateTimeStyles STYLE_ADJUST_TO_UNIVERSAL = DateTimeStyles.AdjustToUniversal;
const DateTimeStyles STYLE_NONE = DateTimeStyles.None;
const DateTimeStyles STYLE_ROUND_TRIP = DateTimeStyles.RoundtripKind;

var cultureInvariant = CultureInfo.InvariantCulture;

string[] dateFormats = { "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", "yyyy-MM-dd'T'HH:mm:ss'Z'", "yyyyMMdd'T'HH:mm:ss.fff'Z'", "yyyyMMdd'T'HH:mm:ss'Z'", "dd-MM-yyyy HH:mm:ss", "dd/MM/yyyy HH:mm:ss" };
var dateStringKeyValuePairs = new Dictionary<string, string>
{
    { "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", "2023-01-15T14:12:12.000Z" },
    { "yyyy-MM-dd'T'HH:mm:ss'Z'", "2023-01-15T14:12:12Z" },
    { "yyyyMMdd'T'HH:mm:ss.fff'Z'", "20230115T14:12:12.000Z" },
    { "yyyyMMdd'T'HH:mm:ss'Z'", "20230115T14:12:12Z" },
    { "dd-MM-yyyy HH:mm:ss", "15-01-2023 14:12:12" },
    { "dd/MM/yyyy HH:mm:ss", "15/01/2023 14:12:12" }
};

/*
 * Printing the Current Culture
 */
DateTime date = new(2023, 1, 15, 14, 21, 37);
Console.WriteLine($"My current culture: {CultureInfo.CurrentCulture}");
Console.WriteLine($"My date in the current culture({CultureInfo.CurrentCulture}): {date}");

/*
 * Changing the Current Culture
 */
var culture = CultureInfo.GetCultureInfo("en-GB");
Console.WriteLine($"My date in the culture({culture}): {date.ToString(culture)}");
Console.WriteLine($"Current Culture: {Thread.CurrentThread.CurrentCulture.Name}");

#region Parse overloads

Console.WriteLine("\nOverload: Parse()");
try
{
    /*
     * Parse(String)
     */
    Console.WriteLine("\nOverload: Parse(String)");
    Console.WriteLine(ParseMethod.ParseWithStringInputParameter(DATESTRING_MMDDYYYY_HHMMSS)); /* Output under en-US: 1/15/2023 2:21:37 AM */

    /*
     * Parse(String, IFormatProvider)
     */
    Console.WriteLine("\nOverload: Parse(String, IFormatProvider)");
    Console.WriteLine(ParseMethod.ParseWithStringAndFormatProviderInputParameters(DATESTRING_DDMYYYY_HHMMSS_TIME, CULTURE_FR)); /* Output under en-US: 1/15/2023 2:21:37 AM */

    /*
     * Parse(String, IFormatProvider, DateTimeStyles)
     */
    Console.WriteLine("\nParse(String, IFormatProvider, DateTimeStyles)");
    Console.WriteLine(ParseMethod.ParseWithStringAndFormatProviderAndDateTimeStylesInputParameters(DATESTRING_DDMYYYY_HHMMSS_TIME, CULTURE_FR, STYLE_ASSUME_UNIVERSAL)); /* Output under en-US, host at UTC+01:00: 1/15/2023 3:21:37 AM */

    /*
     * Parse(ReadOnlySpan<Char>, IFormatProvider)
     */
    Console.WriteLine("\nParse(ReadOnlySpan<Char>, IFormatProvider)");
    Console.WriteLine(ParseMethod.ParseWithSpanAndFormatProviderInputParameters(DATESTRING_DDMYYYY_HHMMSS_TIME, CULTURE_FR)); /* Output under en-US: 1/15/2023 2:21:37 AM */

    /*
     * Parse(ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles)
     */
    Console.WriteLine("\nParse(ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles)");
    Console.WriteLine(ParseMethod.ParseWithSpanAndFormatProviderAndDateTimeStylesInputParameters(DATESTRING_DDMYYYY_HHMMSS_TIME, CULTURE_FR, STYLE_ASSUME_UNIVERSAL)); /* Output under en-US, host at UTC+01:00: 1/15/2023 3:21:37 AM */
}
catch (ArgumentNullException e)
{
    Console.WriteLine(e.Message);
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
}
catch (FormatException e)
{
    Console.WriteLine(e.Message);
}

#endregion

#region TryParse overloads

/*
 * TryParse(String, DateTime)
 */
Console.WriteLine("\nOverload: TryParse(String, DateTime)");
TryParseMethod.TryParseWithStringInputParameter(DATESTRING_MMDDYYYY, out var parsedDate);
Console.WriteLine(parsedDate); /* Output under en-US: 1/15/2023 12:00:00 AM */

/*
 * TryParse(String, IFormatProvider, DateTime)
 */
Console.WriteLine("\nOverload: TryParse(String, IFormatProvider, DateTime)");
TryParseMethod.TryParseWithStringAndFormatProviderInputParameters(DATESTRING_DDMMYYYY, CULTURE_EN_GB, out parsedDate);
Console.WriteLine(parsedDate); /* Output under en-US: 1/15/2023 12:00:00 AM */

/*
 * TryParse(String, IFormatProvider, DateTimeStyles, DateTime)
 */
Console.WriteLine("\nOverload: TryParse(String, IFormatProvider, DateTimeStyles, DateTime)");
TryParseMethod.TryParseWithStringAndFormatProviderAndDateTimeStylesInputParameters(DATESTRING_EST_TIMEZONE, CULTURE_EN_GB, STYLE_ADJUST_TO_UNIVERSAL, out parsedDate);
Console.WriteLine(parsedDate); /* Output under en-US: 1/15/2023 7:21:37 PM */

/*
 * TryParse(ReadOnlySpan<Char>, DateTime)
 */
Console.WriteLine("\nOverload: TryParse(ReadOnlySpan<Char>, DateTime)");
TryParseMethod.TryParseWithSpanInputParameter(DATESTRING_MMDDYYYY, out parsedDate);
Console.WriteLine(parsedDate); /* Output under en-US: 1/15/2023 12:00:00 AM */

/*
 * TryParse(ReadOnlySpan<Char>, IFormatProvider, DateTime)
 */
Console.WriteLine("\nOverload: TryParse(ReadOnlySpan<Char>, IFormatProvider, DateTime)");
TryParseMethod.TryParseWithSpanAndFormatProviderInputParameters(DATESTRING_DDMMYYYY, CULTURE_EN_GB, out parsedDate);
Console.WriteLine(parsedDate); /* Output under en-US: 1/15/2023 12:00:00 AM */

/*
 * TryParse(ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles, DateTime)
 */
Console.WriteLine("\nOverload: TryParse(ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles, DateTime)");
TryParseMethod.TryParseWithSpanAndFormatProviderAndDateTimeStylesInputParameters(DATESTRING_DDMMYYYY, CULTURE_EN_GB, STYLE_NONE, out parsedDate);
Console.WriteLine(parsedDate); /* Output under en-US: 1/15/2023 12:00:00 AM */

#endregion

#region ParseExact
/*
 * ParseExact(String, String, IFormatProvider)
 */
Console.WriteLine("\nOverload: ParseExact(String, String, IFormatProvider)");
Console.WriteLine(ParseExactMethod.ParseExactWithStringAndStringAndFormatProviderInputParameters(DATESTRING_DDMYYYY_HHMMSS, DATEFORMAT_DDMYYYY_HHMMSS, CULTURE_FR)); /* Output under en-US: 1/15/2023 10:12:12 AM */

/*
 * ParseExact(String, String, IFormatProvider, DateTimeStyles)
 */
Console.WriteLine("\nOverload: ParseExact(String, String, IFormatProvider, DateTimeStyles)");
Console.WriteLine(ParseExactMethod.ParseExactWithStringAndStringAndFormatProviderAndDateTimeStylesInputParameters(DATESTRING_YYYYMMDD_ROUNDTRIP, DATEFORMAT_ROUNDTRIP, CULTURE_FR, STYLE_ROUND_TRIP)); /* Output under en-US: 1/15/2023 2:12:12 PM */

/*
 * ParseExact(ReadOnlySpan<Char>, ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles)
 */
Console.WriteLine("\nOverload: ParseExact(ReadOnlySpan<Char>, ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles)");
Console.WriteLine(ParseExactMethod.ParseExactWithSpanAndSpanAndFormatProviderAndDateTimeStylesInputParameters(DATESTRING_YYYYMMDD_ROUNDTRIP, DATEFORMAT_ROUNDTRIP, CULTURE_FR, STYLE_ROUND_TRIP)); /* Output under en-US: 1/15/2023 2:12:12 PM */

/*
 * ParseExact(String, String[], IFormatProvider, DateTimeStyles)
 */
Console.WriteLine("\nOverload: ParseExact(String, String[], IFormatProvider, DateTimeStyles)");
var resultParseExactKeyValuePair = ParseExactMethod.ParseExactWithStringAndStringArrayAndFormatProviderAndDateTimeStylesInputParameters(dateStringKeyValuePairs, dateFormats, cultureInvariant, STYLE_NONE);
foreach (var result in resultParseExactKeyValuePair)
{
    Console.WriteLine(result.Value);
}

/*
 * ParseExact(ReadOnlySpan<Char>, String[], IFormatProvider, DateTimeStyles)
 */
Console.WriteLine("\nOverload: ParseExact(ReadOnlySpan<Char>, String[], IFormatProvider, DateTimeStyles)");
resultParseExactKeyValuePair = ParseExactMethod.ParseExactWithSpanAndStringArrayAndFormatProviderAndDateTimeStylesInputParameters(dateStringKeyValuePairs, dateFormats, cultureInvariant, STYLE_NONE);
foreach (var result in resultParseExactKeyValuePair)
{
    Console.WriteLine(result.Value);
}

#endregion

#region TryParseExact

/*
 * TryParseExact(String, String, IFormatProvider, DateTimeStyles, DateTime)
 */
Console.WriteLine("\nOverload: TryParseExact(String, String, IFormatProvider, DateTimeStyles, DateTime)");
TryParseExactMethod.TryParseExactWithStringAndStringAndFormatProviderAndDateTimeStylesInputParameters(DATESTRING_DD_MM_YYYY, DATEFORMAT_DD_MM_YYYY, cultureInvariant, STYLE_NONE, out parsedDate);
Console.WriteLine(parsedDate); /* Output under en-US: 1/15/2023 12:00:00 AM */

/*
 * TryParseExact(ReadOnlySpan<Char>, ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles, DateTime)
 */
Console.WriteLine("\nOverload: TryParseExact(ReadOnlySpan<Char>, ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles, DateTime)");
TryParseExactMethod.TryParseExactWithSpanAndSpanAndFormatProviderAndDateTimeStylesInputParameters(DATESTRING_DD_MM_YYYY, DATEFORMAT_DD_MM_YYYY, cultureInvariant, STYLE_NONE, out parsedDate);
Console.WriteLine(parsedDate); /* Output under en-US: 1/15/2023 12:00:00 AM */

/*
 * TryParseExact(String, String[], IFormatProvider, DateTimeStyles, DateTime)
 */
Console.WriteLine("\nOverload: TryParseExact(String, String[], IFormatProvider, DateTimeStyles, DateTime)");
var resultTryParseExacKeyValuePair = TryParseExactMethod.TryParseExactWithStringAndStringArrayAndFormatProviderAndDateTimeStylesInputParameters(dateStringKeyValuePairs, dateFormats, cultureInvariant, STYLE_NONE);
foreach (var result in resultTryParseExacKeyValuePair)
{
    Console.WriteLine(result.Value);
}

/*
 * TryParseExact(ReadOnlySpan<Char>, String[], IFormatProvider, DateTimeStyles, DateTime)
 */
Console.WriteLine("\nOverload: TryParseExact(ReadOnlySpan<Char>, String[], IFormatProvider, DateTimeStyles, DateTime)");
resultTryParseExacKeyValuePair = TryParseExactMethod.TryParseExactWithSpanAndStringArrayAndFormatProviderAndDateTimeStylesInputParameters(dateStringKeyValuePairs, dateFormats, cultureInvariant, STYLE_NONE);
foreach (var result in resultTryParseExacKeyValuePair)
{
    Console.WriteLine(result.Value);
}

#endregion
