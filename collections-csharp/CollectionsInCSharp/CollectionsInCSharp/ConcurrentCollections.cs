using System.Collections;
using System.Collections.Concurrent;
namespace CollectionsInCSharp
{
    public class ConcurrentCollections
    {
        public static ConcurrentDictionary<int, string> CreateConcurrentNumbersDictionary()
        {
            ConcurrentDictionary<int, string> concurrentNumbersDictionary = new();
            concurrentNumbersDictionary.TryAdd(1, "One");
            concurrentNumbersDictionary.TryAdd(2, "Two");
            concurrentNumbersDictionary.TryAdd(3, "Three");

            return concurrentNumbersDictionary;
        }
        
        public static string ReadFromConcurrentNumbersDictionary(ConcurrentDictionary<int, string> concurrentNumbersDictionary)
        {
            var word = concurrentNumbersDictionary[1];

            return word;
        }

        public static ConcurrentQueue<int> CreateConcurrentNumbersQueue()
        {
            ConcurrentQueue<int> concurrentNumbersQueue = new();
            concurrentNumbersQueue.Enqueue(1);
            concurrentNumbersQueue.Enqueue(2);
            concurrentNumbersQueue.Enqueue(3);

            return concurrentNumbersQueue;
        }

        public static ArrayList ReadFromConcurrentNumbersQueue(ConcurrentQueue<int> concurrentNumbersQueue)
        {
            var numberList = new ArrayList();
            if(concurrentNumbersQueue.TryDequeue(out int num))
            {
                numberList.Add(num);
            }

            return numberList;
        }

        public static ConcurrentStack<string> CreateConcurrentOperationStack()
        {
            ConcurrentStack<string> concurrentOperationStack = new();
            concurrentOperationStack.Push("Operation - 1");
            concurrentOperationStack.Push("Operation - 2");
            concurrentOperationStack.Push("Operation - 3");

            return concurrentOperationStack;
        }

        public static string? ReadFromConcurrentOperationStack(ConcurrentStack<string> concurrentOperationStack)
        {
            string? operation = null;
            if(concurrentOperationStack.TryPop(out string? op))
            {
                operation = op;
            }

            return operation;
        }
    }
}