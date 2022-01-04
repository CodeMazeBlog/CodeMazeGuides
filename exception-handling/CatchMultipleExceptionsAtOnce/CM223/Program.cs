using CM223;

string? strNumerator = null;
string? strDenominator = null;

while (string.IsNullOrEmpty(strNumerator))
{
    Console.WriteLine("Enter the numerator:");
    strNumerator = Console.ReadLine();
}

while (string.IsNullOrEmpty(strDenominator))
{
    Console.WriteLine("Enter the denominator:");
    strDenominator = Console.ReadLine();
}

var result1 = CatchExamples.MultipleCatches(strNumerator, strDenominator);
var result2 = CatchExamples.SingleCatchWithWhen(strNumerator, strDenominator);
var result3 = CatchExamples.SingleSimplecatch(strNumerator, strDenominator);
var result4 = CatchExamples.SingleCatch_SwitchCase(strNumerator, strDenominator);
var result5 = CatchExamples.SingleCatch_SwitchWhen(strNumerator, strDenominator);

if (result1 >= 0)
    Console.WriteLine("The result is: " + result1);
else
    Console.WriteLine("Invalid inputs!");

if (result2 >= 0)
    Console.WriteLine("The result is: " + result2);
else
    Console.WriteLine("Invalid inputs!");

if (result3 >= 0)
    Console.WriteLine("The result is: " + result3);
else
    Console.WriteLine("Invalid inputs!");

if (result4 >= 0)
    Console.WriteLine("The result is: " + result4);
else
    Console.WriteLine("Invalid inputs!");

if (result5 >= 0)
    Console.WriteLine("The result is: " + result5);
else
    Console.WriteLine("Invalid inputs!");