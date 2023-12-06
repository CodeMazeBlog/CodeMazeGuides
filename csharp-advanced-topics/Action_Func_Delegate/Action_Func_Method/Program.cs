// See https://aka.ms/new-console-template for more information
namespace CodeMaze_Func_Action_Evaluation
{
    public class Func_Action_Delegate_Demo
    {
        public static void AddNumbers(int param1, int param2)
        {
            var result = param1 + param2;
            Console.WriteLine($"Addition = {result}");
        }

        public static void AddNumberDelegate(int param1, int param2)
        {
            Action<int, int> AddDelegate = AddNumbers;
            AddDelegate(param1, param2);
        }

        public static int MultiplyNumbers(int param1, int param2)
        {
            var result = param1 * param2;
            return result;
        }

        public static int MultiplyDelegate(int param1, int param2)
        {
            Func<int, int, int> MultiplyDelegate = MultiplyNumbers;
            return (MultiplyDelegate(param1, param2));
        }
        public static int MultiplyDelegateLambda(int param1, int param2)
        {
            Func<int, int, int> MultiplyDelegate = (param1, param2) => param1 * param2;
            return (MultiplyDelegate(param1, param2));
        }

        public static void AddNumberDelegateLambda(int param1, int param2)
        {
            Action<int, int> AddDelegate = (param1, param2) =>
             {
                 var result = param1 + param2;
                 Console.WriteLine($"AdditionLambda = {result}");
             };
            AddDelegate(param1, param2);
        }

        static void Main(string[] args)
        {
            AddNumberDelegate(5, 7);
            AddNumberDelegateLambda(5, 7);
            var result = MultiplyDelegate(50, 3);
            Console.WriteLine($"Multiplication = {result}");
            var resultlambda = MultiplyDelegateLambda(50, 3);
            Console.WriteLine($"MultiplicationLambda = {resultlambda}");
        }
        
    }
}
