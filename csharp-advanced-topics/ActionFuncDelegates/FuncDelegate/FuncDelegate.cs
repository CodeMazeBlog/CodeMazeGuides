namespace FuncDelegate
{
    public class FuncDelegate
    {
        public static int Multiplication(int x, int y)
        {
            return x * y;
        }

        public static void Main(string[] args)
        {
            Func<int, int, int> mathematicalOperation = Multiplication;
            var result = mathematicalOperation(5, 4);
        }
    }
}