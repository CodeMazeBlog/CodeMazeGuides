using System;
using System.Threading.Tasks;

namespace DelegatesDemo.ActionPracticalUsage
{
    class Program
    {
        static void Main()
        {
            MainAsync().Wait();
        }
        static async Task MainAsync()
        {
            var collection = new[] { 1,2,3,4,5,6 };
            const int batchSize = 2;
            Action<int> callBack = (item) =>
            {
                item *= 2;
                Console.WriteLine(item);               
            };
            await collection.ProcessInParallel(batchSize,
                                               callBack,
                                               (exp) =>
                                               {
                                                   Console.WriteLine($"Exception: {exp.Message}");
                                               });

            Console.ReadKey();
        }
    }
}
