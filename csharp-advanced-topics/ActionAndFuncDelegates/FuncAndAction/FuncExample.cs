namespace FuncAndAction
{
    public class FuncExample
    {
        public delegate void ForEachCallback(int value);
        int[] array = { 1, 2, 3, 4, 5 };

        public void Run()
        {
            Action<int> actionPrintValueOnConsole = PrintValueOnConsole;
            Func<string, string, string> funcConcat = (text1, text2) => string.Format("{0} {1}", text1, text2);

            ForEach(array, actionPrintValueOnConsole);
            Console.WriteLine(funcConcat("Hello", "World"));
        }

        static void ForEach(int[] array, Action<int> callback)
        {
            foreach (var item in array)
            {
                callback(item);
            }
        }

        static void PrintValueOnConsole(int value)
        {
            Console.WriteLine(value);
        }
    }
}
