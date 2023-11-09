namespace PermutationsOfAString
{
    public static class ListExtension
    {
        public static void AddCopy<T>(this List<T> list, T item) where T : ICloneable
        {
            list.Add((T)item.Clone());
        }
    }
}
