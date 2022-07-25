void PrintHelloWorld()
{
    Console.WriteLine("Hello World!");
}

var action1 = new Action(PrintHelloWorld);
var action2 = PrintHelloWorld;
var action3 = () => { Console.WriteLine("Hello World!"); };

action1();
action2();
action3();

void RunAction(Action action)
{
    Console.Write("Greetings! ");
    action();
}

RunAction(action3);

Action<string> printMessage
    = (message) => { Console.WriteLine(message); };

printMessage("Hello Code Maze!");

Func<int> get42 = () => 42;

Console.WriteLine(get42());

Func<int, int> add42 = (x) => x + 42;

Console.WriteLine(add42(5));
