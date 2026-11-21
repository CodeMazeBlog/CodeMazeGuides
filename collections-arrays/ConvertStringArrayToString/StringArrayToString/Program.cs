using StringArrayToString;

Console.WriteLine("----- How to Convert String Array into String in C# -----");
var elementConcatenator = new ArrayConverter();

string[] array = ["Code", "Maze", "Code-Maze", "C#"];

Console.WriteLine();
Console.WriteLine("Calling ToString() on the array:");
Console.WriteLine(array.ToString());

Console.WriteLine();
Console.WriteLine("Convert to string using Loop String and Addition Assignment Operator:");
Console.WriteLine(elementConcatenator.UsingLoopStringAdditionAssignment(array));

Console.WriteLine();
Console.WriteLine("Convert to string using Loop String Builder:");
Console.WriteLine(elementConcatenator.UsingLoopStringBuilder(array));

Console.WriteLine();
Console.WriteLine("Convert to string using string.Join:");
Console.WriteLine(elementConcatenator.UsingStringJoin(array));

Console.WriteLine();
Console.WriteLine("Convert to string using string.Join with a separator:");
Console.WriteLine(elementConcatenator.UsingStringJoinWithSeparator(array, " "));

Console.WriteLine();
Console.WriteLine("Convert to string using string.Concat:");
Console.WriteLine(elementConcatenator.UsingStringConcat(array));

Console.WriteLine();
Console.WriteLine("Convert to string using aggregation:");
Console.WriteLine(elementConcatenator.UsingAggregation(array));

Console.WriteLine();
Console.WriteLine("Convert to string using aggregation with StringBuilder:");
Console.WriteLine(elementConcatenator.UsingAggregationWithStringBuilder(array));
