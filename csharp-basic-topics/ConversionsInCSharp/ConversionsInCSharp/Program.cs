using ConversionsInCSharp;
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
 
