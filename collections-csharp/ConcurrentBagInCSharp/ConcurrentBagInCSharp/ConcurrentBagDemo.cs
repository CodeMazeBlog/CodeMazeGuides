using System.Collections.Concurrent;

namespace ConcurrentBagInCSharp
{
    public class ConcurrentBagDemo
    {
        public static ConcurrentBag<int> CreateEmptyConcurrentBag()
        {
            return new ConcurrentBag<int>();
        }

        public static ConcurrentBag<int> CreateConcurrentBagWithInitialItems()
        {
            return new ConcurrentBag<int>() { 2, 4, 6, 8, 10 };
        }

        public static ConcurrentBag<int> CreateConcurrentBag()
        {
            var myList = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };

            return new ConcurrentBag<int>(myList);
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

        public static List<int> RemoveFromConcurrentBag(ConcurrentBag<int> numbersBag)
        {
            var result = new List<int>();
            if (numbersBag.TryTake(out int number))
            {
                result.Add(number);
            }

            return result;
        }

        public static List<int> RemoveFromConcurrentBagConcurrently(ConcurrentBag<int> bag)
        {
            var numbersList = new List<int>();
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

        public static List<int> AccessItemFromAConcurrentBag(ConcurrentBag<int> bag)
        {
            var result = new List<int>();

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

        public static List<int> DrainOwnQueue()
        {
            var bag = new ConcurrentBag<int>();
            for (var i = 1; i <= 5; i++)
            {
                bag.Add(i);
            }

            var taken = new List<int>();
            while (bag.TryTake(out var item))
            {
                taken.Add(item);
            }

            return taken;
        }

        public static List<int> DrainStolenQueue()
        {
            var bag = new ConcurrentBag<int>();
            var taken = new List<int>();

            // Dedicated threads, never Task.Run: the thread pool is free to hand both pieces of
            // work to the same thread, and a consumer running on the producer's thread pops its
            // own queue last in, first out instead of stealing.
            var producer = new Thread(() =>
            {
                for (var i = 0; i < 5; i++)
                {
                    bag.Add(i);
                }
            });
            producer.Start();
            producer.Join();

            var consumer = new Thread(() =>
            {
                while (bag.TryTake(out var item))
                {
                    taken.Add(item);
                }
            });
            consumer.Start();
            consumer.Join();

            return taken;
        }

        public static int[] ConcurrentBagToArrayMethod(ConcurrentBag<int> bag)
        {
            return bag.ToArray();
        }

        public static int[] ConcurrentBagCopyToMethod(ConcurrentBag<int> bag)
        {
            // Count and CopyTo are two separate operations. In a multithreaded program another
            // thread can add an item between them, and CopyTo then throws ArgumentException
            // because the destination is too short. Size the destination from a snapshot,
            // or generously, whenever other threads can still write to the bag.
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
