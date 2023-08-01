namespace FuncAndAction
{
    public class ListWithActionExample
    {
        public delegate void ForEachCallback(int value);
        int[] array = { 1, 2, 3, 4, 5 };

        public void Run()
        {
            Action<int> actionPrintValueOnConsole = PrintValueOnConsole;

            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
            list.ForEach(actionPrintValueOnConsole);
        }

        private void PrintValueOnConsole(int value)
        {
            Console.WriteLine(value);
        }
    }
}
