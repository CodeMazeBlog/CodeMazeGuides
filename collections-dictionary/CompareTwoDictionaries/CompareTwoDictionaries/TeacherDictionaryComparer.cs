using System.Diagnostics.CodeAnalysis;

namespace CompareTwoDictionaries;

public class TeacherDictionaryComparer : IEqualityComparer<Dictionary<int, Teacher>>
{
    public bool Equals(Dictionary<int, Teacher>? x, Dictionary<int, Teacher>? y)
    {
        if (x == null || y == null) return false;
        if (x.Count != y.Count) return false;
        if (x.Keys.Except(y.Keys).Any() || y.Keys.Except(x.Keys).Any()) return false;

        foreach (var pair in x)
        {
            if (pair.Value.Name != y[pair.Key].Name && pair.Value.Age != y[pair.Key].Age) return false;
        }

        return true;
    }

    public int GetHashCode([DisallowNull] Dictionary<int, Teacher> obj)
    {
        int hashcode = 17;
        foreach (var pair in obj)
        {
            hashcode = HashCode.Combine(pair.Key, pair.Value.Name, pair.Value.Age);
        }

        return hashcode;
    }
}