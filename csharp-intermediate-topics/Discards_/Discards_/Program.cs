using System.Threading.Channels;

namespace Discards_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var (_, _, sum) = GetSum(9, 89);
            Console.WriteLine(sum);
        }

        static (int, int, int) GetSum(int num1, int num2)
        {
            return (num1, num2, num1 + num2);
        }
    }
}