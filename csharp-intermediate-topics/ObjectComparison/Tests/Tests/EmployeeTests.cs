using ObjectComparisons;
using Xunit;

namespace Tests;

public class EmployeeTests
{
    [Fact]
    public void EmployeeArray_WhenDefaultSorted_ThenIsOrderedBasedOnId()
    {
        var employees = GetEmployees();

        Array.Sort(employees);

        Assert.Equal([1, 2, 3, 4, 5], employees.Select(e => e.Id));
    }

    [Fact]
    public void EmployeeArray_WhenSortedUsingIComparer_ThenIsOrderedBasedOnId()
    {
        var employees = GetEmployees();

        Array.Sort(employees, Employee.SortByIdAscending());

        Assert.Equal([1, 2, 3, 4, 5], employees.Select(e => e.Id));
    }

    [Fact]
    public void EmployeeArray_WhenSortedUsingDescendingIComparer_ThenIsOrderedBasedOnIdDescending()
    {
        var employees = GetEmployees();

        Array.Sort(employees, Employee.SortByIdDescending());

        Assert.Equal([5, 4, 3, 2, 1], employees.Select(e => e.Id));
    }

    [Fact]
    public void EmployeeArray_WhenSortedUsingComparisonDelegate_ThenIsOrderedBasedOnId()
    {
        var employees = GetEmployees();

        Array.Sort(employees, Employee.CompareEmployeesByIdAscending);

        Assert.Equal([1, 2, 3, 4, 5], employees.Select(e => e.Id));
    }

    [Fact]
    public void EmployeeList_WhenSortedUsingLambda_ThenIsOrderedBasedOnName()
    {
        var employees = GetEmployees().ToList();

        employees.Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.Ordinal));

        Assert.Equal(["Alen", "Dan", "Eric", "John", "Tom"], employees.Select(e => e.Name));
    }

    [Fact]
    public void EmployeeArrayWithNulls_WhenSortedByEveryApproach_ThenNullsComeFirstAndIdsAreOrdered()
    {
        Employee?[] expected = [null, null, .. GetEmployees().OrderBy(e => e.Id)];

        Employee?[] byIComparable = GetEmployeesWithNulls();
        Array.Sort(byIComparable);

        Employee?[] byIComparer = GetEmployeesWithNulls();
        Array.Sort(byIComparer, Comparer<Employee?>.Create(new SortByIdAscendingHelper().Compare));

        Employee?[] byDelegate = GetEmployeesWithNulls();
        Array.Sort(byDelegate, Employee.CompareEmployeesByIdAscending);

        Assert.Equal(expected.Select(e => e?.Id), byIComparable.Select(e => e?.Id));
        Assert.Equal(expected.Select(e => e?.Id), byIComparer.Select(e => e?.Id));
        Assert.Equal(expected.Select(e => e?.Id), byDelegate.Select(e => e?.Id));
    }

    [Fact]
    public void RandomEmployees_WhenSortedByEveryApproach_ThenMatchLinqOrderBy()
    {
        var random = new Random(7);
        var employees = Enumerable.Range(0, 500)
            .Select(i => new Employee(random.Next(1_000), $"Employee {i}"))
            .ToArray();
        var expected = employees.Select(e => e.Id).Order().ToArray();

        var byIComparable = (Employee[])employees.Clone();
        Array.Sort(byIComparable);

        var byIComparer = (Employee[])employees.Clone();
        Array.Sort(byIComparer, Employee.SortByIdAscending());

        var byDelegate = (Employee[])employees.Clone();
        Array.Sort(byDelegate, Employee.CompareEmployeesByIdAscending);

        Assert.Equal(expected, byIComparable.Select(e => e.Id));
        Assert.Equal(expected, byIComparer.Select(e => e.Id));
        Assert.Equal(expected, byDelegate.Select(e => e.Id));
    }

    [Fact]
    public void SortedSet_WhenGivenComparerCreatedFromLambda_ThenIsOrderedBasedOnName()
    {
        var employeesByName = new SortedSet<Employee>(
            GetEmployees(),
            Comparer<Employee>.Create((x, y) => string.Compare(x.Name, y.Name, StringComparison.Ordinal)));

        Assert.Equal(["Alen", "Dan", "Eric", "John", "Tom"], employeesByName.Select(e => e.Name));
    }

    private static Employee[] GetEmployees()
    {
        return
        [
            new Employee(4, "John"),
            new Employee(2, "Tom"),
            new Employee(1, "Eric"),
            new Employee(5, "Dan"),
            new Employee(3, "Alen")
        ];
    }

    private static Employee?[] GetEmployeesWithNulls()
    {
        var employees = GetEmployees();

        return [employees[0], null, employees[1], employees[2], null, employees[3], employees[4]];
    }
}
