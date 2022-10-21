using BenchmarkDotNet.Running;
using System.Collections;

namespace DictionaryVsHashTables
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //Dictionary Example
            var ordersDictionary = Utility.CreateOrderDictionary();

            foreach (KeyValuePair<int, Order> order in ordersDictionary)
            {
                Console.WriteLine($"Key: {order.Key}, Order Id: {order.Value.OrderId}, " +
                    $"Quantity: {order.Value.Quantity}");
            }

            //Hashtable Example
            var hashTable = Utility.CreateHashTable();

            foreach (DictionaryEntry item in hashTable)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }

            //Run Benchmarks
            var summary = BenchmarkRunner.Run<BenchmarkProcess>();
        }
    }
}