var arg = args.FirstOrDefault("0");
Console.WriteLine($"Got argument {arg}");

if (int.TryParse(arg, out int parsedCode))
{
    return parsedCode;
}
else
{
    return 1;
}