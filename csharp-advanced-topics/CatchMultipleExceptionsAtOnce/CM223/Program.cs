using CM223;

string? strNumerator = null;
string? strDenominator = null;

while (string.IsNullOrEmpty(strNumerator))
{
    Console.WriteLine("Enter the numerator (between 0 and 10):");
    strNumerator = Console.ReadLine();
}

while (string.IsNullOrEmpty(strDenominator))
{
    Console.WriteLine("Enter the denominator (between 1 and 10):");
    strDenominator = Console.ReadLine();
}

int result1 = -1;
int result2 = -1;
int result3 = -1;

result1 = CatchExamples.StrDivision_MultipleCatches(strNumerator, strDenominator);
result2 = CatchExamples.StrDivision_SingleCatch(strNumerator, strDenominator);
result3 = CatchExamples.StrDivision_OptimizedSingleCatch(strNumerator, strDenominator);

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