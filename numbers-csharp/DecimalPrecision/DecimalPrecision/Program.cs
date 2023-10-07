// See https://aka.ms/new-console-template for more information

using DecimalPrecision;

decimal myDecimal = 123.456789M;

var stringFormat = new StringFormat();
var roundingFunction = new RoundingFunction();

var stringFormatResult = stringFormat.SetPrecisionUsingStringFormat(myDecimal);
Console.WriteLine(stringFormatResult);

var stringFormatResultWithGlobalScope = stringFormat.SetPrecisionUsingStringFormatAndGlobalScope(myDecimal);
Console.WriteLine(stringFormatResultWithGlobalScope);

var roundedValueFromMathRound = roundingFunction.GetDecimalRoundValueUsingMathRound(myDecimal);
Console.WriteLine(roundedValueFromMathRound);

var roundedValueFromDecimalRound = roundingFunction.GetDecimalRoundValueUsingDecimalRound(myDecimal);
Console.WriteLine(roundedValueFromDecimalRound);

var truncatedValue = roundingFunction.GetDecimalRoundValueUsingDecimalTruncate(myDecimal);
Console.WriteLine(truncatedValue);