using System.Globalization;

// String.Format() Method

var balance = 2154002.535;

var balanceMessage = String.Format("Your account balance is: {0}", balance);

Console.WriteLine(balanceMessage);

var englishCultureInfo = new CultureInfo("en-US");

var balanceMessageWithCultureInfo = String.Format("Your account balance is: {0}", balance, englishCultureInfo);

Console.WriteLine(balanceMessageWithCultureInfo);

var balanceMessageWithSeparators = String.Format("Your account balance is: {0:n}", balance, englishCultureInfo);

Console.WriteLine(balanceMessageWithSeparators);

var balanceMessageWithFourDigits = String.Format("Your account balance is: {0:n4}", balance, englishCultureInfo);

Console.WriteLine(balanceMessageWithFourDigits);

var balanceMessageWithoutDecimals = String.Format("Your account balance is: {0:n0}", balance, englishCultureInfo);

Console.WriteLine(balanceMessageWithoutDecimals);

// The ToString() method

var formatedBalance = balance.ToString("n");

Console.WriteLine("Your account balance is: " + formatedBalance);

var formatedBalanceWithFourDigits = balance.ToString("n4");

Console.WriteLine("Your account balance is: " + formatedBalanceWithFourDigits);

var formatedBalanceWithoutDigits = balance.ToString("n0");

Console.WriteLine("Your account balance is: " + formatedBalanceWithoutDigits);

var spanishCultureInfo = new CultureInfo("es-ES");

var spanishFormatedBalance = balance.ToString("n4", spanishCultureInfo);

Console.WriteLine("Your account balance is: " + spanishFormatedBalance);


// Interpolation

var message = $"Your account balance is: {balance}";

Console.WriteLine(message);

var numericInterpolatedMessage = $"Your account balance is: {balance:n4}";

Console.WriteLine(numericInterpolatedMessage);

var numericInterpolatedMessageWithEnglishCulture = $"Your account balance is: {balance.ToString("n", englishCultureInfo)}";

Console.WriteLine(numericInterpolatedMessageWithEnglishCulture);

var numericInterpolatedMessageWithSpanishCulture = $"Your account balance is: {balance.ToString("n", spanishCultureInfo)}";

Console.WriteLine(numericInterpolatedMessageWithSpanishCulture);