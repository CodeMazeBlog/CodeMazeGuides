// See https://aka.ms/new-console-template for more information
using ActionAndFuncDelegates;


// Using the Action<> delegate to refer to MultiplePrint method.

Action<string, int> action = Sample.MultiplePrint;
action("Message to repeat!", 3);
Console.ReadLine();


// Using the Func<> delegate to refer to Sum and SumToString methods.

Func<int, int, int> func = Sample.Sum;
int res = func.Invoke(2, 3);
Console.WriteLine("2 + 3 = {0}", res);

Func<int, int, string> func2 = Sample.SumToString;
string sum = func2(6, 8);
Console.WriteLine(sum);