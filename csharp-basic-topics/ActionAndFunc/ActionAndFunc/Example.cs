using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesInCSharp
{
    public static class Example
    {
        public static void PrintNumbersWithoutAction(List<int> numbers)
        {
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
        public static void PrintNumbersWithAction(List<int> numbers, Action<int> action)
        {
            numbers.ForEach(action);
        }
    }
}
