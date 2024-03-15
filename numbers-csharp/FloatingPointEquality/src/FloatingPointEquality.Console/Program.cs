using FloatingPointEquality.Library;

const double a = 1.12345;
const double b = 1.1234500000000012;

Console.WriteLine(0.1 + 0.2);
Console.WriteLine($"{0.1:G17}");
Console.WriteLine($"{0.2:G17}");

Console.WriteLine("\n----------------------------------------------------------\n");

var calculation = 0.1 + 0.2;
var expected = 0.3;
Console.WriteLine($"{calculation == expected}");
Console.WriteLine($"{calculation:G17}");
Console.WriteLine($"{expected:G17}");
Console.WriteLine($"{calculation == double.BitIncrement(expected)}");
Console.WriteLine($"{double.BitDecrement(calculation) == expected}");

Console.WriteLine("\n----------------------------------------------------------\n");

Console.WriteLine($"{0.29999999999999999:G17}");
Console.WriteLine($"{0.30000000000000000:G17}");
Console.WriteLine($"{0.30000000000000001:G17}");
Console.WriteLine($"{0.30000000000000002:G17}");
Console.WriteLine($"{0.30000000000000003:G17}");
Console.WriteLine($"{0.30000000000000004:G17}");
Console.WriteLine($"{0.30000000000000005:G17}");

Console.WriteLine("\n----------------------------------------------------------\n");

Console.WriteLine("Equality with precision");
Console.WriteLine(FloatingPointComparisons.EqualityUsingPrecision(a, b, 14));
Console.WriteLine(FloatingPointComparisons.EqualityUsingPrecision(a, b, 15));

Console.WriteLine("\n----------------------------------------------------------\n");

Console.WriteLine("Equality with tolerance");
Console.WriteLine(FloatingPointComparisons.EqualityUsingTolerance(a, b, 1e-14));
Console.WriteLine(FloatingPointComparisons.EqualityUsingTolerance(a, b, 1e-15));

Console.WriteLine("\n----------------------------------------------------------\n");

Console.WriteLine("Equality with ULP");
Console.WriteLine(FloatingPointComparisons.EqualityUsingMaxUnitsInLastPlace(a, b, 5));
Console.WriteLine(FloatingPointComparisons.EqualityUsingMaxUnitsInLastPlace(a, b, 4));