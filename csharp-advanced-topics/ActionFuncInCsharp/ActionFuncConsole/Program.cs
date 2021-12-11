// See https://aka.ms/new-console-template for more information
using DoSomethingLibrary;

//Console.WriteLine("Go and do something with delegates!!!");

DoSomething.LongProcess(() => Console.WriteLine("Looping!"));
DoSomething.LongProcess((x) => Console.WriteLine($"Looping! {x + 1} times"));

DoSomething.InteractiveProcess(() =>
{
    Console.WriteLine("Keep repeating? Y or N ?");
    return Console.ReadKey(true).Key == ConsoleKey.Y;
});

DoSomething.InteractiveProcess((runTimes) =>
{
    Console.WriteLine("Keep repeating? Y or N ?");
    Console.WriteLine($"It had run {runTimes} {(runTimes > 1 ? "times" : "time")}");
    return Console.ReadKey(true).Key == ConsoleKey.Y;
});

//DoSomething.DoSomethingWithAction(49, 5, DoSomethingWithAction);
//DoSomething.DoSomethingWithAction(10, 2, (x) => Console.WriteLine($"You can use arrow functions too : {x}"));
//DoSomething.DoSomethingWithFunc(20, 3, DoSomethingWithFunc);

//Action<int> action = (teste) =>
//{
//    Console.WriteLine($"Action delegate!!!");
//    Console.WriteLine($"Loguei {teste}");
//};

//action(123);

//Func<int, int> func = x =>
// {
//     Console.WriteLine("Now a Func<int,int>");
//     return x + 1;
// };

//Console.WriteLine(func(5));

//void DoSomethingWithAction(int numberFound)
//{
//    Console.WriteLine($"DoSomethingWithAction found that {numberFound} is divided by 5");
//}

//int DoSomethingWithFunc(int numberFound)
//{
//    Console.WriteLine($"DoSomethingWithFunc : {numberFound}");
//    return numberFound;
//}

