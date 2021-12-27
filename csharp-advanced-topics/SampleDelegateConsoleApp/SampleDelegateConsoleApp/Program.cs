using System;

namespace SampleDelegateConsoleApp
{
    public class Program
    {
        public delegate bool MyDelegate(string task);

        static void Main(string[] args)
        {
            string task = "Buy fresh milk";

            var taskSevenEleven = new MyDelegate(SevenElevenMethod);

            var taskFarmersMarket = new MyDelegate(FarmersMarketMethod);

            MyDelegate taskEmpty = (string task) => false;

            MyDelegate taskMulticast = taskEmpty + taskSevenEleven + taskFarmersMarket;

            var result = taskMulticast.Invoke(task);

            Console.WriteLine($"Invoking multicast delegate. Result={result}");

            Func<string, bool> myFunc = SevenElevenMethod;

            result = myFunc.Invoke("Testing Func");

            Console.WriteLine($"Invoking Func delegate. Result={result}");
        }

        public static bool SevenElevenMethod(string task)
        {
            if (task == "Buy milk")
            {
                Console.WriteLine($"{nameof(SevenElevenMethod)}: Successfully executed '{task}'");
                return true;
            }
            else
            {
                Console.WriteLine($"{nameof(SevenElevenMethod)}: Failed to perform '{task}'");
                return false;
            }
        }

        public static bool FarmersMarketMethod(string task)
        {
            if (task == "Buy fresh milk")
            {
                Console.WriteLine($"{nameof(FarmersMarketMethod)}: Successfully executed '{task}'");
                return true;
            }
            else
            {
                Console.WriteLine($"{nameof(FarmersMarketMethod)}: Failed to perform '{task}'");
                return false;
            }
        }
    }
}
