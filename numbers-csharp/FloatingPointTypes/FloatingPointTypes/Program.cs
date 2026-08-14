// See https://aka.ms/new-console-template for more information

using FloatingPointTypes;

var floatingArithmetic = new FloatingPointArithmetic();

floatingArithmetic.FloatSumAndMultiplication(0.1f, 0.5f, 10);
floatingArithmetic.DoubleSumAndMultiplication(0.2D, 1.5D, 10);
floatingArithmetic.DecimalSumAndMultiplication(0.2M, 1.5M, 10);

// Why 0.1 + 0.2 does not equal 0.3: double is base-two and rounds each value,
// while decimal is base-ten and stores 0.1 exactly.
Console.WriteLine(0.1 + 0.2 == 0.3);           // False
Console.WriteLine((0.1 + 0.2).ToString("R"));  // 0.30000000000000004
Console.WriteLine(0.1m + 0.2m == 0.3m);        // True