namespace FuncActionDelegatesCodeMaze
{
    public class Program
    {
        public static void StandardWayToPrint()
        {

            var list = new[] { "a", "b" };
            Array.ForEach(list, Console.WriteLine);
            Console.WriteLine("Done!");
            Console.WriteLine("End of method");
        }

        public static void PrintWithActionDelegate()
        {

            var list = new[] { "a", "b" };
            Action<string> action = new Action<string>(Console.WriteLine);
            Array.ForEach(list, action);
            Console.WriteLine("Done!");
            Console.WriteLine("End of method");

        }
        public static void PrintToConsole(string message)
        {
            Console.WriteLine("Custom print - {0}", message);
        }

        public static void CustomPrintWithActionDelegate(string message)
        {
            {
                var list = new[] { "a", "b" };
                var actions = new Action<string>[] { Console.WriteLine, PrintToConsole };
                Array.ForEach(actions, a => Array.ForEach(list, a));
                Console.WriteLine("Done!");
                Console.WriteLine("End of method");

            }

        }

        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        public static void FuncDelegateExample()
        {
            Func<double, double, double> Calculate = Add;
            double sumResult = Calculate(9.7, 12.6);
            Console.WriteLine(sumResult);
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            StandardWayToPrint();

            PrintWithActionDelegate();

            CustomPrintWithActionDelegate("hello there, general Kenobi");

            FuncDelegateExample();
        }
    }
}