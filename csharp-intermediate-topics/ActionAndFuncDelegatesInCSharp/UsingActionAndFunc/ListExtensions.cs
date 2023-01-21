namespace UsingActionAndFunc
{
    public static class ListExtensions
    {
        public static List<T> Filter<T>(this List<T> items, Func<T, bool> predicate)
        {
            var list = new List<T>();

            foreach (var item in items)
            {
                if (predicate(item))
                {
                    list.Add(item);
                }
            }

            return list;
        }
    }
}
