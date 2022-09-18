
namespace DelegatesSampleCode
{
    public class MathOperations
    {
        public static void Multiply(int x, int y)
        {
            var result = x * y;
        }
        public static void Multiply(string Message, int x, int y)
        {
            var result = $"{Message} : { x * y}";
        }

        public static int Add(int x, int y)
        {
            return x + y;
        }
        public static int Subtract(int x, int y)
        {
            return x - y;
        }
    }
}
