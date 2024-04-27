namespace CompareTwoDictionaries;

public class TeacherDictionaryComparisonHelper(Dictionary<int, Teacher> Dict1, Dictionary<int, Teacher> Dict2)
{
    public bool UseIEqualityComparer()
        => new TeacherDictionaryComparer().Equals(Dict1, Dict2);
}