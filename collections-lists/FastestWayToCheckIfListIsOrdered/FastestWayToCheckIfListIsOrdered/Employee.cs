namespace FastestWayToCheckIfListIsOrdered;

public record Employee(string Name, DateTime BirthDate, double Salary) : IComparable<Employee>
{
    public int CompareTo(Employee? other)
        => BirthDate.CompareTo(other?.BirthDate);
}