using HowToAddSeparatorsInThousandsPlaceForANumber;
using System.Globalization;

// String.Format() Method

var englishCultureInfo = new CultureInfo("en-US");
var spanishCultureInfo = new CultureInfo("es-ES");

var balanceMessage = NumbersFormatting.GetBalanceUsingTheStringFormatMethod();
Console.WriteLine(balanceMessage);

var balanceMessageWithCultureInfo =
    NumbersFormatting.GetBalanceUsingTheStringFormatMethodAndACultureInfo(englishCultureInfo);
Console.WriteLine(balanceMessageWithCultureInfo);

var balanceMessageWithSeparators =
    NumbersFormatting.GetBalanceUsingTheStringFormatMethodACultureInfoAndSpecifiers(null, englishCultureInfo);
Console.WriteLine(balanceMessageWithSeparators);

var balanceMessageWithFourDigits =
    NumbersFormatting.GetBalanceUsingTheStringFormatMethodACultureInfoAndSpecifiers(4, englishCultureInfo);
Console.WriteLine(balanceMessageWithFourDigits);

var balanceMessageWithoutDecimals =
    NumbersFormatting.GetBalanceUsingTheStringFormatMethodACultureInfoAndSpecifiers(0, englishCultureInfo);
Console.WriteLine(balanceMessageWithoutDecimals);

// The ToString() method

var balanceMessageUsingToString = NumbersFormatting.GetBalanceUsingTheToStringMethod("n", null);
Console.WriteLine(balanceMessageUsingToString);

var balanceMessageUsingToStringeWithFourDigits = NumbersFormatting.GetBalanceUsingTheToStringMethod("n4", null);
Console.WriteLine(balanceMessageUsingToStringeWithFourDigits);

var balanceMessageUsingToStringWithoutDigits = NumbersFormatting.GetBalanceUsingTheToStringMethod("n0", null);
Console.WriteLine(balanceMessageUsingToStringWithoutDigits);


var spanishCultureInfoBalanceMessage = NumbersFormatting.GetBalanceUsingTheToStringMethod("n4", spanishCultureInfo);
Console.WriteLine(spanishCultureInfoBalanceMessage);


// Interpolation

var message = NumbersFormatting.GetBalanceUsingStringInterpolation(null);
Console.WriteLine(message);

var numericInterpolatedMessage = NumbersFormatting.GetBalanceUsingStringInterpolation(4);
Console.WriteLine(numericInterpolatedMessage);

var numericInterpolatedMessageWithEnglishCulture =
   NumbersFormatting.GetBalanceUsingStringInterpolationWithCultureInfo("n4", englishCultureInfo);
Console.WriteLine(numericInterpolatedMessageWithEnglishCulture);

var numericInterpolatedMessageWithSpanishCulture =
    NumbersFormatting.GetBalanceUsingStringInterpolationWithCultureInfo("n4", spanishCultureInfo);
Console.WriteLine(numericInterpolatedMessageWithSpanishCulture);