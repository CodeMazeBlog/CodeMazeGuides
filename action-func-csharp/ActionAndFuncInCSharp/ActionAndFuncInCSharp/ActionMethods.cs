namespace ActionAndFuncInCSharp
{
    public class ActionMethods
    {
        private readonly IConsole _console;

        public ActionMethods(IConsole console)
        {
            _console = console;
        }

        public void PrintAMessage()
        {
            Action<string> print = x => _console.WriteLine(x);

            print("Hello"); // prints "Hello" to the console
        }

        public void PrintAHelloMessage()
        {
            Action<string> myHelloAction = SayHello;

            myHelloAction("Code Maze"); // prints "Hello, Code Maze!" to the console
        }

        public void PrintMoreHelloMessages()
        {
            SayHelloToEveryone(SayHello, new string[3] { "Bob", "Joe", "Mary" }); // prints "Hello, Bob! Hello, Joe! Hello, Mary!"
        }

        private void SayHello(string name)
        {
            _console.WriteLine($"Hello, {name}!");
        }

        private void SayHelloToEveryone(Action<string> sayHello, IEnumerable<string> names)
        {
            foreach (var name in names)
            {
                sayHello(name);
            }
        }
    }
}
