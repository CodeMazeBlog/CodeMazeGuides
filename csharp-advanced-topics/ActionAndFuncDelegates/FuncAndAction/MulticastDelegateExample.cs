namespace FuncAndAction
{
    public class MulticastDelegateExample
    {
        public delegate void ForEachCallback(int value);
        int[] array = { 1, 2, 3, 4, 5 };

        public void Run()
        {
            ForEachCallback printValue = PrintValueOnConsole;
            printValue += AddAndPrintValueOnConsole;

            ForEach(array, printValue);
        }

        private void ForEach(int[] array, ForEachCallback callback)
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

        private void AddAndPrintValueOnConsole(int value)
        {
            value += 100;
            Console.WriteLine(value);
        }
    }
}
