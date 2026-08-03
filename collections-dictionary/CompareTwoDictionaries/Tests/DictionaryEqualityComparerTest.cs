using CompareTwoDictionaries;

namespace Tests;

public class DictionaryEqualityComparerTest
{
    private static readonly Dictionary<int, string> _dict1
         = new()
         {
            {1, "Rosary Ogechi"},
            {2, "Clare Chiamaka"}
         };

    private static readonly Dictionary<int, string> _dict2
         = new()
         {
            {1, "Rosary Ogechi"},
            {2, "Clare Chiamaka"}
         };

    private static readonly Dictionary<int, string> _dict3
         = new()
         {
            {1, "Rosary Ogechi"},
            {2, "Clare Chiamaka"}
         };

    private static readonly Dictionary<int, string> _dict4
        = new()
        {
            {1, "Clare Ogechi"},
            {2, "Rosary Chiamaka"}
        };

    [Fact]
    public void WhenUseSequenceEqualsIsCalledWithEqualDictionaries_ThenReturnsTrue()
    {
        Assert.True(DictionaryEqualityComparer.UseSequenceEqual(_dict1, _dict2));
    }

    [Fact]
    public void WhenUseEnumerableAllIsCalledWithEqualDictionaries_ThenReturnsTrue()
    {
        Assert.True(DictionaryEqualityComparer.UseEnumerableAll(_dict1, _dict2));
    }

    [Fact]
    public void WhenUseForeachLoopIsCalledWithEqualDictionaries_ThenReturnsTrue()
    {
        Assert.True(DictionaryEqualityComparer.UseForeachLoop(_dict1, _dict2));
    }

    [Fact]
    public void WhenUseSequenceEqualsIsCalledWithUnEqualDictionaries_ThenReturnsFalse()
    {
        Assert.False(DictionaryEqualityComparer.UseSequenceEqual(_dict3, _dict4));
    }

    [Fact]
    public void WhenUseEnumerableAllIsCalledWithUnEqualDictionaries_ThenReturnsFalse()
    {
        Assert.False(DictionaryEqualityComparer.UseEnumerableAll(_dict3, _dict4));
    }

    [Fact]
    public void WhenUseForeachLoopIsCalledWithUnEqualDictionaries_ThenReturnsFalse()
    {
        Assert.False(DictionaryEqualityComparer.UseForeachLoop(_dict3, _dict4));
    }
}