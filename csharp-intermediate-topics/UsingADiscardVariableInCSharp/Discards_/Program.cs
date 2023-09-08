using System.Threading.Channels;

namespace Discards_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var (_, _, sum) = DiscardExamples.GetSum(9, 89);
            Console.WriteLine(sum);

            DiscardExamples.GetNumber();

            object[] items = new object[5];
            items[0] = 42;                   
            items[1] = "Hello, C#"; 
            items[2] = 3.14; 
            items[3] = true;
            items[4] = new DateTime(2023, 1, 1);
            DiscardExamples.GetType(items);
        }
    }
}