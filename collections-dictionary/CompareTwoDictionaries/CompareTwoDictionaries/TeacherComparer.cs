using System.Diagnostics.CodeAnalysis;

namespace CompareTwoDictionaries;

public class TeacherComparer : IEqualityComparer<Teacher>
{
    public bool Equals(Teacher? x, Teacher? y)
    {
        if (x == null || y == null) return false;
        if (x.Name != y.Name && x.Age != y.Age) return false;

        return true;
    }

    public int GetHashCode([DisallowNull] Teacher obj)
    {
        return HashCode.Combine(obj.Age, obj.Name);
    }
}