using System.Collections;

namespace ObjectComparisons
{
    public class Employee : IComparable
    {
        public Employee(int id, string? name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public int CompareTo(object? obj)
        {
            Employee? employee = obj as Employee;
            return Id.CompareTo(employee?.Id);
        }

        private class SortByIdAscendingHelper : IComparer
        {
            public int Compare(object? x, object? y)
            {
                if ((x == null) || (y == null))
                {
                    return 0;
                }

                Employee? employee1 = x as Employee;
                Employee? employee2 = y as Employee;

                int? value1 = employee1?.Id;
                int? value2 = employee2?.Id;

                int v1 = value1.HasValue ? value1.Value : 0;
                int v2 = value2.HasValue ? value2.Value : 0;

                return v1.CompareTo(v2);
            }
        }

        private class SortByIdDescendingHelper : IComparer
        {
            public int Compare(object? x, object? y)
            {
                if ((x == null) || (y == null))
                {
                    return 0;
                }

                Employee? employee1 = x as Employee;
                Employee? employee2 = y as Employee;

                int? value1 = employee1?.Id;
                int? value2 = employee2?.Id;

                int v1 = value1.HasValue ? value1.Value : 0;
                int v2 = value2.HasValue ? value2.Value : 0;

                return v2.CompareTo(v1);
            }
        }

        public static IComparer SortByIdAscending()
        {
            return (IComparer)new SortByIdAscendingHelper();
        }

        public static IComparer SortByIdDescending()
        {
            return (IComparer)new SortByIdDescendingHelper();
        }

        public static int CompareEmployeesByIdAscending(Employee employee1, Employee employee2)
        {
            if ((employee1 == null) || (employee2 == null))
            {
                return 0;
            }

            int? value1 = employee1?.Id;
            int? value2 = employee2?.Id;

            int v1 = value1 ?? 0;
            int v2 = value2 ?? 0;

            return v1.CompareTo(v2);
        }

        public static int CompareEmployeesByIdDescending(Employee employee1, Employee employee2)
        {
            if ((employee1 == null) || (employee2 == null))
            {
                return 0;
            }

            int? value1 = employee1?.Id;
            int? value2 = employee2?.Id;

            int v1 = value1 ?? 0;
            int v2 = value2 ?? 0;

            return v2.CompareTo(v1);
        }
    }
}
