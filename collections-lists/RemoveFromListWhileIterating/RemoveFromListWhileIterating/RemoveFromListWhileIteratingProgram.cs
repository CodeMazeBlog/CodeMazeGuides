namespace RemoveFromListWhileIterating
{

    public class RemoveFromListWhileIteratingProgram
    {
        private static readonly List<int> _numberList = Enumerable.Range(1, 20).ToList();

        public static void Main(string[] args)
        {
            SimpleIterateRemoveWithToList(_numberList);
            ReverseIterate(_numberList);
            OneLineRemoveAll(_numberList);
            OneLineRemoveAllWithSideEffect(_numberList);
        }

        public static List<int> NaiveIterateRemove(List<int> sourceList)
        {
            foreach (var el in sourceList)
            {
                if (el % 2 == 0)
                {
                    sourceList.Remove(el);
                }
            }

            return sourceList;
        }

        public static List<int> ReverseIterate(List<int> sourceList)
        {
            for (int i = sourceList.Count - 1; i >= 0; i--)
            {
                if (sourceList[i] % 2 == 0)
                {
                    sourceList.RemoveAt(i);
                }
            }

            return sourceList;
        }

        public static List<int> SimpleIterateRemoveWithToList(List<int> sourceList)
        {
            foreach (var el in sourceList.ToList())
            {
                if (el % 2 == 0)
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
            Console.WriteLine($"Checking {element}");
        }

        public static List<int> OneLineRemoveAllWithSideEffect(List<int> sourceList)
        {
            sourceList.RemoveAll(item =>
            {
                PerformOperation(item);
                return item % 2 == 0;
            });
            
            return sourceList;
        }
    }
}
