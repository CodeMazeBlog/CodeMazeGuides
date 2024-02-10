try
{
    Console.Write("Please insert an integer number: ");
    var input = Console.ReadLine();
    if (!int.TryParse(input, out int number))
    {
        throw new InvalidOperationException("The input is not an integer number!");
    }

    var counter = new DigitCounter();
    int noOfDigits = 0;

    Console.WriteLine("Please choose a method (1 - iterative, 2 - recursive, 3 - log10, 4 - string length, 5 - if chain)");
    var inputMethod = Console.ReadLine();
    noOfDigits = inputMethod switch
    {
        "1" => counter.GetIterativeCount(number),
        "2" => counter.GetRecursiveCount(number),
        "3" => counter.GetLog10Count(number),
        "4" => counter.GetStringLengthCount(number),
        "5" => counter.GetIfChainCount(number),
        _ => throw new InvalidOperationException($"Unexpected method {inputMethod}"),
    };
    Console.WriteLine($"The number {number} has {noOfDigits} digits");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

