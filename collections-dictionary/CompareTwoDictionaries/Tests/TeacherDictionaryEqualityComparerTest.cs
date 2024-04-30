using CompareTwoDictionaries;

namespace Tests;

public class TeacherDictionaryEqualityComparerTest
{
    private static readonly Dictionary<int, Teacher> _teacherDict1
        = new()
        {
            { 1, new() {Name = "Rosary Ogechi", Age = 60} },
            { 2, new() {Name = "Clare Chiamaka", Age = 35} }
        };

    private static readonly Dictionary<int, Teacher> _teacherDict2
        = new()
        {
            { 1, new() {Name = "Rosary Ogechi", Age = 60} },
            { 2, new() {Name = "Clare Chiamaka", Age = 35} }
        };

    private static readonly Dictionary<int, Teacher> _teacherDict3
        = new()
        {
            { 1, new() {Name = "Rosary Ogechi", Age = 60} },
            { 2, new() {Name = "Clare Chiamaka", Age = 35} }
        };

    private static readonly Dictionary<int, Teacher> _teacherDict4
        = new()
        {
            { 1, new() {Name = "Clare Ogechi", Age = 35} },
            { 2, new() {Name = "Rosary Chiamaka", Age = 60} }
        };

    [Fact]
    public void WhenUseIEqualityComparerIsCalledWithEqualDictionaries_ThenReturnsTrue()
    {
        Assert.True(TeacherDictionaryEqualityComparer.UseComparer(_teacherDict1, _teacherDict2));
    }

    [Fact]
    public void WhenUseIEqualityComparerIsCalledWithUnEqualDictionaries_ThenReturnsFalse()
    {
        Assert.False(TeacherDictionaryEqualityComparer.UseComparer(_teacherDict3, _teacherDict4));
    }
}