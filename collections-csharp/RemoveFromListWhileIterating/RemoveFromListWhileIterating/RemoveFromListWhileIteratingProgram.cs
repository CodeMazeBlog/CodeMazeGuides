using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace RemoveFromListWhileIterating
{
    [MemoryDiagnoser]
    public class RemoveFromListWhileIteratingProgram
    {
        private static int TestIterations = 100;
        private static List<int> NumberList = Enumerable.Range(1, 200000).ToList();
        
        [Benchmark]
        public void RunReverseIterate()
        {
            for (int i = 0; i < TestIterations; i++)
            {
                ReverseIterate(NumberList);
            }
        }

        [Benchmark]
        public void RunSimpleIterateRemoveWithToList()
        {
            for (int i = 0; i < TestIterations; i++)
            {
                SimpleIterateRemoveWithToList(NumberList);
            }
        }

        [Benchmark]
        public void RunOneLineRemoveAll()
        {
            for (int i = 0; i < TestIterations; i++)
            {
                OneLineRemoveAll(NumberList);
            }
        }

        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<RemoveFromListWhileIteratingProgram>();
        }

        public static List<int> NaiveIterateRemove(List<int> sourceList)
        {
            //This will fail with System.InvalidOperationException:
            foreach (var el in sourceList)
            {
                if (el % 2 == 0) //try remove evens
                {
                    sourceList.Remove(el);
                }
            }

            return sourceList;
        }

        public static List<int> ReverseIterate(List<int> sourceList)
        {
            //by iterating backwards, we avoid InvalidOperationException
            for (int i = sourceList.Count - 1; i >= 0; i--)
            {
                if (sourceList[i] % 2 == 0)
                {
                    sourceList.RemoveAt(i);
                }
            }
            //NB: it is also possible to use the .Reverse() operator but this will create an array copy so you may as well use .ToList()
            return sourceList;
        }

        public static List<int> SimpleIterateRemoveWithToList(List<int> sourceList)
        {
            foreach (var el in sourceList.ToList())
            {
                if (el % 2 == 0) //remove evens
                {
                    sourceList.Remove(el);
                }
            }

            return sourceList;
        }

        public static List<int> OneLineRemoveAll(List<int> sourceList)
        {
            sourceList.RemoveAll(el => el % 2 == 0);
            return sourceList;
        }

        public static void PerformOperation(int element)
        {
            // This method would contain the logic needed to be performed
            // per iteration on each element
            Console.WriteLine($"Checking {element}");
        }

        public static List<int> OneLineRemoveAllWithSideEffect(List<int> sourceList)
        {
            sourceList.RemoveAll(item =>
            {
                PerformOperation(item);
                // In the end return true if the item is to be removed
                return item % 2 == 0;
            }); ;
            return sourceList;
        }

    }
}
