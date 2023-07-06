namespace SortingGenericList.Library;

public sealed class DescendingIntComparison : IComparer<int>
{
    public int Compare(int x, int y) => y.CompareTo(x);
}