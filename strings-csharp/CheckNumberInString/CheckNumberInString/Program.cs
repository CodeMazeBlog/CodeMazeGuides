using BenchmarkDotNet.Running;
using CheckNumberInString;

const string inputString = "The price is $42.75 for two items and $18.50 for one item.";
Console.WriteLine($"Extracting Number From String Using RegularExpression(RegEx) Method -> {ExtractNumber.ExtractNumberUsingRegEx(inputString)} ");
Console.WriteLine($"Extracting Number From String Using Linq Method -> {ExtractNumber.ExtractNumbersUsingLinq(inputString)} ");
Console.WriteLine($"Extracting Number From String Using StringBuilder Method -> {ExtractNumber.ExtractNumberUsingStringBuilder(inputString)} ");
Console.WriteLine($"Extracting Number From String Using Span Method -> {ExtractNumber.ExtractNumberUsingSpan(inputString)} ");

BenchmarkRunner.Run<BenchmarkProcess>();