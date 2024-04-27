using CompareTwoDictionaries;

namespace Tests;

public class TeacherDictionaryComparisonTrueTest
{
    private static readonly Dictionary<int, Teacher> _dict1
        = new()
        {
            {1, new Teacher(){Name = "Rosary Ogechi", Age = 60}},
            {2, new Teacher(){Name = "Clare Chiamaka", Age = 35}}
        };

    private static readonly Dictionary<int, Teacher> _dict2
        = new()
        {
            {1, new Teacher(){Name = "Rosary Ogechi", Age = 60}},
            {2, new Teacher(){Name = "Clare Chiamaka", Age = 35}},
        };

    private readonly TeacherDictionaryComparisonHelper _comparer = new(_dict1, _dict2);

    [Fact]
    public void WhenUseIEqualityComparerIsCalledWithEqualDictionaries_ThenReturnsTrue()
    {
        Assert.True(_comparer.UseIEqualityComparer());
    }
}