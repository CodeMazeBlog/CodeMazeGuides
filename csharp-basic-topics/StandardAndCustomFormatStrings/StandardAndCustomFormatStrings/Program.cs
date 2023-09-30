using StandardAndCustomFormatStrings;

Console.WriteLine($"Currency: {StandardFormatStrings.CurrencyFormat(1652.5899)}");
Console.WriteLine($"Euro Currency: {StandardFormatStrings.EuroCurrency(1652.5899)}");
Console.WriteLine($"Decimal: {StandardFormatStrings.DecimalFormat(6546)}");
Console.WriteLine($"Fixed Point: {StandardFormatStrings.FixedPointFormat(1652.5899)}");

Console.WriteLine($"Decimal Precision: {StandardFormatStrings.DecimalPrecision(6546)}");
Console.WriteLine($"Floating Point Precision: {StandardFormatStrings.FloatingPointPrecision(1652.5899)}");

Console.WriteLine($"Percentage: {StandardFormatStrings.Percentage(0.54)}");

Console.WriteLine("\n\n");
Console.WriteLine("======================== Custom Format Strings ========================");
Console.WriteLine($"Decimal: {CustomFormatStrings.Decimal(6546)}");
Console.WriteLine($"Floating Point: {CustomFormatStrings.FloatingPoint(1652.5899)}");
Console.WriteLine($"Percentage: {CustomFormatStrings.Percentage(0.54)}");
Console.WriteLine($"Digit Separator: {CustomFormatStrings.DigitSeparator(1652.5899)}");

Console.WriteLine($"Phone: {CustomFormatStrings.Phone(55665228871)}");
Console.WriteLine($"Phone: {CustomFormatStrings.PhoneInterpolated(55665228871)}");