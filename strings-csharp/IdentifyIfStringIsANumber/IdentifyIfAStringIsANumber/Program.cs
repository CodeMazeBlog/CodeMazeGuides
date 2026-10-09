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

Console.WriteLine("Using char.IsAsciiDigit():");
foreach (var item in values)
{
    Console.WriteLine($" * {item,-15} ====> {StringIsANumberChecker.UsingCharIsDigit(item)}");
}

Console.WriteLine("Using compiled Regex:");
foreach (var item in values)
{
    Console.WriteLine($" * {item,-15} ====> {StringIsANumberChecker.UsingCompiledRegex(item)}");
}

Console.WriteLine("Using char.IsAsciiDigit() with foreach:");
foreach (var item in values)
{
    Console.WriteLine($" * {item,-15} ====> {StringIsANumberChecker.UsingCharIsDigitWithForeach(item)}");
}

Console.WriteLine("Using character value comparison:");
foreach (var item in values)
{
    Console.WriteLine($" * {item,-15} ====> {StringIsANumberChecker.UsingCharIsBetween09(item)}");
}
