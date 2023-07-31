// Action delegate with local DisplayMessage function
Action<string> displayAction = DisplayMessage;
displayAction("Hello CodeMaze!");

displayAction.Invoke("Hello CodeMaze!");

displayAction?.Invoke("Hello CodeMaze!");

static void DisplayMessage(string message)
{
    Console.WriteLine(message);
}

// Func delegate with local Add function
Func<int, int, int> addFunc = Add;
Console.WriteLine(addFunc(3, 5)); // Output: 8

static int Add(int first, int second)
{
    return first + second;
}

// Func delegate with lambda expression
Func<int, int, int> addFuncWithLambda = (first, second) => first + second;
Console.WriteLine(addFuncWithLambda(3, 5)); // Output: 8

// Enumerable.Where predicate
var listWithNumbers = new List<int> { 1, 4, 3, 6, 9, 2 };
var listWithEvenNumbers = listWithNumbers.Where(number => number % 2 == 0);
Console.WriteLine(string.Join(", ", listWithEvenNumbers)); // Output: 4, 6, 2