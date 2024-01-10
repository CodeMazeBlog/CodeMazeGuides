using HowToAddSeparatorsInThousandsPlaceForANumber;
using System.Globalization;

var englishCultureInfo = new CultureInfo("en-US");
var spanishCultureInfo = new CultureInfo("es-ES");

var balanceMessage = NumbersFormatting.GetBalanceUsingTheStringFormatMethod();
Console.WriteLine(balanceMessage);

var balanceMessageWithCultureInfo =
    NumbersFormatting.GetBalanceUsingTheStringFormatMethodAndACultureInfo(englishCultureInfo);
Console.WriteLine(balanceMessageWithCultureInfo);

var balanceMessageWithSeparators =
    NumbersFormatting.GetBalanceUsingTheStringFormatMethodACultureInfoAndSpecifier(null, englishCultureInfo);
Console.WriteLine(balanceMessageWithSeparators);

var balanceMessageWithFourDecimalPlaces =
    NumbersFormatting.GetBalanceUsingTheStringFormatMethodACultureInfoAndSpecifier(4, englishCultureInfo);
Console.WriteLine(balanceMessageWithFourDecimalPlaces);

var balanceMessageWithoutDecimalPlaces =
    NumbersFormatting.GetBalanceUsingTheStringFormatMethodACultureInfoAndSpecifier(0, englishCultureInfo);
Console.WriteLine(balanceMessageWithoutDecimalPlaces);

var balanceMessageUsingToString = NumbersFormatting.GetBalanceUsingTheToStringMethod("n", null);
Console.WriteLine(balanceMessageUsingToString);

var balanceMessageUsingToStringeWithFourDecimalPlaces = NumbersFormatting.GetBalanceUsingTheToStringMethod("n4", null);
Console.WriteLine(balanceMessageUsingToStringeWithFourDecimalPlaces);

var balanceMessageUsingToStringWithoutDecimalPlaces = NumbersFormatting.GetBalanceUsingTheToStringMethod("n0", null);
Console.WriteLine(balanceMessageUsingToStringWithoutDecimalPlaces);


var spanishCultureInfoBalanceMessage = NumbersFormatting.GetBalanceUsingTheToStringMethod("n4", spanishCultureInfo);
Console.WriteLine(spanishCultureInfoBalanceMessage);

var numericInterpolatedMessage = NumbersFormatting.GetBalanceUsingStringInterpolation(null);
Console.WriteLine(numericInterpolatedMessage);

var numericInterpolatedMessageWithFourDecimalPlaces = NumbersFormatting.GetBalanceUsingStringInterpolation(4);
Console.WriteLine(numericInterpolatedMessageWithFourDecimalPlaces);

var numericInterpolatedMessageWithEnglishCulture =
   NumbersFormatting.GetBalanceUsingStringInterpolationWithCultureInfo("n4", englishCultureInfo);
Console.WriteLine(numericInterpolatedMessageWithEnglishCulture);

var numericInterpolatedMessageWithSpanishCulture =
    NumbersFormatting.GetBalanceUsingStringInterpolationWithCultureInfo("n4", spanishCultureInfo);
Console.WriteLine(numericInterpolatedMessageWithSpanishCulture);