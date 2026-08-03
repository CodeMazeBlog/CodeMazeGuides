namespace ObjectComparisons
{
    public partial class Employee : IComparable<Employee>
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public Employee(int id, string? name)
        {
            Id = id;
            Name = name;
        }

        public int CompareTo(Employee? otherEmployee)
        {
            return otherEmployee is null ? 1 : Id.CompareTo(otherEmployee.Id);
        }

        public static IComparer<Employee> SortByIdAscending()
        {
            return new SortByIdAscendingHelper();
        }

        public static IComparer<Employee> SortByIdDescending()
        {
            return new SortByIdDescendingHelper();
        }

        public static int CompareEmployeesByIdAscending(Employee employee1, Employee employee2)
        {
            if ((employee1 is null) || (employee2 is null))
            {
                return 0;
            }

            int value1 = employee1?.Id ?? 0;
            int value2 = employee2?.Id ?? 0;

            return value1.CompareTo(value2);
        }

        public static int CompareEmployeesByIdDescending(Employee employee1, Employee employee2)
        {
            if ((employee1 is null) || (employee2 is null))
            {
                return 0;
            }

            int value1 = employee1?.Id ?? 0;
            int value2 = employee2?.Id ?? 0;

            return value2.CompareTo(value1);
        }
    }
}
