using System;
using System.Text;

namespace DebuggingBasicsInCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number");

            int number = Convert.ToInt32(Console.ReadLine());

            string table = GetMultiplicationTable(number);

            Console.WriteLine(table);
        }

        public static string GetMultiplicationTable(int number)
        {
            var result = new StringBuilder();

            for (int i = 1; i <= 10; i++)
            {
                int product = number * i;
                result.AppendLine($"{number} X {i} = {product}");
            }

            return result.ToString();
        }
    }
}
