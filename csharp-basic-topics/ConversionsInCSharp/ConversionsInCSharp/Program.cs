using ConversionsInCSharp;
using System.Globalization;

// basic examples
Console.WriteLine("Some basic examples");
Console.WriteLine(Utilities.ConvertIntToOtherTypes(4));
Console.WriteLine();

// POSSIBLE CONVERSION OUTCOMES

// successful widening conversion: int -> long
Console.WriteLine("Successful widening conversion");
Console.WriteLine(Utilities.MakeConversion(Convert.ToInt64, 1500));
Console.WriteLine();

// successful narrowing conversion: long -> int
Console.WriteLine("Successful narrowing conversion");
Console.WriteLine(Utilities.MakeConversion(Convert.ToInt32, 1500L));
Console.WriteLine();

// unsuccessful narrowing conversion - OverflowException long -> int
Console.WriteLine("Unsuccessful narrowing conversion - OverflowException");
Console.WriteLine(Utilities.MakeConversion(Convert.ToInt32, 10_000_000_000L));
Console.WriteLine();

// unsuccessful conversion - InvalidCastException char -> bool
Console.WriteLine("Unsuccessful conversion - InvalidCastException");
Console.WriteLine(Utilities.MakeConversion(Convert.ToBoolean, 'a'));
Console.WriteLine();

// unsuccessful conversion - FormatException string -> char
Console.WriteLine("Unsuccessful conversion - FormatException");
Console.WriteLine(Utilities.MakeConversion(Convert.ToChar, "hey"));
Console.WriteLine();

// unsuccessful conversion - FormatException string -> int
Console.WriteLine("Unsuccessful conversion - FormatException");
Console.WriteLine(Utilities.MakeConversion(Convert.ToInt32, "125s"));
Console.WriteLine();

// no conversion int -> int
Console.WriteLine("No conversion");
Console.WriteLine(Utilities.MakeConversion(Convert.ToInt32, 10));
Console.WriteLine();

// loss of precision double -> float
Console.WriteLine("Loss of precision");
Console.WriteLine(Utilities.MakeConversion(Convert.ToSingle, 246.123456789));
Console.WriteLine();

// loss of precision float -> int
Console.WriteLine("Loss of precision");
Console.WriteLine(Utilities.MakeConversion(Convert.ToInt32, 56.91f));
Console.WriteLine();

// NUMERIC CONVERSIONS

Console.WriteLine("Numeric conversions");
Console.WriteLine(Utilities.MakeConversion(Convert.ToByte, 125));
Console.WriteLine(Utilities.MakeConversion(Convert.ToDecimal, 125));
Console.WriteLine(Utilities.MakeConversion(Convert.ToByte, 125u));
Console.WriteLine(Utilities.MakeConversion(Convert.ToInt16, 125));
Console.WriteLine(Utilities.MakeConversion(Convert.ToInt32, 125u));
Console.WriteLine(Utilities.MakeConversion(Convert.ToSByte, 125L));
Console.WriteLine(Utilities.MakeConversion(Convert.ToUInt32, 125));
Console.WriteLine();

// CONVERSIONS TO STRINGS

Console.WriteLine("Conversions to strings");
Console.WriteLine(Utilities.MakeConversion(Convert.ToString, true));
Console.WriteLine(Utilities.MakeConversion(Convert.ToString, 4.56f));
Console.WriteLine(Utilities.MakeConversion(Convert.ToString, 'c'));
Console.WriteLine(Utilities.MakeConversion(Convert.ToString, new DateTime()));
Console.WriteLine(Utilities.MakeConversion(Convert.ToString, new Random()));
Console.WriteLine();


// BASE 64 ENCODING

Console.WriteLine("Base64 encoding");
byte[] bytes = [5, 10, 15, 20, 25, 30];
Console.WriteLine(Utilities.MakeConversion(Convert.ToBase64String, bytes));
Console.WriteLine();

// NON-DECIMAL NUMBERS

Console.WriteLine("Integral types in different number systems - to string");
Console.WriteLine(Utilities.ConvertToStringWithBase(100, 2));
Console.WriteLine(Utilities.ConvertToStringWithBase(100, 8));
Console.WriteLine(Utilities.ConvertToStringWithBase(100, 10));
Console.WriteLine(Utilities.ConvertToStringWithBase(100, 16));
Console.WriteLine(Utilities.ConvertToStringWithBase(100, 3));
Console.WriteLine();

Console.WriteLine("Integral types in different number systems - from string");
Console.WriteLine(Utilities.ConvertFromStringWithBase("1010", 2));
Console.WriteLine(Utilities.ConvertFromStringWithBase("34", 8));
Console.WriteLine(Utilities.ConvertFromStringWithBase("51", 10));
Console.WriteLine(Utilities.ConvertFromStringWithBase("3A", 16));
Console.WriteLine(Utilities.ConvertFromStringWithBase("65", 5));
Console.WriteLine();

// CONVERSIONS TO BOOLEANS 

// Numeric types
Console.WriteLine("Conversions to booleans - numeric types");
Console.WriteLine(Utilities.MakeConversion(Convert.ToBoolean, 5));
Console.WriteLine(Utilities.MakeConversion(Convert.ToBoolean, 0));
Console.WriteLine(Utilities.MakeConversion(Convert.ToBoolean, -19.875));
Console.WriteLine(Utilities.MakeConversion(Convert.ToBoolean, 4.65f));
Console.WriteLine(Utilities.MakeConversion(Convert.ToBoolean, 170.54m));
Console.WriteLine();

// strings
Console.WriteLine("Conversions to booleans - strings");
Console.WriteLine(Utilities.MakeConversion(Convert.ToBoolean, "True"));
Console.WriteLine(Utilities.MakeConversion(Convert.ToBoolean, "false"));
Console.WriteLine();

// CONVERSIONS BETWEEN NUMERIC AND NON-NUMERIC TYPES

// bool to numeric
Console.WriteLine("Conversions from booleans to numeric types");
Console.WriteLine(Utilities.MakeConversion(Convert.ToInt32, true));
Console.WriteLine(Utilities.MakeConversion(Convert.ToInt32, false));
Console.WriteLine();

// string to numeric
Console.WriteLine("Conversions from strings to numeric types");
Console.WriteLine(Utilities.MakeConversion(Convert.ToInt32, "128"));
Console.WriteLine(Utilities.MakeConversion(Convert.ToDouble, "1.83e3"));
Console.WriteLine();

// char to numeric and numeric to char
Console.WriteLine("Conversions between chars and numeric types");
Console.WriteLine(Utilities.MakeConversion(Convert.ToChar, 65));
Console.WriteLine(Utilities.MakeConversion(Convert.ToChar, 41));
Console.WriteLine(Utilities.MakeConversion(Convert.ToInt32, '&'));
Console.WriteLine();

// CONVERSIONS WITH DATETIME

Console.WriteLine("Conversions with DateTime");
Console.WriteLine(Utilities.MakeConversion(Convert.ToString, new DateTime(2023, 11, 27, 9, 45, 28)));
Console.WriteLine(Utilities.MakeConversion(Convert.ToDateTime, "8/2/2003 12:00:00 AM"));
Console.WriteLine(Utilities.MakeConversion(Convert.ToDateTime, "02 June 1985 3:20:17 AM"));
Console.WriteLine();

// CONVERSIONS WITH IFORMATPROVIDER

Console.WriteLine("Conversions with IFormatProvider");

var culture = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

CultureInfo cultureDE = new("de-AT");
var deDate = "15/2/2021";

Console.WriteLine(
    $"Austrian culture: {deDate} --- US culture: {Convert.ToDateTime(deDate, cultureDE).ToShortDateString()}");

var deNumber = "280,99";

Console.WriteLine(
    $"Austrian culture: {deNumber} --- US culture: {Convert.ToDecimal(deNumber, cultureDE)}");

Console.WriteLine();

// CONVERSIONS FROM CUSTOM OBJECTS

Console.WriteLine("Conversions from the custom Note type");
Note note = new('C');
Console.WriteLine(Utilities.MakeConversion(Convert.ToBoolean, note));
Console.WriteLine(Utilities.MakeConversion(Convert.ToInt64, note));
Console.WriteLine(Utilities.MakeConversion(Convert.ToChar, note));