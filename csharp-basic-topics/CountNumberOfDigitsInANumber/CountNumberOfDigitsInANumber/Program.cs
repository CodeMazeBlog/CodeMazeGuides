BenchmarkRunner.Run<DigitCounterBenchmark>();

int number = 123;

Console.WriteLine($"Number = {number}\n");

Console.WriteLine("Digit count:");
Console.WriteLine("Iterative = " + DigitCounter.GetIterativeCount(number));
Console.WriteLine("Recursive = " + DigitCounter.GetRecursiveCount(number));
Console.WriteLine("Log10     = " + DigitCounter.GetLog10Count(number));
Console.WriteLine("String    = " + DigitCounter.GetStringLengthCount(number));
Console.WriteLine("IfChain   = " + DigitCounter.GetIfChainCount(number));

