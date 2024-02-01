using CountNumberOfDigitsInANumber;

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
	switch (inputMethod)
	{
		case "1":
			noOfDigits = counter.GetIterativeCount(number); 
			break;
        case "2":
            noOfDigits = counter.GetRecursiveCount(number);
            break;
        case "3":
            noOfDigits = counter.GetLog10Count(number);
            break;
        case "4":
            noOfDigits = counter.GetStringLengthCount(number);
            break;
        case "5":
            noOfDigits = counter.GetIfChainCount(number);
            break;
        default:
			throw new InvalidOperationException($"Unexpected method {inputMethod}");
	}

	Console.WriteLine($"The number {number} has {noOfDigits} digits");
}
catch (Exception ex)
{
	Console.WriteLine($"Error: {ex.Message}");
}

