namespace ActionDelegate
{
    public class ActionDelegate
    {
        public static void Subtraction(int x, int y)
        {
            var result = x - y;
        }

        public static void Main(string[] args)
        {
            Action<int, int> mathematicalOperation = Subtraction;
            mathematicalOperation(5, 4);
        }
    }
}