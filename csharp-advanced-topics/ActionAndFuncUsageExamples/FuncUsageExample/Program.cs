using FuncUsageExample;

IMathService mathService = new MathService();

var resultString = mathService.PerformOperation(2, 8, arithmeticOperation: (x, y) => x + y );

Console.WriteLine(resultString);

var _ = Console.ReadKey();
