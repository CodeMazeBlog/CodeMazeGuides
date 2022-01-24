using static ActionAndFuncDelegates.ActionAndFuncUtils;

SetMessageDelegate handler = SetMessage;
SumNumbersDelegate otherHandler = SumNumbers;

handler("Hello Code Maze!!");
var result = otherHandler(1, 1);
Console.WriteLine(Message);
Console.WriteLine(result);


Action<string> setMessage = x => { Message = x; };
Func<int, int, int> sum = (x, y) => x + y;

setMessage("Hello again Code Maze!");
Console.WriteLine(Message);
result = sum(1, 1);
Console.WriteLine(result);

SumNumbersWithCallback(1, 1, setMessage);
Console.WriteLine(Message);





