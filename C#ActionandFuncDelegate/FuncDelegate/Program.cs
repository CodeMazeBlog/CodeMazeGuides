using System;
namespace FuncDelegate
{

    public class Program
    {
        public static int Product(int x, int y)
        {
            return x * y;
        }
        public static void Main(string[] args)
        {
            Func<int, int, int> prod = Product;
            int result = prod(12, 10);
            Console.WriteLine(result);
        }
    }
}

