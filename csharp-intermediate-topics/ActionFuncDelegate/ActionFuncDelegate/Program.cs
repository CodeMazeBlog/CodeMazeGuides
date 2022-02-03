namespace ActionFuncDelegate
{
    delegate void DisplayMessage(string message);
    delegate int Fun(int x, int y);

    public class Program
    {
        static int Add(int x, int y)
        {
            return x + y;
        }

        public static string Delegate1(string mes)
        {
            DisplayMessage messageDisplay;
            messageDisplay = Console.WriteLine;
            messageDisplay(mes);
            return mes;
        }

        public static string ActionDelegate(string mes)
        {
            Action<string> messageDisplay = Console.WriteLine;
            messageDisplay(mes);
            return mes;
        }

        public static string AnonActionDelegate(string mes)
        {
            Action<string> messageDisplay = delegate (string s) { Console.WriteLine(s); };
            messageDisplay(mes);
            return mes;
        }

        public static int FuncDelegate(int x, int y)
        {
            Func<int, int, int> fun = Add;
            int result = fun(x, y);
            Console.WriteLine(result);
            return result;
        }

        public static int Delegate2(int x, int y)
        {
            Fun fun;
            fun = Add;
            int result = fun(x, y);
            Console.WriteLine(result);
            return result;
        }

        public static int AnonFuncDelegate(int x, int y)
        {
            Func<int, int, int> fun = delegate (int x, int y) { return x + y; };
            int result = fun(x, y);
            Console.WriteLine(result);
            return result;
        }

        static void Main(string[] args)
        {
            int x = 10;
            int y = 10;

            Delegate1("Hello, Code Maze!");

            ActionDelegate("Hello, Code Maze!");

            AnonActionDelegate("Hello, Code Maze!");

            FuncDelegate(x, y);

            Delegate2(x, y);

            AnonFuncDelegate(x, y);

        }
    }
}