using DecimalPrecision;

var myDecimal = 123.456789M;

var stringFormatResult = StringFormat.FormatDecimalWithPrecision(myDecimal, "0.00");
Console.WriteLine(stringFormatResult);

var stringFormatResultWithGlobalScope = StringFormat.SetPrecisionUsingStringFormatInfo(myDecimal, 2);
Console.WriteLine(stringFormatResultWithGlobalScope);

var roundedValueFromMathRound = RoundingFunction.GetDecimalRoundValueUsingMathRound(myDecimal);
Console.WriteLine(roundedValueFromMathRound);

var roundedValueFromDecimalRound = RoundingFunction.GetDecimalRoundValueUsingDecimalRound(myDecimal);
Console.WriteLine(roundedValueFromDecimalRound);

var roundedValueToEven = RoundingFunction.GetDecimalRoundValuesUsingMidPointRoundingModelToEven(myDecimal);
Console.WriteLine(roundedValueToEven);

var roundedValueAwayFromZero = RoundingFunction.GetDecimalRoundValuesUsingMidPointRoundingModelAwayFromZero(myDecimal);
Console.WriteLine(roundedValueAwayFromZero);

var roundedValueToZero = RoundingFunction.GetDecimalRoundValuesUsingMidPointRoundingModelToZero(myDecimal);
Console.WriteLine(roundedValueToZero);

var truncatedValue = RoundingFunction.GetDecimalRoundValueUsingDecimalTruncate(myDecimal);
Console.WriteLine(truncatedValue);