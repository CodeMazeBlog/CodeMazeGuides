using ConvertString2Int;

var stringValue = "3";
int number;

number = int.Parse(stringValue);
Console.WriteLine($"Converted '{stringValue}' to {number} using 'int.Parse'");

number = int.TryParse(stringValue, out number) ? number : 0;
Console.WriteLine($"Converted '{stringValue}' to {number} using 'int.TryParse'");

number = Convert.ToInt32(stringValue);
Console.WriteLine($"Converted '{stringValue}' to {number} using 'Convert.ToInt32'");

number = CustomConvert.Parse(stringValue);
Console.Write($"Converted '{stringValue}' to {number} using 'CustomConvert'");

Console.WriteLine(Benchmark.Run(stringValue, 100000));
Console.WriteLine(Benchmark.Run(stringValue, 10000000));
Console.WriteLine(Benchmark.Run(stringValue, 1000000000));

Console.ReadKey();