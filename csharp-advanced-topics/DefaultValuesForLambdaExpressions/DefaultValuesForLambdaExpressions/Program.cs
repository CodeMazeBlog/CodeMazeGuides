
using DefaultValuesForLambdaExpressions;

Console.WriteLine($"10 incremented by 5 is equal to: {Calculator.IncrementByValue(10, 5)}");

Console.WriteLine($"10 incremented by the default value is equal to: {Calculator.IncrementByDefaultValue(10)}");

int[] array = { 10, 20, 30, 40, 50 };
Console.WriteLine($"The array total is equal to: {Calculator.Total(array)}");