namespace ObjectComparisons;

public class SortByIdAscendingHelper : IComparer<Employee>
{
    public int Compare(Employee? firstEmployee, Employee? secondEmployee)
    {
        if (firstEmployee is null)
        {
            return secondEmployee is null ? 0 : -1;
        }

        if (secondEmployee is null)
        {
            return 1;
        }

        return firstEmployee.Id.CompareTo(secondEmployee.Id);
    }
}
