using FuncUsageExample;

var numberList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

var evenNumbersOnly = numberList.Filter(number => number % 2 == 0);

Console.WriteLine($"Numbers after filtering: { string.Join(",", evenNumbersOnly) }");

var _ = Console.ReadKey();
