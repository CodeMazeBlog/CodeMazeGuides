using ActionAndFuncDelegates;

Console.WriteLine("Count down to 1:");

foreach (var item in CallbackController.CountDown(10, CallbackController.CalculateMinusOne))
{
    Console.WriteLine(item);
}

Console.WriteLine("-----------------");
Console.WriteLine("Say Hello!");

LinqController.SayHello();

Console.WriteLine("-----------------");
Console.WriteLine("What is 5 + 2?");

Func<int, Task<int>> asyncFunc = AsyncController.DoubleAsync;
int result = await asyncFunc(5);

Console.WriteLine($"The result is: {result}");