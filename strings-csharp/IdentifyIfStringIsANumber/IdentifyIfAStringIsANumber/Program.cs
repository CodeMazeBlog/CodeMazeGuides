using IdentifyIfAStringIsANumber;

var values = new string[] { "1234","ABC-789", "1.23", "9999999999" };

Console.WriteLine("Using int.TryParse():");
foreach (var item in values)
{
    Console.WriteLine($" * {item,-15} ====> {StringIsANumberChecker.IntTryParse(item)}");
}

Console.WriteLine("------");
Console.WriteLine();

Console.WriteLine("Using double.TryParse():");
foreach (var item in values)
{
    Console.WriteLine($" * {item,-15} ====> {StringIsANumberChecker.DoubleTryParse(item)}");
}
Console.WriteLine("------");
Console.WriteLine();

Console.WriteLine("Using Regex:");
foreach (var item in values)
{
    Console.WriteLine($" * {item,-15} ====> {StringIsANumberChecker.UsingRegex(item)}");
}

Console.WriteLine("Using Char.IdDigit:");
foreach (var item in values)
{
    Console.WriteLine($" * {item,-15} ====> {StringIsANumberChecker.UsingCharIsDigit(item)}");
}
