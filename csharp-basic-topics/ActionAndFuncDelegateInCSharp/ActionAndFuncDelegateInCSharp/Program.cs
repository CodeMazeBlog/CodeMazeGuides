namespace ActionAndFuncDelegateInCSharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Delegate Example:");
            ActionExample.ExecuteDelegateExample();

            Console.WriteLine("Action Delegate Example:");
            ActionExample.ExecuteActionDelegateExample();

            Console.WriteLine("Linq with Action Delegate Example:");
            ActionExample.ExecuteLinqWithActionDelegateExample();

            Console.WriteLine("Func Delegate Example:");
            FuncExample.ExecuteFuncDelegateExample();
        }
    }

    internal class ActionExample
    {
        private delegate void PrintMessage(string name);

        private static readonly List<string> Lists = new()
        {
            "Michael",
            "John"
        };

        public static void ExecuteDelegateExample()
        {
            PrintMessage print = Print;

            foreach (var list in Lists) print(list);
        }
        public static void ExecuteActionDelegateExample()
        {
            Action<string> print = Print;
            foreach (var list in Lists) print(list);
        }

        public static void ExecuteLinqWithActionDelegateExample()
        => Lists.ForEach(Print);

        public static void Print(string name) => Console.WriteLine($"Hello {name}!");
    }


    internal class FuncExample
    {
        private static int _count = 0;

        public static void ExecuteFuncDelegateExample()
        {
            Console.WriteLine(Execute(Test, new TimeSpan(0, 0, 1)));
        }

        public static T Execute<T>(Func<T> func, TimeSpan retryInterval, int retryCount = 3)
        {
            var exceptions = new List<Exception>();
            for (var retry = 0; retry < retryCount; retry++)
            {
                try { return func(); }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(retryInterval);
                }
            }
            throw new AggregateException(exceptions);
        }

        public static string Test()
        {
            _count++;
            if (_count < 3)
                throw new Exception($"Fail: Time out {_count}");
            return "Success: Hello World!";
        }
    }

}