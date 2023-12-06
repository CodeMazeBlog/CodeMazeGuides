using ConversionsInCSharp;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

// basic examples
Console.WriteLine("Some basic examples");
Utilities.ConvertIntToOtherTypes(4);
Console.WriteLine();

// POSSIBLE CONVERSION OUTCOMES

// successful widening conversion: int -> long
Console.WriteLine("Successful widening conversion");
Utilities.MakeConversion(Convert.ToInt64, 1500);
Console.WriteLine();

// successful narrowing conversion: long -> int
Console.WriteLine("Successful narrowing conversion");
Utilities.MakeConversion(Convert.ToInt32, 1500L);
Console.WriteLine();

// unsuccessful narrowing conversion - OverflowException long -> int
Console.WriteLine("Unsuccessful narrowing conversion - OverflowException");
Utilities.MakeConversion(Convert.ToInt32, 10_000_000_000L);
Console.WriteLine();

// unsuccessful conversion - InvalidCastException char -> bool
Console.WriteLine("Unsuccessful conversion - InvalidCastException");
Utilities.MakeConversion(Convert.ToBoolean, 'a');
Console.WriteLine();

// unsuccessful conversion - FormatException string -> char
Console.WriteLine("Unsuccessful conversion - FormatException");
Utilities.MakeConversion(Convert.ToChar, "hey");
Console.WriteLine();

// unsuccessful conversion - FormatException string -> int
Console.WriteLine("Unsuccessful conversion - FormatException");
Utilities.MakeConversion(Convert.ToInt32, "125s");
Console.WriteLine();

// no conversion int -> int
Console.WriteLine("No conversion");
Utilities.MakeConversion(Convert.ToInt32, 10);
Console.WriteLine();

// loss of precision double -> float
Console.WriteLine("Loss of precision");
Utilities.MakeConversion(Convert.ToSingle, 246.123456789);
Console.WriteLine();

// loss of precision float -> int
Console.WriteLine("Loss of precision");
Utilities.MakeConversion(Convert.ToInt32, 56.91f);
Console.WriteLine();

// NUMERIC CONVERSIONS

Console.WriteLine("Numeric conversions");
Utilities.MakeConversion(Convert.ToByte, 125);
Utilities.MakeConversion(Convert.ToDecimal, 125); 
Utilities.MakeConversion(Convert.ToByte, 125u);
Utilities.MakeConversion(Convert.ToInt16, 125);
Utilities.MakeConversion(Convert.ToInt32, 125u);
Utilities.MakeConversion(Convert.ToSByte, 125L);
Utilities.MakeConversion(Convert.ToUInt32, 125);
Console.WriteLine();

// CONVERSIONS TO STRINGS

Console.WriteLine("Conversions to strings");
Utilities.MakeConversion(Convert.ToString, true);
Utilities.MakeConversion(Convert.ToString, 4.56f); 
Utilities.MakeConversion(Convert.ToString, 'c');
Utilities.MakeConversion(Convert.ToString, new DateTime());
Utilities.MakeConversion(Convert.ToString, new Random());
Console.WriteLine();


// BASE 64 ENCODING

Console.WriteLine("Base64 encoding");
byte[] bytes = [5, 10, 15, 20, 25, 30];
Utilities.MakeConversion(Convert.ToBase64String, bytes);
Console.WriteLine();

// NON-DECIMAL NUMBERS

Console.WriteLine("Integral types in different number systems - to string");
Utilities.ConvertToStringWithBase(100, 2);
Utilities.ConvertToStringWithBase(100, 8);
Utilities.ConvertToStringWithBase(100, 10);
Utilities.ConvertToStringWithBase(100, 16);
Utilities.ConvertToStringWithBase(100, 3);
Console.WriteLine();

Console.WriteLine("Integral types in different number systems - from string");
Utilities.ConvertFromStringWithBase("1010", 2);
Utilities.ConvertFromStringWithBase("34", 8);
Utilities.ConvertFromStringWithBase("51", 10);
Utilities.ConvertFromStringWithBase("3A", 16);
Utilities.ConvertFromStringWithBase("65", 5);
Console.WriteLine();

// CONVERSIONS TO BOOLEANS 

// Numeric types
Console.WriteLine("Conversions to booleans - numeric types");
Utilities.MakeConversion(Convert.ToBoolean, 5);
Utilities.MakeConversion(Convert.ToBoolean, 0);
Utilities.MakeConversion(Convert.ToBoolean, -19.875);
Utilities.MakeConversion(Convert.ToBoolean, 4.65f);
Utilities.MakeConversion(Convert.ToBoolean, 170.54m);
Console.WriteLine();

// strings
Console.WriteLine("Conversions to booleans - strings");
Utilities.MakeConversion(Convert.ToBoolean, "True");
Utilities.MakeConversion(Convert.ToBoolean, "false");
Console.WriteLine();

// CONVERSIONS BETWEEN NUMERIC AND NON-NUMERIC TYPES

// bool to numeric
Console.WriteLine("Conversions from booleans to numeric types");
Utilities.MakeConversion(Convert.ToInt32, true);
Utilities.MakeConversion(Convert.ToInt32, false);
Console.WriteLine();

// string to numeric
Console.WriteLine("Conversions from strings to numeric types");
Utilities.MakeConversion(Convert.ToInt32, "128");
Utilities.MakeConversion(Convert.ToDouble, "1.83e3");
Console.WriteLine();

// char to numeric and numeric to char
Console.WriteLine("Conversions between chars and numeric types");
Utilities.MakeConversion(Convert.ToChar, 65);
Utilities.MakeConversion(Convert.ToChar, 41);
Utilities.MakeConversion(Convert.ToInt32, '&');
Console.WriteLine();

// CONVERSIONS WITH DATETIME

Console.WriteLine("Conversions with DateTime");
Utilities.MakeConversion(Convert.ToString, new DateTime(2023, 11, 27, 9, 45, 28));
Utilities.MakeConversion(Convert.ToDateTime, "8/2/2003 12:00:00 AM");
Utilities.MakeConversion(Convert.ToDateTime, "02 June 1985 3:20:17 AM");
Console.WriteLine();

// CONVERSIONS WITH IFORMATPROVIDER

Console.WriteLine("Conversions with IFormatProvider");
CultureInfo cultureDE = new("de-AT");
string deDate = "15/2/2021";

Console.WriteLine(
    $"Austrian culture: {deDate} --- US culture: {Convert.ToDateTime(deDate, cultureDE).ToShortDateString()}");

string deNumber = "280,99";

Console.WriteLine(
    $"Austrian culture: {deNumber} --- US culture: {Convert.ToDecimal(deNumber, cultureDE)}");

Console.WriteLine();

// CONVERSIONS FROM CUSTOM OBJECTS

Console.WriteLine("Conversions from the custom Note type");
Note note = new('C');
Utilities.MakeConversion(Convert.ToBoolean, note);
Utilities.MakeConversion(Convert.ToInt64, note);
Utilities.MakeConversion(Convert.ToChar, note);