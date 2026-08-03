using ConvertString2Int;

var stringValue = "3";
var number = 0;

number = int.Parse(stringValue);
Console.WriteLine($"Converted '{stringValue}' to {number} using 'int.Parse()'");

int.TryParse(stringValue, out number);
Console.WriteLine($"Converted '{stringValue}' to {number} using 'int.TryParse()'");

number = Convert.ToInt32(stringValue);
Console.WriteLine($"Converted '{stringValue}' to {number} using 'Convert.ToInt32()'");

number = CustomConvert.Parse(stringValue);
Console.Write($"Converted '{stringValue}' to {number} using 'CustomConvert.Parse()'");

Console.ReadKey();