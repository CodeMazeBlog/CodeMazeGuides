namespace FuncAndAction
{
    public class ActionExample
    {
        public delegate void ForEachCallback(int value);
        int[] array = { 1, 2, 3, 4, 5 };

        public void Run()
        {
            Action<int> actionPrintValueOnConsole = PrintValueOnConsole;

            ForEach(array, actionPrintValueOnConsole);
        }

        private void ForEach(int[] array, Action<int> callback)
        {
            foreach (var item in array)
            {
                callback(item);
            }
        }

        private void PrintValueOnConsole(int value)
        {
            Console.WriteLine(value);
        }
    }
}
