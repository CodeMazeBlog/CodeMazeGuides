using BenchmarkDotNet.Running;
using ConvertHexadecimalToDecimal;

var hexVal = "7FFFFFFF";
var decimalVal = int.MaxValue;
ConversionExamples _conversionExamples = new();

Console.WriteLine("{0} converted to hexadecimal using ToString is {1}", decimalVal, _conversionExamples.DecimalToHexUsingToString(decimalVal));
Console.WriteLine("{0} converted to hexadecimal using String.Format is {1}", decimalVal, _conversionExamples.DecimalToHexUsingStringFormat(decimalVal));
Console.WriteLine("{0} converted to hexadecimal using Bitwise Method is {1}", decimalVal, _conversionExamples.DecimalToHexUsingBitwiseMethod(decimalVal));
Console.WriteLine("{0} converted to decimal using int.Parse is {1}", hexVal, _conversionExamples.HexToDecimalUsingParse(hexVal));
Console.WriteLine("{0} converted to decimal using Convert.Int32 is {1}", hexVal, _conversionExamples.HexToDecimalUsingParse(hexVal));
BenchmarkRunner.Run<ConversionExamples>();