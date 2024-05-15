using System.Diagnostics.CodeAnalysis;

namespace UsingExceptInCSharp;

public class EmployeeComparer : IEqualityComparer<Employee>
{
    public bool Equals(Employee? x, Employee? y)
    {
        if (x is null && y is null) return true;
        if (x is null || y is null) return false;

        return x.ID == y.ID && x.Name == y.Name && x.Age == y.Age && x.Department == y.Department;
    }

    public int GetHashCode([DisallowNull] Employee obj)
    {
        var hashID = obj.ID.GetHashCode();
        var hashName = obj.Name.GetHashCode();

        return hashID ^ hashName;
    }
}