namespace ActionAndFuncDelegates
{
    public class BinarySearchIndex
    {
        private readonly SortComparer comparer;
        private readonly int[] data;

        public BinarySearchIndex(IEnumerable<int> dataSource, Func<int, int, int> compareDelegate)
        {
            comparer = new SortComparer(compareDelegate);
            data = dataSource
                .OrderBy(x => x, comparer)
                .ToArray();
        }

        public void Find(int x, Action<int> actionWhenFound, Action<int> actionWhenNotFound)
        {
            var index = Array.BinarySearch(data, x, comparer);

            if (index < 0)
                actionWhenNotFound(x);
            else
                actionWhenFound(x);
        }

        public static int DefaultIntOrder(int x, int y) => x.CompareTo(y);

        internal class SortComparer : IComparer<int>
        {
            private readonly Func<int, int, int> compareDelegate;

            public SortComparer(Func<int, int, int> compareDelegate)
            {
                this.compareDelegate = compareDelegate;
            }

            public int Compare(int x, int y)
            {
                return compareDelegate(x, y);
            }
        }
    }
}