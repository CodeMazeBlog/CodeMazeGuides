using DecimalPrecision;

decimal myDecimal = 123.456789M;

var stringFormatResult = StringFormat.SetPrecisionUsingStringFormat(myDecimal);
Console.WriteLine(stringFormatResult);

var stringFormatResultWithGlobalScope = StringFormat.SetPrecisionUsingStringFormat(myDecimal, 2);
Console.WriteLine(stringFormatResultWithGlobalScope);

var roundedValueFromMathRound = RoundingFunction.GetDecimalRoundValueUsingMathRound(myDecimal);
Console.WriteLine(roundedValueFromMathRound);

var roundedValueFromDecimalRound = RoundingFunction.GetDecimalRoundValueUsingDecimalRound(myDecimal);
Console.WriteLine(roundedValueFromDecimalRound);

var truncatedValue = RoundingFunction.GetDecimalRoundValueUsingDecimalTruncate(myDecimal);
Console.WriteLine(truncatedValue);