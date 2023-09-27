using CatchMultipleExceptionsAtOnes;

string? strNumerator = null;
string? strDenominator = null;

while (string.IsNullOrEmpty(strNumerator))
{
    Console.WriteLine("Enter the numerator (>=0):");
    strNumerator = Console.ReadLine();
}

while (string.IsNullOrEmpty(strDenominator))
{
    Console.WriteLine("Enter the denominator (>=1):");
    strDenominator = Console.ReadLine();
}

var result1 = CatchExamples.MultipleCatches(strNumerator, strDenominator);
var result2 = CatchExamples.SingleCatchWithWhen(strNumerator, strDenominator);
var result3 = CatchExamples.SingleCatchSwitchCase(strNumerator, strDenominator);
var result4 = CatchExamples.SingleCatchSwitchPattern(strNumerator, strDenominator);

if (result1 >= 0)
    Console.WriteLine("The result is: " + result1);

if (result2 >= 0)
    Console.WriteLine("The result is: " + result2);

if (result3 >= 0)
    Console.WriteLine("The result is: " + result3);

if (result4 >= 0)
    Console.WriteLine("The result is: " + result4);
