namespace FuncAndAction
{
    public class DelegateExample
    {
        public delegate void ForEachCallback(int value);
        int[] array = { 1, 2, 3, 4, 5 };

        public void Run()
        {
            ForEachCallback printValue = PrintValueOnConsole;

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
    }
}
