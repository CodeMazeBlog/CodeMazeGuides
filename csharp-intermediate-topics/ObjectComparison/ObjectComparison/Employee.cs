namespace ObjectComparisons;

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

    public static int CompareEmployeesByIdAscending(Employee? employee1, Employee? employee2)
    {
        if (employee1 is null)
        {
            return employee2 is null ? 0 : -1;
        }

        if (employee2 is null)
        {
            return 1;
        }

        return employee1.Id.CompareTo(employee2.Id);
    }

    public static int CompareEmployeesByIdDescending(Employee? employee1, Employee? employee2)
    {
        if (employee1 is null)
        {
            return employee2 is null ? 0 : -1;
        }

        if (employee2 is null)
        {
            return 1;
        }

        return employee2.Id.CompareTo(employee1.Id);
    }
}
