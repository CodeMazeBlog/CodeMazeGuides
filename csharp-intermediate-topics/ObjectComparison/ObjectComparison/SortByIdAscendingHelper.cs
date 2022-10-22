using System.Collections;

namespace ObjectComparisons
{
    public class SortByIdAscendingHelper : IComparer
    {
        public int Compare(object? x, object? y)
        {
            if ((x is null) || (y is null))
            {
                return 0;
            }

            Employee? employee1 = x as Employee;
            Employee? employee2 = y as Employee;

            int value1 = employee1?.Id ?? 0;
            int value2 = employee2?.Id ?? 0;

            return value1.CompareTo(value2);
        }
    }

}
