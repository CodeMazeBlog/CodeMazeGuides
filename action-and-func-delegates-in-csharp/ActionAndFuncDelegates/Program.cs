namespace ActionAndFuncDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Action

            ActionDelegate actionDelegate = new ActionDelegate();
            // Output: Hello, world!
            actionDelegate.PrintHello();
            // Output: Hello, John!
            actionDelegate.Greet("John");
            // Output: Sum: 8 
            actionDelegate.Add(3, 5);
            #endregion

            #region Func

            FuncDelegate funcDelegate = new FuncDelegate();
            // Output: Hello, world!
            Console.WriteLine(funcDelegate.GetGreeting());

            // Output: Hello, John!
            Console.WriteLine(funcDelegate.Greet("John"));

            // Output: 8
            Console.WriteLine(funcDelegate.Add(3, 5));
            #endregion
        }
    }
    /// <summary>
    /// Func Delegate
    /// </summary>
    public class FuncDelegate
    {
        /// <summary>
        /// Func delegate example: zero parameters, returns a string
        /// </summary>
        public Func<string> GetGreeting = () => "Hello, world!";

        /// <summary>
        /// Func delegate example: one parameter, returns a string
        /// </summary>
        public Func<string, string> Greet = (name) => $"Hello, {name}!";

        /// <summary>
        /// Func delegate example: multiple parameters, returns an integer
        /// </summary>
        public Func<int, int, int> Add = (a, b) => a + b;
    }
    /// <summary>
    /// Action Delegate
    /// </summary>
    public class ActionDelegate
    {
        /// <summary>
        /// Action delegate example: zero parameters
        /// </summary>
        public Action PrintHello = () => Console.WriteLine("Hello, world!");
        /// <summary>
        /// Action delegate example: one parameter
        /// </summary>
        public Action<string> Greet = (name) => Console.WriteLine($"Hello, {name}!");
        /// <summary>
        /// Action delegate example: multiple parameters
        /// </summary>
        public Action<int, int> Add = (a, b) => Console.WriteLine($"Sum: {a + b}");
    }
}

