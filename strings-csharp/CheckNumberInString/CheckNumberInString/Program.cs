using BenchmarkDotNet.Running;
using CheckNumberInString;

internal class Program
{
    private static void Main(string[] args)
    {
        var inputString = "The total revenue is $123.4";
        Console.WriteLine($"Extracting Number From String Using RegularExpression(RegEx) Method -> {ExtractNumber.ExtractNumberUsingRegEx(inputString)} ");
        Console.WriteLine($"Extracting Number From String Using Linq And CharIsDigit Method -> {ExtractNumber.ExtractNumberUsingLinqAndCharIsDigit(inputString)} ");
        Console.WriteLine($"Extracting Number From String Using StringBuilder And CharIsDigit Method -> {ExtractNumber.ExtractNumberUsingStringBuilderAndCharIsDigit(inputString)} ");
        //BenchmarkRunner.Run<BenchmarkProcess>();
    }
}