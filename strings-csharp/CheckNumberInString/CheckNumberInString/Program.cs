using BenchmarkDotNet.Running;
using CheckNumberInString;

internal class Program
{
    private static void Main(string[] args)
    {
        var inputString = "The price is $42.75 for two items and $18.50 for one item.";
        Console.WriteLine($"Extracting Number From String Using RegularExpression(RegEx) Method -> {ExtractNumber.ExtractNumberUsingRegEx(inputString).ToString()} ");
        Console.WriteLine($"Extracting Number From String Using Linq Method -> {ExtractNumber.ExtractNumbersUsingLinq(inputString).ToString()} ");
        Console.WriteLine($"Extracting Number From String Using StringBuilder Method -> {ExtractNumber.ExtractNumberUsingStringBuilder(inputString).ToString()} ");
        Console.WriteLine($"Extracting Number From String Using Span Method -> {ExtractNumber.ExtractNumberUsingSpan(inputString).ToString()} ");

        //BenchmarkRunner.Run<BenchmarkProcess>();
    }
}