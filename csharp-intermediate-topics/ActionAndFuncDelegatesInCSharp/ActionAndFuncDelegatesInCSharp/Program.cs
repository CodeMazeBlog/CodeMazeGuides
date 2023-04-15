namespace ActionAndFuncDelegatesInCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Action
            var logAction = new Action<string>(new Logger().Log);
            logAction("THIS IS LOGGING!!!!");

            //Func
            var prodFunc = new Func<int, int, int>(new Calculator().Multiply);
            var result = prodFunc(2, 3);

            Console.WriteLine($"Product: {result}");
        }
    }
}