using ActionAndFuncDelegates;

int[] numbers = { 3, 5, 7, 8, 9 };
var result = NumberOperations.SumNumbers(numbers, NumberOperations.IsOdd, NumberOperations.ThrowNumberShouldBeOddException);

Console.WriteLine($"SumNumbers result: {result}");

