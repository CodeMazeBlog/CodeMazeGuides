using System.Diagnostics.CodeAnalysis;

namespace UsingExceptInCSharp;

public class EmployeeComparer : IEqualityComparer<Employee>
{
    public bool Equals(Employee? x, Employee? y)
    {
        if (object.ReferenceEquals(x, y))
        {
            return true;
        }

        if(object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null)) 
        {
            return false;
        }

        return x.ID == y.ID && x.Name == y.Name && x.Age == y.Age && x.Department == y.Department;
    }

    public int GetHashCode([DisallowNull] Employee obj)
    {
        var hashID = obj.ID.GetHashCode();
        var hashName = obj.Name.GetHashCode();

        return hashID ^ hashName;
    }
}