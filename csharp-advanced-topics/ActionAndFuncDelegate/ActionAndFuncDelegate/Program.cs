using ActionAndFuncDelegate;

int a = 50, b = 5;

Func<int, int, int> AddFuncDelegate = new Func<int, int, int>(BasicMaths.Add);
Func<int, int, int> SubFuncDelegate = new Func<int, int, int>(BasicMaths.Sub);

int AddFuncDelegateResult = AddFuncDelegate(a, b);
int SubFuncDelegateResult = SubFuncDelegate(a, b);

Console.WriteLine($"{a} + {b} = {AddFuncDelegateResult}");
Console.WriteLine($"{a} - {b} = {SubFuncDelegateResult}");

Action<int> ActionDelegateEvenOrOdd = new Action<int>(BasicMaths.EvenOrOdd);
Action<double, double> ActionDelegateMaximum = new Action<double, double>(BasicMaths.Maximum);

ActionDelegateEvenOrOdd(21);
ActionDelegateMaximum(10.30, 10.50);

Console.ReadLine();
