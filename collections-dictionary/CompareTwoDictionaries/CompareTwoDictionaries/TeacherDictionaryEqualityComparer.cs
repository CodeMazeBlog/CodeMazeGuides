namespace CompareTwoDictionaries;

public class TeacherDictionaryEqualityComparer()
{
    public static bool UseComparer(Dictionary<int, Teacher> teacherDict1, Dictionary<int, Teacher> teacherDict2)
    {
        if (DictionaryEqualityComparer.AreKeysAndCountNotEqual(teacherDict1, teacherDict2))
        {
            return false;
        }

        var comparer = new TeacherComparer();
        foreach (var kvp in teacherDict1)
        {
            if (!teacherDict2.TryGetValue(kvp.Key, out var value) || !comparer.Equals(value, kvp.Value))
            {
                return false;
            }
        }

        return true;
    }
}