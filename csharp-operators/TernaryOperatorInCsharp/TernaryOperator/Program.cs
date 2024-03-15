
#region nested ternary operator vs if-else statement

var x = 5;
var y = 10;

if (x > y)
{
    Console.WriteLine("x is greater than y");
}
else
{
    Console.WriteLine("y is greater than x");
}

var result = (x > y) ? "x is greater than y" : "y is greater than x";
Console.WriteLine(result);

#endregion

#region nested ternary operator vs if-else if statement

var a = 10;
var b = 10;

if (a > b)
{
    Console.WriteLine("a is greater than b");
}
else if (a < b)
{
    Console.WriteLine("b is greater than a");
}
else
{
    Console.WriteLine("a is equal to b");
}

var comparison = (a > b) ? "a is greater than b" : (a < b) ? "b is greater than a" : "a is equal to b";
Console.WriteLine(comparison);

#endregion

#region ternary operator without ref keyword

var array1 = new int[] { 1, 2, 3, 4, 5 };
var number1 = 100;

var value1 = number1 >= 100 ? array1[2] : array1[4];
value1 = 0;
Console.WriteLine(string.Join(" ", array1));

#endregion

#region ternary operator with ref keyword

var array2 = new int[] { 1, 2, 3, 4, 5 };
var number2 = 100;

ref var value2 = ref ((number2 >= 100) ? ref array2[2] : ref array2[4]);
value2 = 10000;
Console.WriteLine(string.Join(" ", array2));

#endregion