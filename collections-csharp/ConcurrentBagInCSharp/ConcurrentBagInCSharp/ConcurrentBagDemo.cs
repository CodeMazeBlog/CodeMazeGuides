using System.Collections.Concurrent;
using System.Collections;

namespace ConcurrentBagInCSharp
{
    public class ConcurrentBagDemo
    {
        public static ConcurrentBag<int> CreateConcurrentBag()
        {
            ConcurrentBag<int> myNumbers = new();

            var myConcurrentBag = new ConcurrentBag<int>() { 2, 4, 6, 8, 10 };
            var myConcurrentBagCount = myConcurrentBag.Count;

            var myList = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            var anotherConcurrentBag = new ConcurrentBag<int>(myList);

            return anotherConcurrentBag;
        }

        public static ConcurrentBag<int> CreateAndAddToConcurrentBagConcurrently()
        {
            ConcurrentBag<int> numbersBag = new();
            // Add elements to the bag concurrently
            Parallel.For(0, 1000, i =>
            {
                numbersBag.Add(i);
            });

            return numbersBag;
        }

        public static ArrayList RemoveFromConcurrentBag(ConcurrentBag<int> numbersBag)
        {
            var result = new ArrayList();
            if (numbersBag.TryTake(out int number))
            {
                result.Add(number);
            }

            return result;
        }

        public static ArrayList RemoveFromConcurrentBagConcurrently(ConcurrentBag<int> bag)
        {
            var numbersList = new ArrayList();
            Parallel.For(0, 20, i =>
            {
                if (bag.TryTake(out int number))
                {
                    Console.WriteLine($"Thread {Environment.CurrentManagedThreadId} took item: {number}");
                    numbersList.Add(number);
                }
            });

            return numbersList;
        }

        public static ArrayList AccessItemFromAConcurrentBag(ConcurrentBag<int> bag)
        {
            var result = new ArrayList();

            if (bag.TryPeek(out int number))
            {
                result.Add(number);
            }

            return result;
        }

        public static void AccessItemFromAConcurrentBagConcurrently(ConcurrentBag<int> bag)
        {
            Parallel.For(0, 50, i =>
            {
                if (bag.TryPeek(out int number))
                {
                    Console.WriteLine("Thread {0} peeked item: {1}", Environment.CurrentManagedThreadId, number);
                }
            });
        }

        public static int[] ConcurrentBagToArrayMethod(ConcurrentBag<int> bag)
        {
            var myArray = new int[bag.Count];
            myArray = bag.ToArray();

            return myArray;
        }

        public static int[] ConcurrentBagCopyToMethod(ConcurrentBag<int> bag)
        {
            var someArray = new int[bag.Count];
            bag.CopyTo(someArray, 0);

            return someArray;
        }
        
        public static void ConcurrentBagClearMethod(ConcurrentBag<int> bag)
        {
            bag.Clear();

            Console.WriteLine($"My concurrent bag contains {bag.Count} item."); // My concurrent bag contains 0 item.
        }
    }
}