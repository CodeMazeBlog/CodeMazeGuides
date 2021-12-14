namespace Action_and_Func_delegates
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Func<int, int, int> Multiply = Multiplication;
            int result = Multiply(2, 3);
            Console.WriteLine(result);
        }
        private static int Multiplication(int num1, int num2)
        {
            return num1 * num2;
        }
    }
}