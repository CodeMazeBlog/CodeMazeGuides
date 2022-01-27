using static ActionAndFuncDelegates.ActionAndFuncUtils;

SetMessageDelegate messageHandler = SetMessage;
SumNumbersDelegate sumHandler = SumNumbers;

messageHandler("Hello Code Maze!!");
var result = sumHandler(1, 1);

Console.WriteLine(message);
Console.WriteLine(result);


Action<string> setMessage = x => { message = x; };
Func<int, int, int> sum = (x, y) => x + y;
setMessage("Hello Code Maze!");
result = sum(1, 1);
setMessage("Hello again Code Maze!");
SumNumbersWithCallback(1, 1, setMessage);

Console.WriteLine(message);
Console.WriteLine(result);
Console.WriteLine(message);


