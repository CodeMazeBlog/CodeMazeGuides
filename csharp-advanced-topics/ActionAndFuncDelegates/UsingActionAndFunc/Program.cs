using ActionAndFuncDelegates;

//Action delegate

Action<string> greetings = ActionAndFunc.GreetUser;

greetings("Dave");

//Func delegate

Func<int, string> squaredResult = ActionAndFunc.SquareToString;

var result = squaredResult(3);

Console.WriteLine(result);

//With lambda and LINQ

var numbers = Enumerable.Range(1, 10).ToList();

//Any Func<int, bool> below is supposed to be a Predicate<int, bool> as it is best fitted for this purpose,
//but seeing as it wasn't introduced, we maintain the Func<int, bool>
Func<int, bool> isEven = x => x % 2 == 0;

Func<int, int> square = x => x * x;

Func<int, bool> isAbove30 = x => x > 30;

var evenSquaredNumbersAbove30 = numbers
    .Where(isEven)
    .Select(square)
    .Where(isAbove30);

Console.WriteLine(string.Join(", ", evenSquaredNumbersAbove30));