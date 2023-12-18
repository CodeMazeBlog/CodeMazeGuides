using DecimalPrecision;

const decimal myDecimal = 123.456789M;

Console.WriteLine("----Decimal formatting----");
Console.WriteLine($"Value (\"0.00\"): {myDecimal.ToString("0.00")}");
Console.WriteLine($"Value (default format): {myDecimal}");
Console.WriteLine($"Value (\"0.0000\"): {myDecimal.ToString("0.0000")}");
Console.WriteLine($"Value (NumberFormatInfo 3 digits): {myDecimal.ToStringXDecimalPlaces(3)}");
Console.WriteLine();

Console.WriteLine("----Decimal rounding----");

Console.WriteLine($"Value (default format): {myDecimal}");
Console.WriteLine($"Value (round 2 places): {myDecimal.Round(2)}");
Console.WriteLine($"Value (truncate): {myDecimal.Truncate()}");
Console.WriteLine($"Value (ceiling): {myDecimal.Ceiling()}");
Console.WriteLine($"Value (floor): {myDecimal.Floor()}");
