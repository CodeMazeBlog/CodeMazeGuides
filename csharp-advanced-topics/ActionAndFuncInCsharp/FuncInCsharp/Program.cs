using FuncInCsharp;

var values = new[] { 0, 10, 20 };
ArrayHelper.Recalculate(values, AddFive);

Console.WriteLine($"Array elements after recalculation: {string.Join(' ', values)}");

static int AddFive(int value) => value + 5;
