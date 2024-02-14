namespace ActionAndFuncDelegatesInCSharp
{
    public  class BasicDelegate
    {
        private delegate void PrintDelegate(string x);

        public void Run(int number)
        {
            PrintDelegate printer = (text) => Print(text);
            printer(number.ToString());
        }

        public string RunFunc(int number)
        {
            Func<int, string> formatter = (number) => Format(number);

            return formatter(number);
        }

        public void RunAction(int number)
        {
            Action<string> printer = (text) => Print(text);
            printer(number.ToString());
        }

        private string Format(int number)
        {
            return $"Formatted {number}";
        }

        private void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
